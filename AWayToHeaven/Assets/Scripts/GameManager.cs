using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public UIManager UI;
    int modoJuego;
   // public Text timer;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        modoJuego = UI.modoJuego;

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
        }
    }
}
