using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class EnemigoEspecialFSM : MonoBehaviour
{
    
    #region variables
    [Header("Destinos")]
    public GameObject jugador;

    //Maquina de estados
    private StateMachineEngine enemigoEspecialFSM;

    //Estados
    private EstadosEnemigoEspecial estadosEnemigo;
    private int estadoJugador;

    [Header("Variables de control")]
    [SerializeField] private string estadoActual;

    //Percepciones
    public bool veJugador = false;
    public bool haAlcanzado = false;
    public bool vidaBaja = false;
    public bool vidaCompleta = false;
    public bool haEscapado = false;

    //Otras variables
    private float health = 5;
    private int maxHealth = 5;
    private bool recovered = false;
    private float speed = 1.5f;

    private float lastTimeAttack = 0;
    private float attackCD = 1f;
    private int distanciaPatrulla = 8;
    private int distanciaEscape = 12;
    private float velocidadCuracion = 3;

    public GameManager GM;

    private Vector2 destino;    //la posicion del jugador en ese momento
    private bool enMovimiento = true;

    //Control Sprite
    SpriteRenderer sprite;

    #endregion variables


    // Start is called before the first frame update
    void Start()
    {
        //Buscar objetos de la escena 
        GM = GameManager.FindObjectOfType<GameManager>();
        jugador = GameObject.Find("Player");

        //Coger sprite
        sprite = this.GetComponent<SpriteRenderer>();

        estadosEnemigo = new EstadosEnemigoEspecial();

        enemigoEspecialFSM = new StateMachineEngine(); 

        CreateStateMachine();
    }

    private void CreateStateMachine()
    {
        #region Percepciones
        Perception veJugadorPercepcion = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => veJugador);
        Perception noVeJugadorPercepcion = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => !veJugador);

        Perception haAlcanzadoPercepcion = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => haAlcanzado);
        Perception noHaAlcanzadoPercepcion = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => !haAlcanzado);

        Perception puedeCurarsePercepcion = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => vidaBaja && !recovered);

        Perception vidaCompletaPerception = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => vidaCompleta);

        Perception haEscapadoPerception = enemigoEspecialFSM.CreatePerception<ValuePerception>(() => haEscapado);
        #endregion Percepciones

        #region Estados
        State patrullandoState = enemigoEspecialFSM.CreateEntryState(estadosEnemigo.Patrullando, Patrullando);
        State acercandoseState = enemigoEspecialFSM.CreateState(estadosEnemigo.Acercandose, Acercandose);
        State atacandoState = enemigoEspecialFSM.CreateState(estadosEnemigo.Atacando, Atacando);
        State escapandoState = enemigoEspecialFSM.CreateState(estadosEnemigo.Escapando, Escapando);
        State curandoState = enemigoEspecialFSM.CreateState(estadosEnemigo.Curando, Curando);
        #endregion Estados

        #region Transiciones
        enemigoEspecialFSM.CreateTransition("El jugador está a la vista", patrullandoState, veJugadorPercepcion, acercandoseState);
        enemigoEspecialFSM.CreateTransition("Enemigo ha alcanzado al jugador", acercandoseState, haAlcanzadoPercepcion, atacandoState);
        enemigoEspecialFSM.CreateTransition("El jugador se ha alejado", atacandoState, noHaAlcanzadoPercepcion, acercandoseState);
        enemigoEspecialFSM.CreateTransition("El jugador ya no está a la vista", acercandoseState, noVeJugadorPercepcion, patrullandoState);
        enemigoEspecialFSM.CreateTransition("Patrullando: Vida baja y puede curarse", patrullandoState, puedeCurarsePercepcion, escapandoState);
        enemigoEspecialFSM.CreateTransition("Acercandose: Vida baja y puede curarse", acercandoseState, puedeCurarsePercepcion, escapandoState);
        enemigoEspecialFSM.CreateTransition("Atacando: Vida baja y puede curarse", atacandoState, puedeCurarsePercepcion, escapandoState);
        enemigoEspecialFSM.CreateTransition("Ha escapado", escapandoState, haEscapadoPerception, curandoState);
        enemigoEspecialFSM.CreateTransition("Se ha curado", curandoState, vidaCompletaPerception, patrullandoState);
        #endregion Transiciones
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.estadoJugador != 1)
        {
            return;
        }


        if(GM.modoJuego == -1)
        {
            return;
        }

        enemigoEspecialFSM.Update();
        Debug.Log(estadoActual);

        actualizarDestino();
        comprobarJugadorVisible();
        comprobarDestino();
        moving();

        //esto es una ñapa porque las balas hacen daño a enemy y hay que recoger los valores
        if(estadoActual != estadosEnemigo.Curando)
        {
            health = GetComponent<Enemy>().health;
        }
        vidaBaja = health <= 2;

        if (!recovered && estadoActual == estadosEnemigo.Curando)
        {
            Curacion();
        }
    }

    
    private void Patrullando()
    {
        estadoActual = estadosEnemigo.Patrullando;
        enMovimiento = true;
        destino = Vector2.negativeInfinity;

        //Selecciona una dirección aleatoria a la que moverse
        //Se move hacia esa direccion en moving()
        //Cuando llega al destino escoge otro nuevo
        //Si ve al jugador cambia a acercandose
    }
    private void Acercandose()
    {
       // Debug.Log("Enemigo: Acercándose al jugador");
        estadoActual = estadosEnemigo.Acercandose;
        enMovimiento = true;

        //Va hacia el jugador
        //Se hace con la función moving() que se llama en cada Update
        //El enemigo se mantiene en este estado siempre que el jugador sea visible pero no se le haya alcanzado aún
    }

    private void Atacando()
    {
        //Debug.Log("Enemigo: Atacando al jugador");
        estadoActual = estadosEnemigo.Atacando;

        //restar vida al jugador
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //si esta colisionando con el player
        if (collision.gameObject.tag == "Player" && estadoActual == estadosEnemigo.Atacando)
        {
            if (Time.time - lastTimeAttack >= attackCD)
            {
                lastTimeAttack = Time.time;
                Debug.Log("Enemigo a melee ataca al jugador");
                //esto es una ñapa porque playerLife es un objeto distinto de player
         //       FindObjectOfType<PlayerLife>().TakeDamage();
            }
        }
    }

    private void Escapando()
    {
        estadoActual = estadosEnemigo.Escapando;
        enMovimiento = true;
        destino = Vector2.negativeInfinity;

        //Selecciona un destino lejos del jugador
        //Se mueve con moving() hacia ese destino
        //Cuando llega, se cura

    }
    private void Curando()
    {
        estadoActual = estadosEnemigo.Curando;
        enMovimiento = false;

        //Se cura hasta completar su vida
        //Cambia una flag porque solo se puede hacer una vez
        //Vuelve a patrullar

    }

    void Curacion()
    {
        if (health < maxHealth)
        {
            health += Time.deltaTime * velocidadCuracion;
            health = Mathf.Clamp(health, 0, maxHealth);
            //esto es una ñapa porque hay que volver a actualizar los valores a enemy para que todo tenga sentido
            GetComponent<Enemy>().health = (int)health;
            if (health >= maxHealth)
            {
                recovered = true;
                vidaCompleta = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "BulletEnemy")
        {
            actualizarDestino(true);
        }
    }

    void actualizarDestino(bool force = false)
    {
        float PosAnterior = this.transform.position.x;
        if (estadoActual == estadosEnemigo.Patrullando)
        {
            //si no tienes destino, busca uno
            //si has llegado al destino, busca uno nuevo
            if (destino.x < float.MinValue || force || haAlcanzado)
            {
                destino = DestinoAleatorio(distanciaPatrulla);
            }
        }
        else if (estadoActual == estadosEnemigo.Acercandose ||estadoActual == estadosEnemigo.Atacando)
        {
            //ir hacia el enemigo
            destino = new Vector2(jugador.transform.position.x, jugador.transform.position.y);
        }
        else if (estadoActual == estadosEnemigo.Escapando)
        {
            //si no tiene destino de escape, busca uno
            if (destino.x < float.MinValue)
            {
                destino = DestinoAleatorio(distanciaEscape);
            }
            //si has llegado al destino de escape, has escapado
            else if (haAlcanzado || force)
            {
                haEscapado = true;
            }
        }

        if(destino.x >PosAnterior)
        {
           sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    Vector2 DestinoAleatorio(float distancia)
    {
        float xDirection = Random.Range(transform.position.x - distancia, transform.position.x + distancia);
        float yDirection = Random.Range(transform.position.y - distancia, transform.position.y + distancia);

        return new Vector2(xDirection, yDirection);
    }

    void comprobarDestino()
    {
        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("El enemigo está a distancia" + distanceTo);    //comprobar que la distancia se está calculando correctamente
        if (distanceTo <= 1)
        {
            haAlcanzado = true;
        } else
        {
            haAlcanzado = false;
        }
    }

    void comprobarJugadorVisible()
    {
        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("-----El enemigo está a distancia" + distanceTo);   //comprobar que la distancia se está calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le verá y comenzará a acercarse a él.
        if(distanceTo <=10){
            veJugador = true;
        }
        else
        {
            veJugador = false;
        }

    }

    void moving()
    {
        if(enMovimiento)//El enemigo debe estar en este estado para moverse
        {
            //Va hacia el jugador
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, destino, step);    //MoveTowards(posicion actual, destino, distancia máxima)
        }
    }


    public void TakeDamage(int amount)
    {
        //El enemigo muere cuando le alcanza una bala del jugador
        health = health - amount;
        if (health <= 0)
        {
            veJugador = false;
            Destroy(this.gameObject);

            return;
        }
    }
}
