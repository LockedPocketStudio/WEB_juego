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
}
