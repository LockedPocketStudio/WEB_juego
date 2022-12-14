using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoFSM : MonoBehaviour
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

    //Otras variables
    private int health = 1;
    private float speed = 1.5f;
    public GameManager GM;

    private Vector2 destino;    //la posicion del jugador en ese momento


    //Control Sprite
    SpriteRenderer sprite;
    private Vector2 destinoAnterior;

    #endregion variables



    // Start is called before the first frame update
    void Start()
    {
        //Buscar objetos de la escena 
        GM = GameManager.FindObjectOfType<GameManager>();
        jugador = GameObject.Find("Player");

        //Coger sprite
        sprite = this.GetComponent<SpriteRenderer>();


        estadosEnemigo = new EstadosEnemigo();

        enemigoFSM = new StateMachineEngine(); 

        CreateStateMachine();
    }

    private void CreateStateMachine()
    {
        #region Percepciones
        Perception veJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => veJugador);
        Perception noVeJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => !veJugador);

        Perception haAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => haAlcanzado);
        Perception noHaAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => !haAlcanzado);
        #endregion Percepciones

        #region Estados
        State descansandoState = enemigoFSM.CreateEntryState(estadosEnemigo.Descansando, Descansando);
        State acercandoseState = enemigoFSM.CreateState(estadosEnemigo.Acercandose, Acercandose);
        State atacandoState = enemigoFSM.CreateState(estadosEnemigo.Atacando, Atacando);
        #endregion Estados

        #region Transiciones
        enemigoFSM.CreateTransition("El jugador est?? a la vista", descansandoState, veJugadorPercepcion, acercandoseState);
        enemigoFSM.CreateTransition("Enemigo ha alcanzado al jugador", acercandoseState, haAlcanzadoPercepcion, atacandoState);
        enemigoFSM.CreateTransition("El jugador se ha alejado", atacandoState, noHaAlcanzadoPercepcion, acercandoseState);
        enemigoFSM.CreateTransition("El jugador ya no est?? a la vista", atacandoState, noVeJugadorPercepcion, descansandoState);
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

        if (GM.modoJuego == 1 && GM.ModoHordasDificultad == -1)
        {
            return;
        }
        if (GM.modoJuego == 3)
        {
            return;
        }
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

        //Se comprueba constantemente que el jugador sea visisble ( est?? cerca). Cuando lo sea, pasr?? al estado de Acercandose()
    }
    
    private void Acercandose()
    {
       // Debug.Log("Enemigo: Acerc??ndose al jugador");
        estadoActual = estadosEnemigo.Acercandose;

        //Va hacia el jugador
        //Se hace con la funci??n moving() que se llama en cada Update
        //El enemigo se mantiene en este estado siempre que el jugador sea visible pero no se le haya alcanzado a??n

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

        if(destino.x >PosAnterior)
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
        //Debug.Log("El enemigo est?? a distancia" + distanceTo);    //comprobar que la distancia se est?? calculando correctamente
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
        //Debug.Log("-----El enemigo est?? a distancia" + distanceTo);   //comprobar que la distancia se est?? calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le ver?? y comenzar?? a acercarse a ??l.
        if(distanceTo <= 5){
            veJugador = true;
        }
        else
        {
            veJugador = false;
        }

    }

    void moving()
    {
        if(estadoActual == estadosEnemigo.Acercandose)  //El enemigo debe estar en este estado para moverse
        {
                //Va hacia el jugador
            float step = speed * Time.deltaTime;
         //   Debug.Log("step " + step);
            transform.position = Vector2.MoveTowards(transform.position, destino, step);    //MoveTowards(posicion actual, destino, distancia m??xima)
        }
    }

  
}
