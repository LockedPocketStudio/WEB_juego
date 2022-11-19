using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
   private Vector3 Playerpos;
    public GameObject player;
    public GameManager GM;
    protected AudioSource musica;
    
    void Start()
    {
        Playerpos = player.transform.position;
        this.transform.position = Playerpos;
        musica = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Playerpos = player.transform.position;
        this.transform.position = Playerpos;
    }
    public void TakeDamage()
    {
        Player e = player.GetComponent<Player>();
        if (e.InvencibleTimeLeft <= 0)
        {
            e.VidaActual--;
            e.InvencibleTimeLeft = e.InvencibleTime;

            Debug.LogWarning("He perdido una vida");
        }
        if (e.VidaActual <= 0)
        {
            e.BarraVida.fillAmount = 0;
            Destroy(e);

            GM.PlayerState(-1);
            Destroy(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "Enemy" || c.gameObject.tag =="BulletEnemy")
        {

            Player e = player.GetComponent<Player>();
            if (e.InvencibleTimeLeft <= 0)
            {
                musica.Play();
                e.VidaActual--;
                e.InvencibleTimeLeft = e.InvencibleTime;
                
                Debug.LogWarning("He perdido una vida");
            }
            if (e.VidaActual <= 0)
            {
                e.BarraVida.fillAmount = 0;
                Destroy(e);
               
                GM.PlayerState(-1);
                Destroy(this);
            }

        }
        if (c.gameObject.tag == "Experiencia")
        {
             Player e = player.GetComponent<Player>();
            GameObject exp = c.gameObject;
            Player.experiencia++;
           
            Destroy(exp);
        }

    }
}
