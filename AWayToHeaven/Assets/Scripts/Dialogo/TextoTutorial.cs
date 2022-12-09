using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TextoTutorial : MonoBehaviour
{
    public Button PasarTexto;
    public GameObject Pasa;
    public bool puedePasar = false;

    public GameObject EscenaDialogo;
    public GameManager GM;
    List<string> DialogoHistoria;
    List<string> DialogoHordas;
    List<string> DialogoControles;

    public GameObject eleccion;
    public Button controles;  //0
    public Button mH;  //1
    public Button mordas;  //2
    public Button prueba; //3
    public Button salir;
    public int tipoTexto = -1;
   public  int i=0; //historia
    public int z = 0;//hordas
    public int y = 0;//controles
    
    public TMP_Text t;
    string a ="¿Hola? parece que no sabes muy bien qué hacer… ¿Te echo una mano? ¿Qué tipo de información necesitas?";
    
    string o = "En cuanto al modo hordas consiste en sobrevivir 5 minutos, existen 3 niveles de dificultad. Te animo a probarlo";
    
    string h1 = "En el modo historia te contar� como has acabado aqu�... Seguro que tienes ganas de saberlo";
    string h2 = "Tu objetivo ser� buscar unas escaleras ... No te dir� el porque , eso tendr�s que averiguarlo tu";
    string h3 = "Para escapar de las salas tendr�s que buscar una puerta y la llave que la abre claro... ";
    string h4 = "Al salir de una sala podr�s elegir la siguiente sala a la que ir�s de entre las adyacentes a ella";
    string h5 = "Por �ltimo, cuando tu barra de experiencia se llene , no obtendr�s un power up de manera autom�tica. Tendr�s que buscar un cofre para poder conseguirlo";
    string hf = "�Necesitas m�s informaci�n?";

    string s1 = "Es importante que sepas cómo moverte por este mundo antes de explorarlo.";
    string s2 = "Para moverte, solo debes hacer click en el lugar al que quieres ir o mantener el click pulsado en la dirección en la que quieras andar. ";
    string s3 = "Si estás jugando en un dispositivo móvil, puedes hacer esto tocando la pantalla.";
    string s4 = "Para que te puedas defender de los enemigos que te encuentres por este mundo te he concedido el poder de dispararles, ¡aprovéchalo!";
    string s5 = "Para disparar debes estar cerca de un enemigo. El disparo será automático, por lo que no tienes que preocuparte por nada más.";
    string s6 = "Existen diferentes tipos de enemigos a los que te irás enfrentando, algunos más fuertes y resistentes que otros.";
    string s7 = "Aquí te presento a tres de ellos para que sepas cómo son: Huesitos, Pesadilla y la Torre. Te dejo que conozcas tú mismo a los demás…";
    string s8 = "Ten cuidado al enfrentarte a ellos, ¡te pueden matar!";
    string s9 = "Puedes saber cuánta vida te queda gracias a la barra de estado que se encuentra en la parte superior izquierda de la pantalla.";
    string s10 = "También en esa posición podrás consultar cuántos aurem has acumulado hasta el momento.";
    string s11 = "Ya descubrirás para qué sirve el aurem en cada modo de juego…";
    
    string s12 = "Con todo esto dicho, te dejo que pruebes tú mismo. ¡Ánimo!";

    string final = "Bueno ... y eso ha sido todo, te mando a la pantalla principal para que puedas jugar otros modos ... �Suerte!";

    public float tText = 0.15f;
    public float tLeft = 0;

    float tiempofinal = 2f;
    float tfleft=0;
    void Start()
    {

        GM = GameManager.FindObjectOfType<GameManager>();
        DialogoHistoria = new List<string>();
        DialogoHordas = new List<string>();
        DialogoControles = new List<string>();
        // DialogoHistoria
        DialogoHistoria.Add(h1);
        DialogoHistoria.Add(h2);
        DialogoHistoria.Add(h3);
        DialogoHistoria.Add(h4);
        DialogoHistoria.Add(h5);
        DialogoHistoria.Add(hf);

        // DialogoHordas
        DialogoHordas.Add(o);
        DialogoHordas.Add(hf);

        //DialogoControles
        DialogoControles.Add(s1);
        DialogoControles.Add(s2);
        DialogoControles.Add(s3);
        DialogoControles.Add(s4);
        DialogoControles.Add(s5);
        DialogoControles.Add(hf);


        mH.onClick.AddListener(() => { tipoTexto = 1; i = 0; eleccion.SetActive(false); t.text = DialogoHistoria[0]; i++; });
        mordas.onClick.AddListener(() => { tipoTexto = 2; z = 0; eleccion.SetActive(false); t.text = DialogoHordas[0]; z++; });
        controles.onClick.AddListener(() => { tipoTexto = 0; y = 0; eleccion.SetActive(false); t.text = DialogoControles[0]; y++; });
        prueba.onClick.AddListener(() => { eleccion.SetActive(false); EscenaDialogo.SetActive(false);
            Pasa.SetActive(false);
            GM.modoJuego = 2;
            tipoTexto = -1;
        });

        salir.onClick.AddListener(() => SceneManager.LoadScene(0));
        PasarTexto.onClick.AddListener(() => puedePasar = true);
        t.text = a;

        
      //  eleccion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.finModo2)
        {
            switch (tipoTexto)
            {
                case 0:
                    PresentarTextoControles();
                    break;
                case 1:
                    PresentarTextoHistoria();
                   
                    break;
                case 2:
                    PresentarTextoHordas();
                    break;
                
                case -1:
                    break;
            }
        }
        else
        {
            eleccion.SetActive(false);
            EscenaDialogo.SetActive(false);
           
            Textofinal();
        }
       


    }
    public void Textofinal()
    {
        EscenaDialogo.SetActive(true);
        eleccion.SetActive(false);
        t.text = final;
        
        Pasa.SetActive(false);
        
        if (tfleft > tiempofinal)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)))
            {
                SceneManager.LoadScene(0);
            }
        
        }
       

        tfleft += Time.deltaTime;
    }
    public void PresentarTextoControles()
    {
        if (tLeft > tText)
        {
           if(puedePasar)
          //  if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                if (DialogoControles.Count != y)
                {
                    t.text = DialogoControles[y];
                    y++;
                    tLeft = 0;
                }
                else
                {
                    eleccion.SetActive(true);
                }
                puedePasar = false;
            }


        }

        tLeft += Time.deltaTime;
    }

    public void PresentarTextoHordas()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (DialogoHordas.Count != z)
                {
                    t.text = DialogoHordas[z];
                    z++;
                    tLeft = 0;
                }
                else
                {
                    eleccion.SetActive(true);
                }
                puedePasar = false;
            }


        }

        tLeft += Time.deltaTime;
    }
    public void PresentarTextoHistoria()
    {
        
        if(tLeft > tText)
        {
            if (puedePasar)
            {
                if(DialogoHistoria.Count != i)
                {
                    t.text = DialogoHistoria[i];
                    i++;
                    tLeft = 0;
                }
                else
                {
                    eleccion.SetActive(true);
                }
                puedePasar = false;
                /*
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
                */
            }

        
        }

        tLeft += Time.deltaTime;
        
    }
}
