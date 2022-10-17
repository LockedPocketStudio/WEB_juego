using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeSpawn = 1;
    public float SpawnRate = 1; //cada 3 segundos spawnea un enemigo
    public Transform xRangeLeft;
    public Transform XRangeRight;
    public Transform yRangeUP;
    public Transform yRangeDown;

    public GameManager GM;
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        InvokeRepeating("SpawnEnemies",timeSpawn, SpawnRate);
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
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        int seleccionEnemigo = Range(0, 1);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, XRangeRight.position.y), Random.Range(yRangeDown.position.y, yRangeUP.position.y), 0);
        GameObject enemie= Instantiate(enemies[0],spawnPosition,gameObject.transform.rotation);
    
    }
}
