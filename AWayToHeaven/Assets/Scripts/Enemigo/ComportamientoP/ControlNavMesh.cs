using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlNavMesh : MonoBehaviour
{

    private NavMeshAgent navMesh;
    public bool destinoAsignado=false;
    public VisorEnemigo head;

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
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destino(Vector2 destino) //para los puntos donde tieen que buscar el camino
    {
       
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
        return navMesh.remainingDistance <= navMesh.stoppingDistance && !navMesh.pathPending;
    }



}
