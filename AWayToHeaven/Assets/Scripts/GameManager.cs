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

    float tleftModo2 = 0;
    public bool finModo2 = false;

    public GameObject EscenaDialogo;

    void Start()
    {
       // player = FindObjectOfType("Player");
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
        else if(modoJuego == 1)
        {
            //Comenzamos modo hordas
            if(estadoJugador  != -1)
            {
                time += Time.deltaTime;
                string t = time.ToString("F2");
                timer.text = t;
                

            }
            

        }

        if(time >= 180 && dificultad==0){
            vidasEnemigos++;
            dificultad++;

        }
        if(time >= 240 && dificultad == 1)
        {
            vidasEnemigos++;
            dificultad++;

        }
        if (time >= 300 && dificultad == 2)
        {
            vidasEnemigos++;
            dificultad++;

        }

        if(modoJuego == 2 && EscenaDialogo.active == false)
        {
            tleftModo2 += Time.deltaTime;

            if(tleftModo2 >= 25f)
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
