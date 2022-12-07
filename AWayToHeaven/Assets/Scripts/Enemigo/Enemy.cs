using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public GameObject ExpPrefab;
    public int bala = 0;
    private bool estatico =false;
    private Animator animacion;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        animacion = this.GetComponent<Animator>(); 
        GM = GameManager.FindObjectOfType<GameManager>();
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
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;
        if (health <= 0)
        {
            var r = new Quaternion(0,0, 0, 0);
            GameObject EXP = (GameObject)Instantiate(ExpPrefab, this.transform.position,r);
            Destroy(this.gameObject);
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
