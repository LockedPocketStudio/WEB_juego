using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject player;

    public Vector3 posAnterior;
    public float cambio;
    void Start()
    {

        var a = player.transform.position;
        this.transform.position = new Vector3(a.x, a.y, this.transform.position.z);
        posAnterior = a;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var a = player.transform.position;
        float cambiox = a.x - posAnterior.x;
        float cambioy = a.y - posAnterior.y;
      
        if(cambiox>=cambio || cambiox <= -cambio)
        {
            this.transform.position = new Vector3(a.x, a.y, this.transform.position.z);
            posAnterior = this.transform.position;
        }
        else if (cambioy >= cambio || cambioy <= -cambio)
        {
            this.transform.position = new Vector3(a.x, a.y, this.transform.position.z);
            posAnterior = this.transform.position;
        }*/
        
        var a = player.transform.position;
       this.transform.position = new Vector3(a.x, a.y, this.transform.position.z);
    }
}
