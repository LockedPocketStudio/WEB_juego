using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escuchar : MonoBehaviour
{
    [Range(0f, 360f)]
    public float visionAngle = 90f;
    public float visionDistance = 2f;
    public float DistanciaAlerta = 14f;
    public Transform head;
   public Vector2 Distancia;
    public ControlNavMesh nav;

    public Transform player;
    public GameObject jugador;
    movement movimientoJugador; 

    VisorEnemigo visor;
   public bool detected = false;
    //Tipo de enemigo //Cada uno tiene un cono de visión diferente
    public bool EFSM;
    public bool EBT;
    public bool EEs;


    void Start()
    {
        visor = this.GetComponent<VisorEnemigo>();
        nav = this.GetComponent<ControlNavMesh>();
        jugador = GameObject.Find("Player");
        movimientoJugador = jugador.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVector = player.position - head.transform.position;
        if (Vector3.Angle(playerVector.normalized, head.right) < visionAngle * 0.5f)
        {
            if (EBT) { 
            if (playerVector.magnitude < visionDistance )
            {
              detected = true;
                    AlertarEnemigos();
            }
            else
            {
              detected = false;
            }
            }
            else
            {
                if (playerVector.magnitude < visionDistance && movimientoJugador.hacerRuido)
                {
                    detected = true;
                    AlertarEnemigos();
                }
                else
                {
                    detected = false;
                }

            }
        }
        else
        {
            detected = false;
        }
    }

    public void OnDrawGizmos()
    {
        //  if (visionAngle <= 0f) return;


        float halfVision = visionAngle * 0.5f;

        Vector2 p1, p2;
        p1 = PointForAngle(halfVision, visionDistance);
        p2 = PointForAngle(-halfVision, visionDistance);
        if (EFSM )
        {
           Distancia = (((Vector2)head.position + p1) -(Vector2) head.position);
            if(nav!=null)
            nav.DistanciaEscuchar = Distancia.magnitude;
            DistanciaAlerta = Distancia.magnitude + 4;
        Gizmos.color = detected ? Color.red : Color.blue;
            Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
            Gizmos.DrawLine(head.position, (Vector2)head.position + p2);
            Gizmos.DrawWireSphere(head.position, 4);
            //Gizmos.DrawRay(head.position, head.right * 4f);
        }
        if(EBT)
        { // Los murcielagos ven menos pero tienen mejor oido 
            Gizmos.color = detected ? Color.red : Color.blue;
            Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
            Gizmos.DrawLine(head.position, (Vector2)head.position + p2);
            Gizmos.DrawWireSphere(head.position, 7);

             Distancia = (((Vector2)head.position + p1) - (Vector2)head.position);
            if (nav != null)
                nav.DistanciaEscuchar = Distancia.magnitude;
        }
       

    }

    public Vector3 PointForAngle(float angle, float distance)
    {
        // Vector2 ret = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * visionDistance, Mathf.Sin(angle * Mathf.Deg2Rad) * visionDistance);

        return head.TransformDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance);

    }

    public void AlertarEnemigos()
    {
       ControlNavMesh[] enemigos = FindObjectsOfType<ControlNavMesh>();
    
        for(int i=0;i< enemigos.Length; i++)
        {
            Vector2 distancia = head.transform.position - enemigos[i].head.transform.position;
            float Distanciaf = Distancia.magnitude + enemigos[i].DistanciaEscuchar;
            if (distancia.magnitude < DistanciaAlerta && this.transform != enemigos[i].transform)
            {
                enemigos[i].Destino(player.position);
                enemigos[i].alertado = true;
            }
        }
    }
}
