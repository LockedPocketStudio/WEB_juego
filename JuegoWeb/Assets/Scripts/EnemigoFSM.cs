using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoFSM : MonoBehaviour
{
    #region variables
    [Header("Objetivos")]
    public GameObject jugador;

    private NavMeshAgent meshAgent;

    //Maquina de estados
    private StateMachineEngine enemigoFSM;

    //Estados
    private EstadosEnemigo estadosEnemigo;

    [Header("Variables de control")]
    [SerializeField] private string estadoActual;

    //Percepciones
    public bool veJugador = false;
    public bool haAlcanzado;

    private Vector3 posicionJugador;    //la posicion del jugador en ese momento

    //Otras variables
    private int vidaActual;
    #endregion variables


    // Start is called before the first frame update
    void Start()
    {
        estadosEnemigo = new EstadosEnemigo();

        enemigoFSM = new StateMachineEngine(false); //Si no funciona revisar este false !!!!!!!!!!!!!!

        meshAgent = GetComponent<NavMeshAgent>();

        //implementar cuando este el jugador
        //posicionJugador = new Vector3(casa.transform.position.x, transform.position.y, casa.transform.position.z);

        CreateStateMachine();
        
    }

    private void CreateStateMachine()
    {
        #region Percepciones
        Perception veJugadorPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => veJugador);
        Perception noVeJugadorPerception = enemigoFSM.CreatePerception<ValuePerception>(() => !veJugador);

        Perception haAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => haAlcanzado);
        Perception noHaAlcanzadoPercepcion = enemigoFSM.CreatePerception<ValuePerception>(() => !haAlcanzado);
        #endregion Percepciones

        #region Estados
        State descansandoState = enemigoFSM.CreateEntryState(estadosEnemigo.Descansando, Descansando);
        State acercandoseState = enemigoFSM.CreateState(estadosEnemigo.Acercandose, Acercandose);
        State atacandoState = enemigoFSM.CreateState(estadosEnemigo.Atacando, Atacando);
        #endregion Estados

        #region Transiciones
        enemigoFSM.CreateTransition("El jugador está a la vista", descansandoState, veJugadorPercepcion, acercandoseState);
        enemigoFSM.CreateTransition("Enemigo ha alcanzado al jugador", acercandoseState, haAlcanzadoPercepcion, atacandoState);
        enemigoFSM.CreateTransition("El jugador se ha alejado", atacandoState, noHaAlcanzadoPerception, acercandoseState);
        enemigoFSM.CreateTransition("El jugador ya no está a la vista", atacandoState, noVeJugadorPerception, descansandoState);
        #endregion Transiciones
    }

    // Update is called once per frame
    void Update()
    {

        enemigoFSM.Update();

        comprobarDestino();
        
    }
}
