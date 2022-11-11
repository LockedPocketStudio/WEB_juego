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
                if(currentScene == 2){
                    jugador.transform.position = new Vector2(-35.34f, 14.79f);
                }else{
                    jugador.transform.position = new Vector2(-44.23f, 14.79f);
                }
                
            break;

            case "Sala1_2":
                Debug.Log("SALA 1_ 2");
                jugador.transform.position = new Vector2(-0.84f, 16.84f);
            break;

            case "Sala1_3":
                Debug.Log("SALA 1_ 3");
                jugador.transform.position = new Vector2(48.21f, 16.84f);
            break;

            case "Sala1_4":
                Debug.Log("SALA 1_ 4");
                jugador.transform.position = new Vector2(97.05f, 16.84f);
            break;

            //Segunda fila
            case "Sala2_1":
                Debug.Log("SALA 2_ 1");
                jugador.transform.position = new Vector2(-44.23f, -24.82f);
            break;

            case "Sala2_2":
                Debug.Log("SALA 2_ 2");
                jugador.transform.position = new Vector2(-0.84f, -24.82f);
            break;

            case "Sala2_3":
                Debug.Log("SALA 2_ 3");
                jugador.transform.position = new Vector2(47.8f, -24.82f);
            break;

            case "Sala2_4":
                Debug.Log("SALA 2_ 4");
                jugador.transform.position = new Vector2(97.05f, -24.82f);
            break;

            //Tercera fila
            case "Sala3_1":
                Debug.Log("SALA 3_ 1");
                jugador.transform.position = new Vector2(-44.23f, -71.56f);
            break;

            case "Sala3_2":
                Debug.Log("SALA 3_ 2");
                jugador.transform.position = new Vector2(-0.84f, -71.56f);
            break;

            case "Sala3_3":
                Debug.Log("SALA 3_ 3");
                jugador.transform.position = new Vector2(48.99f, -71.56f);
            break;

            case "Sala3_4":
                Debug.Log("SALA 3_ 4");
                jugador.transform.position = new Vector2(98.25f, -71.56f);
            break;

            //Cuarta fila
            case "Sala4_1":
                Debug.Log("SALA 4_ 1");
                jugador.transform.position = new Vector2(-44.23f, -116.66f);
            break;

            case "Sala4_2":
                Debug.Log("SALA 4_ 2");
                jugador.transform.position = new Vector2(0.12f, -116.66f);
            break;

            case "Sala4_3":
                Debug.Log("SALA 4_ 3");
                jugador.transform.position = new Vector2(50.4f, -116.66f);
            break;

            case "Sala4_4":
                Debug.Log("SALA 4_ 4");
                jugador.transform.position = new Vector2(99.4f, -116.66f);
            break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
