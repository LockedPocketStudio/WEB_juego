using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteligente : MonoBehaviour
{
    [Range(0f, 360f)]
    public float visionAngle = 90f;
    public float visionDistance = 2f;
    public float DistanciaAlerta = 14f;
    public Transform head;
    public Vector2 Distancia;
    bool enemigoasignado = false;
    GameObject enemigoAsignado;

   public float tiempo = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigoasignado == false) { 
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemigos.Length; i++)
        {
            
            Vector2 playerVector = enemigos[i].transform.position - head.transform.position;
            if (Vector3.Angle(playerVector.normalized, head.right) < visionAngle * 0.5f)
            {
                if (playerVector.magnitude < visionDistance)
                {
                    Desmontar(enemigos[i]);
                }
            }
        
        }
        }
        else
        {
            Desmontar(enemigoAsignado);
        }
    }


    public void OnDrawGizmos()
    {
        //  if (visionAngle <= 0f) return;


        float halfVision = visionAngle * 0.5f;

        Vector2 p1, p2;
        p1 = PointForAngle(halfVision, visionDistance);
        p2 = PointForAngle(-halfVision, visionDistance);
       
          
            Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
            Gizmos.DrawLine(head.position, (Vector2)head.position + p2);
            Gizmos.DrawWireSphere(head.position, 10); 
            Gizmos.DrawRay(head.position, head.right * 4f);
        
    

    }
    public Vector3 PointForAngle(float angle, float distance)
    {
        // Vector2 ret = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * visionDistance, Mathf.Sin(angle * Mathf.Deg2Rad) * visionDistance);

        return head.TransformDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance);

    }

   public void Desmontar(GameObject enemigo)
    {
       ControlNavMesh ene = enemigo.GetComponent<ControlNavMesh>();
        VisorEnemigo a = ene.GetComponent<VisorEnemigo>();
        Escuchar b = ene.GetComponent<Escuchar>();

        if(a.detected || b.detected || ene.alertado)
        {
            return;
        }
        else
        {
            enemigoAsignado = enemigo;
            enemigoasignado = true;

           ene.Destino(this.transform.position);
            if (Mathf.Abs(enemigo.transform.position.x - this.transform.position.x) < 0.7f && Mathf.Abs(enemigo.transform.position.y - this.transform.position.y) < 0.7f)
            {
                ene.DetenerNav();
                if (tiempo <= 0)
                {
                    ene.ReanudarNav();
                    Destroy(this.gameObject);
                }
                tiempo -= Time.deltaTime;
            }
        }
    }
}
