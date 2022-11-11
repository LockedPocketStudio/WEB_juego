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
   // public Text timer;
   
    void Start()
    {

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
            //Comenzamos modo historia
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


    }

    public void PlayerState(int n)
    {
        estadoJugador = n;
    }
}
