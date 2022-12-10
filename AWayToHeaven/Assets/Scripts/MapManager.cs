using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region variables
    public GameObject jugador;

    public GameObject escalera;
    
    public int currentScene;

    #endregion variables
    
    // Start is called before the first frame update
    void Start()
    {

        jugador = GameObject.Find("Player");

        string nivel = PlayerPrefs.GetString("selectedLevel");
        Debug.Log(nivel);

        currentScene = SceneManager.GetActiveScene().buildIndex;


        //según qué nivel haya elegido el jugador, el personje se colocará en una posición en el mapa (correspondiente a una sala)
        //Las salas están colocadas en forma de cuadrícula de 4x4 
        if(currentScene == 2)   //Anillo1
        {
            switch(nivel)
            {
                //Primera fila
                case "Sala1_1":
                    Debug.Log("SALA 1_ 1");
                    jugador.transform.position = new Vector2(-37.04f, 14.29f);
                                        
                break;

                case "Sala1_2":
                    Debug.Log("SALA 1_ 2");
                    jugador.transform.position = new Vector2(6.04f,5.81f);
                break;

                case "Sala1_3":
                    Debug.Log("SALA 1_ 3");
                    jugador.transform.position = new Vector2(54.749f, 5.563f);
                break;

                case "Sala1_4":
                    Debug.Log("SALA 1_ 4");
                    jugador.transform.position = new Vector2(103.56f, 5.64f);
                break;

                //Segunda fila
                case "Sala2_1":
                    Debug.Log("SALA 2_ 1");
                    jugador.transform.position = new Vector2(-37.28f, -35.794f);
                break;

                case "Sala2_2":
                    Debug.Log("SALA 2_ 2");
                    jugador.transform.position = new Vector2(6.39f, -35.77f);
                break;

                case "Sala2_3":
                    Debug.Log("SALA 2_ 3");
                    jugador.transform.position = new Vector2(54.38f, -36.05f);
                break;

                case "Sala2_4":
                    Debug.Log("SALA 2_ 4");
                    jugador.transform.position = new Vector2(103.99f, -35.74f);
                break;

                //Tercera fila
                case "Sala3_1":
                    Debug.Log("SALA 3_ 1");
                    jugador.transform.position = new Vector2(-37.23f, -82.54f);
                break;

                case "Sala3_2":
                    Debug.Log("SALA 3_ 2");
                    jugador.transform.position = new Vector2(5.97f, -82.54f);
                break;

                case "Sala3_3":
                    Debug.Log("SALA 3_ 3");
                    jugador.transform.position = new Vector2(56f, -82.61f);
                    
                break;

                case "Sala3_4":
                    Debug.Log("SALA 3_ 4");
                    jugador.transform.position = new Vector2(105.21f, -82.61f);
                break;

                //Cuarta fila
                case "Sala4_1":
                    Debug.Log("SALA 4_ 1");
                    jugador.transform.position = new Vector2(-37.5f, -127.52f);
                break;

                case "Sala4_2":
                    Debug.Log("SALA 4_ 2");
                    jugador.transform.position = new Vector2(6.74f, -123.93f);
                break;

                case "Sala4_3":
                    Debug.Log("SALA 4_ 3");
                    jugador.transform.position = new Vector2(57.28f, -123.93f);
                break;

                case "Sala4_4":
                    Debug.Log("SALA 4_ 4");
                    if(currentScene == 2){
                        jugador.transform.position = new Vector2(99.2f, -116.55f);
                    }else{
                        jugador.transform.position = new Vector2(106.36f, -123.93f);
                    }
                    
                break;


            }

        }else if(currentScene == 5) //Anillo2
        {

        }else if(currentScene == 10){   //Sala final

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
