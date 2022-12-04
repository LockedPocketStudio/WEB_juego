using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        var a = player.transform.position;
        this.transform.position = new Vector3(a.x, a.y, this.transform.position.z);
    }
}
