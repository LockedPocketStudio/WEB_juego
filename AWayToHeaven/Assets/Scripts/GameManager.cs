using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  
    public int modoJuego; //-1 pausa //0 historia //1 hordas
    public int modoJuegoanteriro;
    public int estadoJugador = 1; //-1-muerto 1-vivo

    public TextMeshProUGUI timer;
    public float time =0f;
    public  int vidasEnemigos = 1;
    int dificultad = 0;  //hordas
    public bool victoria = false;

    GameObject player;
    // public Text timer;

    //Dialogo tutorial
    float tleftModo2 = 0;
    public bool finModo2 = false;
    public bool iniciopelea = false;
    public GameObject EscenaDialogo;
    public GameObject eleccion;
    public AudioSource musica;
    public AudioClip m;
    public AudioClip mExploracion;
    public AudioClip mDialogo;
    //public AudioClip mSelSala;
    bool SeleccionMusica = false;
    bool SeleccionMusica2 = false;
    bool SalaExplorar = false;
    //bool SelSala = false;

    //Control modo hordas
    public int ModoHordasDificultad = -1; //0- facil, 1-medio , 2-dificil 
    public GameObject SeleccionDificultad;
    public Button btnFacil;
    public Button btnMedio;
    public Button btnDificil;

    public GameObject DificultadMedia;
    public GameObject DificultadDificil;


    public int currentScene;


    void Start()
    {
        
        currentScene = SceneManager.GetActiveScene().buildIndex;

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
       

        if(modoJuego == 0)
        {
            string nivel = PlayerPrefs.GetString("selectedLevel");

            if(currentScene == 2)   //Anillo1
            {
                switch(nivel)
                {
                    //Primera fila
                    case "Sala1_1":
                        Debug.Log("SALA 1_ 1");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }
                                            
                    break;

                    case "Sala1_3":
                        Debug.Log("SALA 1_ 3");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }

                    break;

                    case "Sala3_2":
                        Debug.Log("SALA 3_ 2");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }

                    break;

                    case "Sala3_3":
                        Debug.Log("SALA 3_ 3");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }
                                                
                    break;

                    case "Sala4_4":
                        Debug.Log("SALA 4_ 4");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }
                                            
                    break;
                }

            }else if(currentScene == 5) //Anillo2
            {
                switch(nivel)
                {
                    //Primera fila
                    case "Sala1_1":
                        Debug.Log("SALA 1_ 1");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }
                                            
                    break;

                    case "Sala1_3":
                        Debug.Log("SALA 1_ 3");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }

                    break;

                    case "Sala2_1":
                        Debug.Log("SALA 2_ 1");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }

                    break;

                    //Tercera fila
                    case "Sala3_1":
                        Debug.Log("SALA 3_ 1");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }

                    break;

                    case "Sala3_3":
                        Debug.Log("SALA 3_ 3");
                        if(!SalaExplorar)
                        {
                            musica.clip = mExploracion;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SalaExplorar = true;
                        }
                                                
                    break;
   
                }

            }/*else if((currentScene == 3)||(currentScene == 4)){
                        if(!SelSala)
                        {
                            musica.clip = mSelSala;
                            musica.volume = PlayerPrefs.GetFloat("Volumen");
                            musica.Play();
                            SelSala = true;
                        }
            }*/

            
            if (!SeleccionMusica2)
            {
                musica.clip = m;
                musica.volume = PlayerPrefs.GetFloat("Volumen");
                musica.Play();
                SeleccionMusica2 = true;
            }
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
        if(time >= 180 && dificultad == 1 && ModoHordasDificultad>=1)
        {
            vidasEnemigos++;
            dificultad++;

        }
        if (time >= 260 && dificultad == 2 && ModoHordasDificultad==2)
        {
            vidasEnemigos++;
            dificultad++;
        }

        if(time >= 300)
        {
            victoria = true;
             estadoJugador = -1;
        }

        if(modoJuego == 2 && EscenaDialogo.active == false)
        {
            iniciopelea = true;
            eleccion.SetActive(false);
            tleftModo2 += Time.deltaTime;
            if (!SeleccionMusica)
            {
                musica.clip = m;
                musica.Play();
                musica.volume = PlayerPrefs.GetFloat("Volumen");
                SeleccionMusica = true;
            }
           
            if(tleftModo2 >= 15f)
            {
                finModo2 = true;
                EscenaDialogo.SetActive(true);
            }


        }

        if(modoJuego == 3)
        {
            if (!SeleccionMusica)
            {
                musica.clip = mDialogo;
                musica.volume = PlayerPrefs.GetFloat("Volumen");
                musica.Play();
                SeleccionMusica = true;
            }
           
        }
     

    }

    public void PlayerState(int n)
    {
        estadoJugador = n;
    }
}
