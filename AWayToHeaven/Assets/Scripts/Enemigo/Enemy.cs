using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health ;
    public GameObject ExpPrefab;
    public int bala = 0;
    private bool estatico =false;
    private Animator animacion;
    public GameManager GM;
    bool muerto;
    float tiempoanimacionfinal = 0.3f;
    float tiempogolpe = 0.3f;
    public bool bt;
    public bool fsm;
    bool golpe = false;
    Rigidbody2D rr;
    BoxCollider2D b;
    // Start is called before the first frame update
    void Start()
    {
        animacion = this.GetComponent<Animator>(); 
        GM = GameManager.FindObjectOfType<GameManager>();
        rr = GetComponent<Rigidbody2D>();
        b = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.modoJuego == -1)
        {
            animacion.enabled = false;
            return;
        }
     

        if(GM.estadoJugador == -1)
        {
            animacion.enabled = false;
            return;
        }
           

        if (animacion.enabled == false)
        {
            animacion.enabled = true;
       
        }
        if (muerto )
        {
            if (tiempoanimacionfinal <= 0)
            {
                Destroy(this.gameObject);
            }
            tiempoanimacionfinal -= Time.deltaTime;
        }

        if (golpe)
        {
            if (tiempogolpe <= 0)
            {
                animacion.SetBool("Golpe", false);
                golpe = false;
                tiempogolpe = 0.3f;
            }
            tiempogolpe -= Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;
        animacion.SetBool("Golpe", true);
        golpe = true;
        if (health <= 0)
        {
           
            animacion.SetBool("Muerte", true);
            Destroy(rr);
            Destroy(b);
            if (bt)
            {
                var a = this.GetComponent<Disparoal>();
                var b = this.GetComponent<EnemigoBT>();
                Destroy(a);
                Destroy(b);
            }
            if (fsm)
            {
                var a = this.GetComponent<EnemigoFSM>();
                Destroy(a);
            }
            
            var r = new Quaternion(0,0, 0, 0);
            GameObject EXP = (GameObject)Instantiate(ExpPrefab, this.transform.position,r);
            muerto = true;
          //  if()
            //Destroy(this.gameObject);
            return;
        }
    }

    public void Esestatico(bool a)
    {
        estatico = a;
    }
    
   /* public void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.tag == "PlayerCollider")
        {
           
           Player e = c.gameObject.GetComponent<Player>();
            if (e.InvencibleTimeLeft <= 0)
            {
                e.life--;
                e.InvencibleTimeLeft = e.InvencibleTime;
                Debug.LogWarning("He perdido una vida");
            }
            if (e.life <= 0)
            {
                Destroy(e.gameObject);
            }

        }
       
    }*/
}
