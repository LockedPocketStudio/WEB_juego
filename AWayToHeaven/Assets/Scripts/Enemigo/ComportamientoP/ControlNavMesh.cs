using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlNavMesh : MonoBehaviour
{

    private NavMeshAgent navMesh;
    public bool destinoAsignado=false;
    public VisorEnemigo head;
    public float DistanciaEscuchar;
    public bool alertado = false;
    public GameObject alerta;
    public bool hemosllegado;
    public float b;

    [HideInInspector]
    public Transform perseguir; //a donde queremos que vaya el enemigo

    public Vector2 DestinoActualizado;

    private void Awake()
    {
        navMesh = this.GetComponent<NavMeshAgent>();
        head = this.GetComponent<VisorEnemigo>();
    }
    void Start()
    {
        alerta.SetActive(false);
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destino(Vector2 destino) //para los puntos donde tieen que buscar el camino
    {
        if (alertado == true)
        {
            alerta.SetActive(true);
        }
        destinoAsignado = true;
        navMesh.destination = destino;
        navMesh.isStopped = false;
        DestinoActualizado = destino;
    }

    public void Destino() //para el jugador 
    {
        Destino(perseguir.position);
    }
    public void DetenerNav()
    {
        navMesh.isStopped = true;
    }
    public void ReanudarNav()
    {
        navMesh.isStopped = false;
    }

    public bool Hemosllegado()
    {
        bool hemosllegado = false;
        b = Vector3.Distance(navMesh.destination, this.transform.position);
        if (b < 0.7f)
            hemosllegado = true;
          ///  bool a = navMesh.remainingDistance <= navMesh.stoppingDistance && !navMesh.pathPending;
        if ( hemosllegado && alertado)
        {
            alertado = false;
            alerta.SetActive(false);
        }

        return hemosllegado;//navMesh.remainingDistance <= navMesh.stoppingDistance && !navMesh.pathPending;
    }



}
