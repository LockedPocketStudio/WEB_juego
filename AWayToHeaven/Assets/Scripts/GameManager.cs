using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    public int modoJuego; //-1 pausa //0 historia //1 hordas
    public int estadoJugador = 1; //-1-muerto 1-vivo

    public TextMeshProUGUI timer;
    public float time =0f;
    public  int vidasEnemigos = 1;
    int dificultad = 0;

    GameObject player;
    // public Text timer;

    //Dialogo tutorial
    float tleftModo2 = 0;
    public bool finModo2 = false;
    public GameObject EscenaDialogo;
    public GameObject eleccion;
    public AudioSource musica;
    public AudioClip m;
    bool SeleccionMusica = false;

    //Control modo hordas
    public int ModoHordasDificultad = -1; //0- facil, 1-medio , 2-dificil 
    public GameObject SeleccionDificultad;
    public Button btnFacil;
    public Button btnMedio;
    public Button btnDificil;

    public GameObject DificultadMedia;
    public GameObject DificultadDificil;


    void Start()
    {
        // player = FindObjectOfType("Player");

        if (modoJuego == 1) //hordas
        {
            btnFacil.onClick.AddListener(() => { ModoHordasDificultad = 0; SeleccionDificultad.SetActive(false); });
            btnMedio.onClick.AddListener(() => { ModoHordasDificultad = 1; SeleccionDificultad.SetActive(false); });
            btnDificil.onClick.AddListener(() => { ModoHordasDificultad = 2; SeleccionDificultad.SetActive(false); });
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  modoJuego = UI.modoJuego;

        if(modoJuego == -1)
        {
            return;
        }

        else if(modoJuego == 0)
        {
         
            timer.text = "Nivel : "+ Player.nivelHistoria;

        }
        else if(modoJuego == 1 && ModoHordasDificultad != -1)
        {
            //Comenzamos modo hordas
            if(estadoJugador  != -1)
            {
                time += Time.deltaTime;
                string t = time.ToString("F2");
                timer.text = t;
                

            }
            

        }
        if(modoJuego == 1)
        {
            if (ModoHordasDificultad == 0)
            {
                DificultadMedia.SetActive(false);
                DificultadDificil.SetActive(false);
            }
            else if(ModoHordasDificultad ==1)
            {
                DificultadMedia.SetActive(true);
                DificultadDificil.SetActive(false);
            }
            else if (ModoHordasDificultad == 2)
            {
                DificultadMedia.SetActive(true);
                DificultadDificil.SetActive(true);
            }
        }
        

        if(time >= 60 && dificultad==0){
            vidasEnemigos++;
            dificultad++;

        }
        if(time >= 180 && dificultad == 1)
        {
            vidasEnemigos++;
            dificultad++;

        }
        if (time >= 260 && dificultad == 2)
        {
            vidasEnemigos++;
            dificultad++;
        }

        if(time >= 300)
        {
            //Fin del juego
        }

        if(modoJuego == 2 && EscenaDialogo.active == false)
        {
            eleccion.SetActive(false);
            tleftModo2 += Time.deltaTime;
            if (!SeleccionMusica)
            {
                musica.clip = m;
                musica.Play();
                musica.volume = 0.3f;
                SeleccionMusica = true;
            }
           
            if(tleftModo2 >= 15f)
            {
                finModo2 = true;
                EscenaDialogo.SetActive(true);
            }


        }

    }

    public void PlayerState(int n)
    {
        estadoJugador = n;
    }
}
