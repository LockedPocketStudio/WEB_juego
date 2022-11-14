using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoTutorial : MonoBehaviour
{
    public GameObject EscenaDialogo;
    public GameManager GM;
    List<string> Dialogo;

    
    public TMP_Text t;
    string a ="¿Hola? , bueno , veo que no sabes muy bien que hacer. Ya que estoy dejame contarte unas cuantas de cosas";
    string a2 = "En cuanto a la navegacion entre modos : El modo hordas consiste en sobrevivir 5 minutos, existen 3 niveles de dificultad. Te animo a probarlo";
    string a3 = "En cambio en el modo historia te contare el como he acabado aqui. Seguro que tienes ganas de saberlo";
    string a4 = "Ahora voy a hablarte de como moverte por este mundo";
    string a5 = "Puedes moverte tocando hacia donde quieres ir y no te preocupes ya que puedes disparar de manera automática";
    string s1 = " Como puedes ver existen diferentes tipos de enemigos, aqui te presento a estos 3 : al esqueleto , murcielago y la torre";
    string s2 = "En el modo historia existirán salas en las cuales tienes que acabar con todos estos enemigos o huir encontrando una puerta";
    string s3 = "Tambien como ves arriba a la izquierda esa es tu barra de estado. La barra de arriba muestra tu vida y la de abajo la experiencia que vayas acumulando";
    string s4 = "Cuando tu barra de experiencia se llene , en el modo hordas obtendras un power up de manera automatica pero en el modo historia necesitas acercarte a un cofre para obtenerlo";
    string s5 = "Con todo esto dicho te dejo que lo pruebes tu mismo, ¡Ánimo!";

    public float tText = 0.15f;
    public float tLeft = 0;
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        Dialogo = new List<string>();
       // Dialogo.Add(a);
        Dialogo.Add(a2);
        Dialogo.Add(a3);
        Dialogo.Add(a4);
        Dialogo.Add(a5);
        Dialogo.Add(s1);
        Dialogo.Add(s2);
        Dialogo.Add(s3);
        Dialogo.Add(s4);
        Dialogo.Add(s5);

        t.text = a;

    }

    // Update is called once per frame
    void Update()
    {
        PresentarTexto();
    }

    public void PresentarTexto()
    {
       

        if(tLeft > tText)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                if (Dialogo.Count == 0)
                {
                    EscenaDialogo.SetActive(false);
                    GM.modoJuego = 2;

                }
                if (Dialogo.Count != 0)
                {
                    t.text = Dialogo[0];
                    Dialogo.RemoveAt(0);
                }
               
                tLeft = 0;
            }

        
        }

        tLeft += Time.deltaTime;
        
    }
}
