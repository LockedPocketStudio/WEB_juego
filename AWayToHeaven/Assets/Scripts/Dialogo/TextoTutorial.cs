using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TextoTutorial : MonoBehaviour
{
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
    string a ="¿Hola? , bueno... veo que no sabes muy bien que hacer. ¿Qué tipo de información necesitas?";
    
    string o = "En cuanto al modo hordas consiste en sobrevivir 5 minutos, existen 3 niveles de dificultad. Te animo a probarlo";
    
    string h1 = "En el modo historia te contaré como has acabado aqui... Seguro que tienes ganas de saberlo";
    string h2 = "Tu objetivo será buscar unas escaleras ... No te diré el porque , eso tendrás que averiguarlo tu";
    string h3 = "Para escapar de las salas tendrás que buscar una puerta ";
    string h4 = "Al salir de una sala podrás elegir la siguiente sala a la que irás de entre las adyacentes a ella";
    string h5 = "Por último, cuando tu barra de experiencia se llene , no obtendrás un power up de manera automática. Tendrás que buscar un cofre para poder conseguirlo";
    string hf = "¿Necesitas más información?";

    string s1 = "Ahora voy a hablarte de como moverte por este mundo";
    string s2 = "Puedes moverte tocando hacia donde quieres ir y no te preocupes, ya que puedes disparar de manera automática";
    string s3 = "Existen diferentes tipos de enemigos, aquí te presento a estos 3 : al esqueleto , murcielago y la torre";
    string s4 = "También como ves arriba a la izquierda se encuentra tu barra de estado. La barra de arriba muestra tu vida y la de abajo la experiencia que vayas acumulando";
    string s5 = "Cuando tu barra de experiencia se llene , en el modo hordas obtendrás un power up de manera automática pero en el modo historia necesitas acercarte a un cofre para obtenerlo";
  
    
    string s6 = "Con todo esto dicho te dejo que lo pruebes tu mismo, ¡Ánimo!";

    string final = "Bueno ... y eso ha sido todo, te mando a la pantalla principal para que puedas jugar otros modos ... ¡Suerte!";

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
            GM.modoJuego = 2;
            tipoTexto = -1;
        });

        salir.onClick.AddListener(() => SceneManager.LoadScene(0));
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
        if (tfleft > tiempofinal)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                SceneManager.LoadScene(0);
        }
       

        tfleft += Time.deltaTime;
    }
    public void PresentarTextoControles()
    {
        if (tLeft > tText)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
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

            }


        }

        tLeft += Time.deltaTime;
    }

    public void PresentarTextoHordas()
    {
        if (tLeft > tText)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
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
               
            }


        }

        tLeft += Time.deltaTime;
    }
    public void PresentarTextoHistoria()
    {
        
        if(tLeft > tText)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
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
