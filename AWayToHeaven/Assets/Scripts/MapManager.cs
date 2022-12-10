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
                    jugador.transform.position = new Vector2(6.77f, -127.6f);
                break;

                case "Sala4_3":
                    Debug.Log("SALA 4_ 3");
                    jugador.transform.position = new Vector2(57.39f, -127.6f);
                break;

                case "Sala4_4":
                    Debug.Log("SALA 4_ 4");
                    jugador.transform.position = new Vector2(106.39f, -127.6f);
                                        
                break;
            }

        }else if(currentScene == 5) //Anillo2
        {
            switch(nivel)
            {
                //Primera fila
                case "Sala1_1":
                    Debug.Log("SALA 1_ 1");
                    jugador.transform.position = new Vector2(-37.23f, 5.92f);
                                        
                break;

                case "Sala1_2":
                    Debug.Log("SALA 1_ 2");
                    jugador.transform.position = new Vector2(6.16f,5.92f);
                break;

                case "Sala1_3":
                    Debug.Log("SALA 1_ 3");
                    jugador.transform.position = new Vector2(54.71f, 5.92f);
                break;

                case "Sala1_4":
                    Debug.Log("SALA 1_ 4");
                    jugador.transform.position = new Vector2(103.62f, 6.04f);
                break;

                //Segunda fila
                case "Sala2_1":
                    Debug.Log("SALA 2_ 1");
                    jugador.transform.position = new Vector2(-37.21f, -35.6f);
                break;

                case "Sala2_2":
                    Debug.Log("SALA 2_ 2");
                    jugador.transform.position = new Vector2(6.06f, -35.6f);
                break;

                case "Sala2_3":
                    Debug.Log("SALA 2_ 3");
                    jugador.transform.position = new Vector2(54.82f, -35.6f);
                break;

                case "Sala2_4":
                    Debug.Log("SALA 2_ 4");
                    jugador.transform.position = new Vector2(104.36f, -35.6f);
                break;

                //Tercera fila
                case "Sala3_1":
                    Debug.Log("SALA 3_ 1");
                    jugador.transform.position = new Vector2(-37.17f, -82.21f);
                break;

                case "Sala3_2":
                    Debug.Log("SALA 3_ 2");
                    jugador.transform.position = new Vector2(6.04f, -82.51f);
                break;

                case "Sala3_3":
                    Debug.Log("SALA 3_ 3");
                    jugador.transform.position = new Vector2(55.93f, -73.64f);
                    
                break;

                case "Sala3_4":
                    Debug.Log("SALA 3_ 4");
                    jugador.transform.position = new Vector2(105.38f, -82.09f);
                break;

                //Cuarta fila
                case "Sala4_1":
                    Debug.Log("SALA 4_ 1");
                    jugador.transform.position = new Vector2(-36.75f, -127.23f);
                break;

                case "Sala4_2":
                    Debug.Log("SALA 4_ 2");
                    jugador.transform.position = new Vector2(6.85f, -127.23f);
                break;

                case "Sala4_3":
                    Debug.Log("SALA 4_ 3");
                    jugador.transform.position = new Vector2(57.33f, -127.23f);
                break;

                case "Sala4_4":
                    Debug.Log("SALA 4_ 4");
                    jugador.transform.position = new Vector2(106.25f, -127.23f);
                                        
                break;
            }

        }else if(currentScene == 10){   //Sala final
            jugador.transform.position = new Vector2(-37.189f, -8.131f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
