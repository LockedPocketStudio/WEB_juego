using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathSierra : MonoBehaviour
{
    public PathCreator path;
    public float speed = 5;
    float distanceTravelled;
    public  int damage = 1;
    public GameManager GM;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = path.path.GetPointAtDistance(distanceTravelled);
        if (GM.estadoJugador == -1)
        {
            return;
        }
        if (GM.modoJuego == -1)
        {
            return;
        }
        distanceTravelled += speed * Time.deltaTime;
    
    }
    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "Enemy")
        {

            c.gameObject.GetComponent<Enemy>().TakeDamage(damage);
          


        }
    }

    public void Colocar ( int n)
    {
        if(n == 0)
        {
            transform.position = path.path.GetPointAtDistance(0);
           
            distanceTravelled =0f;
        }
        else if (n == 1)
        {
            transform.position = path.path.GetPointAtDistance(14.5f);
            distanceTravelled = 14.5f;
        }
        else if (n == 2)
        {
            transform.position = path.path.GetPointAtDistance(7f);
            distanceTravelled = 7f;
        }
        else if (n == 3)
        {
            transform.position = path.path.GetPointAtDistance(31);
            distanceTravelled = 31;
        }

    }
}
