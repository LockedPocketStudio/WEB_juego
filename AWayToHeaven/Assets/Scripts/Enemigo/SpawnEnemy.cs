using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeSpawn = 1;
    public float SpawnRate = 5; //cada 3 segundos spawnea un enemigo
    public Transform xRangeLeft;
    public Transform XRangeRight;
    public Transform yRangeUP;
    public Transform yRangeDown;
    public int especial = 0; // 0= sin enemigos estáticos , 1 =con estaticos 

    //estatico
    private int TiempoCreado;
    private int TiempoMuerto;

    public GameManager GM;
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        if(especial == 0)
        {
            InvokeRepeating("SpawnEnemies", timeSpawn, SpawnRate);
        }
        else
        {
            
               // SpawnEstaticEnemy();
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemies()
    {
        if (GM.estadoJugador != 1)
        {
            return;
        }


        if (GM.modoJuego == -1)
        {
            return;
        }

        if (GM.modoJuego == 1 && GM.ModoHordasDificultad == -1)
        {
            return;
        }

        Vector3 spawnPosition = new Vector3(0, 0, 0);

        //Seleccion Especial
        if(GM.ModoHordasDificultad == 1)
        {
            var num1 = Random.Range(0, 10);
            var num2 = Random.Range(0, 10);
            var num3= Random.Range(0, 10);
            var num4 = Random.Range(0, 10);
            if(num4>num1 && num4>num2 && num4>num3)
            {
                GameObject enemie2 = Instantiate(enemies[2], this.transform.position, gameObject.transform.rotation);
            }
        }
        if (GM.ModoHordasDificultad == 2)
        {
            var num1 = Random.Range(0, 10);
            var num2 = Random.Range(0, 10);
           
            var num4 = Random.Range(0, 10);
            if (num4 > num1 && num4 > num2 )
            {
                GameObject enemie2 = Instantiate(enemies[2], this.transform.position, gameObject.transform.rotation);
            }
        }


        var seleccionEnemigo = Random.Range(0,2);

      //  spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, XRangeRight.position.y), Random.Range(yRangeDown.position.y, yRangeUP.position.y), 0);
        GameObject enemie= Instantiate(enemies[seleccionEnemigo],this.transform.position,gameObject.transform.rotation);
      var a=  enemie.GetComponent<Enemy>();
        a.health = GM.vidasEnemigos;
    }

    public void SpawnEstaticEnemy()
    {
        
        GameObject enemie = Instantiate(enemies[2], this.transform.position, gameObject.transform.rotation);
    }
}
