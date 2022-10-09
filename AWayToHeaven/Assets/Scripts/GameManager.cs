using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public int modoJuego; //-1 pausa //0 historia //1 hordas
    public int estadoJugador = 1; //-1-muerto 1-vivo
    public TextMesh timer;
    public float time =0f;

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
            time += Time.deltaTime;
            string t = time.ToString("F2");
            timer.text = t;

        }
    }

    public void PlayerState(int n)
    {
        estadoJugador = n;
    }
}
