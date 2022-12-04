using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionExpp : MonoBehaviour
{
    GameManager GM;
    private Animator animacion;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        animacion = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.modoJuego == -1)
        {
            animacion.enabled = false;
            return;
        }


        if (GM.estadoJugador == -1)
        {
            animacion.enabled = false;
            return;
        }


        if (animacion.enabled == false)
        {
            animacion.enabled = true;

        }
    }
}
