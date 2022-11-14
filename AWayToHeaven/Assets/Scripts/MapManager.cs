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
        switch(nivel)
        {
            //Primera fila
            case "Sala1_1":
                Debug.Log("SALA 1_ 1");
                if(currentScene == 2){  //Anillo 1
                    jugador.transform.position = new Vector2(-37.59f, 11.44f);
                }else if(currentScene == 10){   //Sala final
                    jugador.transform.position = new Vector2(-42.86f, 16.69f);
                }else{
                    jugador.transform.position = new Vector2(-37.59f, 9.34f);
                }
                
            break;

            case "Sala1_2":
                Debug.Log("SALA 1_ 2");
                jugador.transform.position = new Vector2(6.1f, 9.68f);
            break;

            case "Sala1_3":
                Debug.Log("SALA 1_ 3");
                jugador.transform.position = new Vector2(54.69f, 9.68f);
            break;

            case "Sala1_4":
                Debug.Log("SALA 1_ 4");
                jugador.transform.position = new Vector2(103.6f, 9.68f);
            break;

            //Segunda fila
            case "Sala2_1":
                Debug.Log("SALA 2_ 1");
                jugador.transform.position = new Vector2(-37.19f, -32.25f);
            break;

            case "Sala2_2":
                Debug.Log("SALA 2_ 2");
                jugador.transform.position = new Vector2(6.22f, -32.25f);
            break;

            case "Sala2_3":
                Debug.Log("SALA 2_ 3");
                jugador.transform.position = new Vector2(54.8f, -32.34f);
            break;

            case "Sala2_4":
                Debug.Log("SALA 2_ 4");
                jugador.transform.position = new Vector2(104.07f, -32.05f);
            break;

            //Tercera fila
            case "Sala3_1":
                Debug.Log("SALA 3_ 1");
                jugador.transform.position = new Vector2(-37.19f, -78.75f);
            break;

            case "Sala3_2":
                Debug.Log("SALA 3_ 2");
                jugador.transform.position = new Vector2(5.94f, -78.75f);
            break;

            case "Sala3_3":
                Debug.Log("SALA 3_ 3");
                if(currentScene == 2){
                    jugador.transform.position = new Vector2(55.84f, -78.91f);
                }else{
                    jugador.transform.position = new Vector2(55.65f, -74.83f);
                }
            break;

            case "Sala3_4":
                Debug.Log("SALA 3_ 4");
                jugador.transform.position = new Vector2(105.11f, -78.95f);
            break;

            //Cuarta fila
            case "Sala4_1":
                Debug.Log("SALA 4_ 1");
                jugador.transform.position = new Vector2(-37.26f, -123.93f);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
