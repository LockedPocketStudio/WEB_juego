using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elementos : MonoBehaviour
{
    public bool fuego;
    public bool agua;
    public bool aire;
    public bool roca;
    bool primera = false;
    SpriteRenderer sprite;
    NavMeshAgent nav;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = new Color(255, 255, 255, 255);
        nav.speed = 3.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "lava")
        {

            if (!fuego) 
            {
                Color fuegoC = new Color(255, 0, 0, 255);
                sprite.color = fuegoC;
                nav.speed = 2f;
            }
        }
        else if(collision.gameObject.tag == "Agua")
        {
            if (!agua)
            {
                Color aguaC = new Color(0, 0, 255, 255);
                sprite.color = aguaC;
                nav.speed = 2f;
            }
        }
        else if(collision.gameObject.tag == "Roca")
        {
            if (!roca)
            {
               
                    Color rocaC = new Color(0, 31, 27, 0.2f);
                    sprite.color = rocaC;

                nav.speed = 2f;






            }
        }
        else if (collision.gameObject.tag == "Aire")
        {
            if (!aire)
            {
                Color aireC = new Color(0, 255, 0, 255);
                sprite.color = aireC;
                nav.speed = 2f;
            }
        }
     
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lava")
        {

            if (!fuego)
            {
                Color fuegoC = new Color(255, 0, 0, 255);
                sprite.color = fuegoC;
                nav.speed = 2f;
            }
        }
        else if (collision.gameObject.tag == "Agua")
        {
            if (!agua)
            {
                Color aguaC = new Color(0, 0, 255, 255);
                sprite.color = aguaC;
                nav.speed = 2f;
            }
        }
        else if (collision.gameObject.tag == "Roca")
        {
            if (!roca)
            {

                Color rocaC = new Color(0, 31, 27, 0.2f);
                sprite.color = rocaC;


                nav.speed = 2f;





            }
        }
        else if (collision.gameObject.tag == "Aire")
        {
            if (!aire)
            {
                Color aireC = new Color(0, 255, 0, 255);
                sprite.color = aireC;
                nav.speed = 2f;
            }
        }
       
    }
}
