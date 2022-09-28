using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float posX;
    public float posY;
    public GameObject obj;
    //public GameObject per;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        posX = Input.mousePosition.x;
        posY = Input.mousePosition.y;

        if(posX > 0){
            obj.transform.position = new Vector3(obj.transform.position.x)
        }
        else
        {

        }
        obj.transform.position= new Vector3(posX, posY, 1);

    }
}
