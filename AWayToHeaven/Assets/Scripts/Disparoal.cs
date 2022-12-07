using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoal : MonoBehaviour
{
    public int bulletDamage = 1;
    public int bulletHealth = 1;
    private Vector2 destino;
    public GameObject jugador;
    public GameObject bulletPrefab;
    public GameManager GM;

    public float timeShoot =0f;
    
   // VisorEnemigo visor;
   // Escuchar sonido;
    void Start()
    {
        jugador = GameObject.Find("Player");
        GM = GameManager.FindObjectOfType<GameManager>();
      //  visor = this.GetComponent<VisorEnemigo>();
       // sonido = this.GetComponent<Escuchar>();
    }

    // Update is called once per frame
    void Update()
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
        if (GM.modoJuego == 3)
        {
            return;
        }

        float distanceTo = Vector2.Distance(jugador.transform.position, this.transform.position);
        if (timeShoot >=2.5f && distanceTo<=5)
        {
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
            EnemyBullet b = bulletGO.GetComponent<EnemyBullet>();
            b.dir = jugador.transform.position - this.transform.position;
            b.damage = bulletDamage;
            b.health = bulletHealth;

            var a = this.GetComponent<Enemy>();
            a.bala = 0;
            timeShoot = 0;
        }
      timeShoot+=  Time.deltaTime;
        
    }
}
