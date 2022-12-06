using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM1: MonoBehaviour
{

    #region variables
    [Header("Destinos")]
    public GameObject jugador;

    //Maquina de estados
    private StateMachineEngine enemigoFSM;

    //Estados
    private EstadosEnemigo estadosEnemigo;
    private int estadoJugador;

    [Header("Variables de control")]
    [SerializeField] private string estadoActual;

    //Percepciones
    public bool veJugador = false;
    public bool haAlcanzado = false;
    public bool existeJugador= false;

    //Otras variables
    private int health = 1;
    private float speed = 1.5f;
    public GameManager GM;

    private Vector2 destino;    //la posicion del jugador en ese momento


    //Control Sprite
    SpriteRenderer sprite;
    private Vector2 destinoAnterior;


    //Control navMesh
    public Transform[] targetPoints;
    ControlNavMesh control;
    VisorEnemigo visor;

    #endregion variables



   // Start is called before the first frame update
   void Start()
    {
        //Buscar objetos de la escena 
        GM = GameManager.FindObjectOfType<GameManager>();
        jugador = GameObject.Find("Player");
        control = this.GetComponent<ControlNavMesh>();
        visor = this.GetComponent<VisorEnemigo>();
        //Coger sprite
        sprite = this.GetComponent<SpriteRenderer>();


        estadosEnemigo = new EstadosEnemigo();

        enemigoFSM = new StateMachineEngine();

        CreateStateMachine();
    }

    private void CreateStateMachine()
    {
        #region Percepciones
        Perception existeJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => existeJugador);  //descansando

        Perception veJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => veJugador); // atacando (ir hacia el personaje)
        Perception noVeJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => !veJugador); //acercandose (ir hacia los navmesh)

        Perception haAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => haAlcanzado);
        Perception noHaAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => !haAlcanzado);
        #endregion Percepciones

        #region Estados
        State descansandoState = enemigoFSM.CreateEntryState(estadosEnemigo.Descansando, Descansando);
        State acercandoseState = enemigoFSM.CreateState(estadosEnemigo.Acercandose, Acercandose);
        State atacandoState = enemigoFSM.CreateState(estadosEnemigo.Atacando, Atacando);
        #endregion Estados

        #region Transiciones
        enemigoFSM.CreateTransition("El jugador existe", descansandoState, existeJugadorPercepcion, acercandoseState);  //si existe el jugador andar por el mapa
        enemigoFSM.CreateTransition("Enemigo ha localizado al jugador", acercandoseState, haAlcanzadoPercepcion, atacandoState);
        enemigoFSM.CreateTransition("El jugador se ha alejado", atacandoState, noHaAlcanzadoPercepcion, acercandoseState);
        enemigoFSM.CreateTransition("El jugador ya no est� a la vista", atacandoState, noVeJugadorPercepcion, descansandoState);
        #endregion Transiciones
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.estadoJugador != 1)
        {
            return;
        }


        if (GM.modoJuego == -1)
        {
            return;
        }

        if (GM.modoJuego == 1 && GM.ModoHordasDificultad == -1)
        {
            return;
        }
        if (GM.modoJuego == 3)
        {
            return;
        }
        existeJugador = true;

        enemigoFSM.Update();

        actualizarDestino();
        comprobarJugadorVisible();
        comprobarDestino();
        moving();
    }

    private void Descansando()
    {
        //   Debug.Log("Enemigo: Descansado");
        estadoActual = estadosEnemigo.Descansando;

        //Se comprueba constantemente que el jugador sea visisble ( est� cerca). Cuando lo sea, pasr� al estado de Acercandose()
    }

    private void Acercandose()
    {
        // Debug.Log("Enemigo: Acerc�ndose al jugador");
        estadoActual = estadosEnemigo.Acercandose;

        //Va hacia el jugador
        //Se hace con la funci�n moving() que se llama en cada Update
        //El enemigo se mantiene en este estado siempre que el jugador sea visible pero no se le haya alcanzado a�n

    }

    private void Atacando()
    {
        //      Debug.Log("Enemigo: Atacando al jugador");
        estadoActual = estadosEnemigo.Atacando;

        //restar vida al jugador

    }

    void actualizarDestino()
    {
        float PosAnterior = this.transform.position.x;
        destino = new Vector2(jugador.transform.position.x, jugador.transform.position.y);

        if (destino.x > PosAnterior)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    void comprobarDestino()
    {
        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("El enemigo est� a distancia" + distanceTo);    //comprobar que la distancia se est� calculando correctamente
        if (distanceTo <= 1)
        {
         //   haAlcanzado = true;
        }
        else
        {
       //     haAlcanzado = false;
        }
    }

    void comprobarJugadorVisible()
    {
        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("-----El enemigo est� a distancia" + distanceTo);   //comprobar que la distancia se est� calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le ver� y comenzar� a acercarse a �l.
        if (visor.detected == true)
        {
            veJugador = true;
            haAlcanzado = true;
            control.Destino(destino);
         //   control.DestinoActualizado = destino;
            //pasarle al visor la posicion del jugador para que apunte a el y no a los puntos del nav
            
        }
        else
        {
            veJugador = false;
            haAlcanzado = false;
        }

    }


    void moving()
    {
        if (estadoActual == estadosEnemigo.Acercandose)  //El enemigo debe estar en este estado para moverse
        {
            
            control.ReanudarNav();
            /*
            //Va hacia el jugador
            float step = speed * Time.deltaTime;
            //   Debug.Log("step " + step);
            transform.position = Vector2.MoveTowards(transform.position, destino, step);    //MoveTowards(posicion actual, destino, distancia m�xima)
            */
            if (control.destinoAsignado == false)
            {
                int a = Random.RandomRange(0, 4);
                control.Destino(targetPoints[a].position);
            }
           // if(control.destinoAsignado)
        if(control.Hemosllegado() ==true )
           {
               int a = Random.RandomRange(0, 4);
               control.Destino(targetPoints[a].position);
           }
        }

        if(estadoActual == estadosEnemigo.Atacando)
        {
            //Va hacia el jugador
            float step = speed * Time.deltaTime;
            //   Debug.Log("step " + step);
            transform.position = Vector2.MoveTowards(transform.position, destino, step);
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

