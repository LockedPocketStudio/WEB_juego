using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
   private Vector3 Playerpos;
    public GameObject player;
    public GameManager GM;
    protected AudioSource musica;
    //Historia
    public GameObject Dialogo;
    Historia historia;
    static bool d1 = false;
    static bool d2 = false;
    static bool dop1 = false;
    static bool dop2 = false;
    static bool dop3 = false;

    static bool s1 = false;
    static bool s2 = false;

    static bool dop4 = false;
    static bool dop5 = false;
    static bool dop6 = false;

    static bool final = false;
    void Start()
    {
        Playerpos = player.transform.position;
        this.transform.position = Playerpos;
        musica = this.GetComponent<AudioSource>();
        if(Dialogo!=null)
        historia = Dialogo.GetComponent<Historia>();
        
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
            //Meter aqui animcaion de muerte
            GM.modoJuego = -1;

            GM.PlayerState(-1);
            Destroy(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "Enemy" || c.gameObject.tag =="BulletEnemy" ||c.gameObject.tag=="Lava")
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
            if(GM.modoJuego==0)
            PlayerPrefs.SetInt("exp", Player.experiencia);

            Destroy(exp);
        }
        if (c.gameObject.tag == "Llave")
        {
            Player e = player.GetComponent<Player>();
            GameObject Lave = c.gameObject;
            e.PasarSala = true;
            

            Destroy(Lave);
        }
        if (c.gameObject.tag == "D1")
        {
            //Dialogo 2
            if (d1 == false)
            {
                PlayerPrefs.SetInt("exp", 0);
                GM.modoJuego = 3;
                historia.IniciarD1 = true;
                d1 = true;
                historia.t.text = historia.s1;
                historia.imagen.sprite = historia.elias;
                 
                    PlayerPrefs.SetInt("vel",0);
               
                    PlayerPrefs.SetInt("dob", 0);
              
                    PlayerPrefs.SetInt("li", 0);
               
                
                    PlayerPrefs.SetInt("sierra",0);
               
                    PlayerPrefs.SetInt("daño", 0);
               
                
            }


        }
        if (c.gameObject.tag == "D3.3")
        {
            //Dialogo 2
            if (d2 == false)
            {
                GM.modoJuego = 3;
                historia.IniDialogo2 = true;
                d2 = true;
                historia.t.text = historia.x1;
                historia.imagen.sprite = historia.canv;
            }
          

        }
        if (c.gameObject.tag == "D4.4")
        {
            //Dialogo opcional1
            if (dop1 == false)
            {
                GM.modoJuego = 3;
                historia.inicio4_4 = true;
                dop1 = true;
                historia.t.text = historia.v1;
                historia.imagen.sprite = historia.canv;
            }


        }
        if (c.gameObject.tag == "D3.2")
        {
            //Dialogo opcional2
            if (dop2 == false)
            {
                GM.modoJuego = 3;
                historia.IniOp2 = true;
                dop2 = true;
                historia.t.text = historia.g1;
                historia.imagen.sprite = historia.elias;
            }


        }

        if (c.gameObject.tag == "D1.3")
        {
            //Dialogo opcional2
            if (dop3 == false)
            {
                GM.modoJuego = 3;
                historia.Op3= true;
                dop3 = true;
                historia.t.text = historia.k1;
                historia.imagen.sprite = historia.elias;
            }


        }
        if (c.gameObject.tag == "S1")
        {
            //Dialogo opcional2
            if (s1 == false)
            {
                GM.modoJuego = 3;
                historia.D3 = true;
                s1 = true;
                historia.t.text = historia.i1;
                historia.imagen.sprite = historia.canv;
            }


        }
        if (c.gameObject.tag == "S2")
        {
            //Dialogo opcional2
            if (s2 == false)
            {
                GM.modoJuego = 3;
                historia.D4 = true;
                s2 = true;
                historia.t.text = historia.m1;
                historia.imagen.sprite = historia.canv;
            }


        }
        if (c.gameObject.tag == "OP4")
        {
            //Dialogo opcional2
            if (dop4 == false)
            {
                GM.modoJuego = 3;
                historia.OP4 = true;
                dop4 = true;
                historia.t.text = historia.p1;
                historia.imagen.sprite = historia.canv;
            }


        }
        if (c.gameObject.tag == "OP6")
        {
            //Dialogo opcional2
            if (dop6 == false)
            {
                GM.modoJuego = 3;
                historia.OP6 = true;
                dop6 = true;
                historia.t.text = historia.z1;
                historia.imagen.sprite = historia.elias;
            }


        }
        if (c.gameObject.tag == "OP5")
        {
            //Dialogo opcional2
            if (dop5 == false)
            {
                GM.modoJuego = 3;
                historia.OP5 = true;
                dop5 = true;
                historia.t.text = historia.r1;
                historia.imagen.sprite = historia.canv;
            }


        }

        if (c.gameObject.tag == "final")
        {
            //Dialogo opcional2
            if (final == false)
            {
                GM.modoJuego = 3;
                historia.FIN = true;
                final = true;
                historia.t.text = historia.a1;
                historia.imagen.sprite = historia.anom;
                historia.nombre.text = "??";
            }


        }
    }
}
