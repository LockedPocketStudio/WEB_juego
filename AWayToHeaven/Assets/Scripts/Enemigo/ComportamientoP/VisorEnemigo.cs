using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorEnemigo : MonoBehaviour
{
    [Range (0f,360f)]
    public float visionAngle = 90f;
    public float visionDistance = 2f;
    public Transform head;
    public float anterior;
    public float anteriorX;
    public bool subiendo = false;
    public bool bajando = false;
    public float rotacionz;

   public Vector3 DireccionMira;
    float incrementoY = 40f;
    float incrementoX = 40f;

    public ControlNavMesh nav;
    public Transform player;
    public bool detected = false;

    //Tipo de enemigo //Cada uno tiene un cono de visión diferente
    public bool EFSM;
    public bool EBT;
    public bool EEs;
    void Awake()
    {
        detected = false;
        if (!EEs)
        {
            nav = this.GetComponent<ControlNavMesh>();
        }
      

        DireccionMira = new Vector3(0, 0, 0); //Como se encuentra el objeto en un principio

       // DireccionMira = head.localRotation.z;
        anterior = head.position.y;
        anteriorX = head.position.x;

        
    }

    // Update is called once per frame
    void Update()
    {
        /// if(anterior != head.position.y)
        //{
        if (!EEs)
        {
            Vector3 relativePos = new Vector3(nav.DestinoActualizado.x, nav.DestinoActualizado.y, 0) - transform.position;
            Vector3 rotateTarget = Quaternion.Euler(0, 0, 90) * relativePos;


            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotateTarget);
            // Quaternion rotf = new Quaternion(0, 0, rotation.z, 0);
            head.rotation = Quaternion.RotateTowards(head.transform.rotation, rotation, 120 * Time.deltaTime);


        }
         //   Vector3 relativePos = new Vector3(nav.DestinoActualizado.x,nav.DestinoActualizado.y,0) - transform.position;
           // Vector3 rotateTarget = Quaternion.Euler(0, 0, 90) * relativePos;
           // Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotateTarget);
           // head.rotation = Quaternion.RotateTowards(head.transform.rotation,rotation, 120 * Time.deltaTime);




        //  head.transform.Translate(Vector3.right * 5 * Time.deltaTime, Space.Self);
        /*
          var a = new Quaternion(0, 0, 9, 0);
          if (DireccionMira.z < 90f)
          {
                      head.Rotate(new Vector3(0,0, incrementoY) * Time.deltaTime);
              DireccionMira += (new Vector3(0, 0, incrementoY) * Time.deltaTime);
          }

          subiendo = true;
          bajando = false;
          anterior = head.position.y;*/
        //    }/*
        /*    else if (anterior  > head.position.y)
            {
               // var b = head.transform.rotation.eulerAngles;
                // var a=  new Quaternion(0, 0, 9, 0);
                //DireccionMira += new Vector3(0, 0, -0.2f);
                if (DireccionMira.z > -90)
                {
                    // head.transform.rotation = head.transform.rotation * Quaternion.Inverse(Quaternion.Euler(0, 0, 0.1f));
                    //head.transform.rotation.SetLookRotation(DireccionMira);

                    head.Rotate(new Vector3(0, 0, -incrementoY) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, -incrementoY) * Time.deltaTime);
                }


                subiendo = false;
                bajando = true;
                anterior = head.position.y;
            }
            //rotacionz = head.rotation.z;

            if(anteriorX < head.position.x) //derecha
            {

                if(subiendo && DireccionMira.z>= 45f)
                {
                    head.Rotate(new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                }
                else if(subiendo && DireccionMira.z < 45f)
                {
                    head.Rotate(new Vector3(0, 0, incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, incrementoX) * Time.deltaTime);
                }else if(bajando && DireccionMira.z>= -45f)
                {
                    head.Rotate(new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                }else if(bajando && DireccionMira.z < -45f)
                {
                    head.Rotate(new Vector3(0, 0, incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, incrementoX) * Time.deltaTime);
                }

            }else if(anteriorX> head.position.x)
            {
                if (subiendo && DireccionMira.z < 135f)
                {
                    head.Rotate(new Vector3(0, 0, incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, incrementoX) * Time.deltaTime);
                }
                else if(subiendo && DireccionMira.z >= 135f)
                {
                    head.Rotate(new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                }
                else if(bajando && DireccionMira.z >= 225)
                {
                    head.Rotate(new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, -incrementoX) * Time.deltaTime);
                }

                else if(bajando && DireccionMira.z < 225) {
                    head.Rotate(new Vector3(0, 0, incrementoX) * Time.deltaTime);
                    DireccionMira += (new Vector3(0, 0, incrementoX) * Time.deltaTime);
                }
            }
            */


        Vector2 playerVector = player.position - head.transform.position;
       if(Vector3.Angle(playerVector.normalized,head.right) < visionAngle * 0.5f)
        {
            if(playerVector.magnitude < visionDistance)
            {
                detected = true;
            }
            else
            {
                detected = false;
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
        if (EFSM || EBT)
        {
            Gizmos.color = detected ? Color.red : Color.green;
            Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
            Gizmos.DrawLine(head.position, (Vector2)head.position + p2);
            // Gizmos.DrawWireSphere(head.position, 4);detectar sonido tambien 
            Gizmos.DrawRay(head.position, head.right * 4f);
        }
        if (EEs)
        {
            Gizmos.color = detected ? Color.red : Color.green;
            Gizmos.DrawLine(head.position, (Vector2)head.position + p1);
            Gizmos.DrawLine(head.position, (Vector2)head.position + p2);
            float radio = Vector2.Distance(head.position, (Vector2)head.position + p1);
             Gizmos.DrawWireSphere(head.position, radio);
        }

    }

    public Vector3 PointForAngle(float angle, float distance)
    {
       // Vector2 ret = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * visionDistance, Mathf.Sin(angle * Mathf.Deg2Rad) * visionDistance);

        return head.TransformDirection(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance);
    
    }

    public bool ChequearObstaculo()
    {
        bool res = false;
        Vector3 origenRayo = new Vector3(head.transform.position.x, head.transform.position.y+1, head.transform.position.z);
        Vector3 DireccionRayo = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        DireccionRayo -= origenRayo;
        Ray ray = new Ray(origenRayo, DireccionRayo);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {

            if(hit.collider !=null && hit.collider.tag.Equals("Player"))
            {
                res = true;
            }

        }
        return res;
    }
}
