using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region variables
    public GameObject jugador;

    public GameObject escalera;
    

    #endregion variables
    
    // Start is called before the first frame update
    void Start()
    {

        jugador = GameObject.Find("Player");

        string nivel = PlayerPrefs.GetString("selectedLevel");
        Debug.Log(nivel);


        //según qué nivel haya elegido el jugador, el personje se colocará en una posición en el mapa (correspondiente a una sala)
        //Las salas están colocadas en forma de cuadrícula de 4x4 
        switch(nivel)
        {
            //Primera fila
            case "Sala1_1":
                Debug.Log("SALA 1_ 1");
                jugador.transform.position = new Vector2(-4.82f, 1.16f);
            break;

            case "Sala1_2":
                Debug.Log("SALA 1_ 2");
                jugador.transform.position = new Vector2(21.7f, 1.16f);
            break;

            case "Sala1_3":
                Debug.Log("SALA 1_ 3");
                jugador.transform.position = new Vector2(48.3f, 1.16f);
            break;

            case "Sala1_4":
                Debug.Log("SALA 1_ 4");
                jugador.transform.position = new Vector2(75.21f, 1.16f);
            break;

            //Segunda fila
            case "Sala2_1":
                Debug.Log("SALA 2_ 1");
                jugador.transform.position = new Vector2(-4.82f, -24.6f);
            break;

            case "Sala2_2":
                Debug.Log("SALA 2_ 2");
                jugador.transform.position = new Vector2(21.9f, -24.6f);
            break;

            case "Sala2_3":
                Debug.Log("SALA 2_ 3");
                jugador.transform.position = new Vector2(47.9f, -24.6f);
            break;

            case "Sala2_4":
                Debug.Log("SALA 2_ 4");
                jugador.transform.position = new Vector2(75.21f, -24.6f);
            break;

            //Tercera fila
            case "Sala3_1":
                Debug.Log("SALA 3_ 1");
                jugador.transform.position = new Vector2(-4.82f, -51.4f);
            break;

            case "Sala3_2":
                Debug.Log("SALA 3_ 2");
                jugador.transform.position = new Vector2(21.9f, -51.4f);
            break;

            case "Sala3_3":
                Debug.Log("SALA 3_ 3");
                jugador.transform.position = new Vector2(47.9f, -51.4f);
            break;

            case "Sala3_4":
                Debug.Log("SALA 3_ 4");
                jugador.transform.position = new Vector2(75.21f, -51.4f);
            break;

            //Cuarta fila
            case "Sala4_1":
                Debug.Log("SALA 4_ 1");
                jugador.transform.position = new Vector2(-4.82f, -78.3f);
            break;

            case "Sala4_2":
                Debug.Log("SALA 4_ 2");
                jugador.transform.position = new Vector2(21.9f, -78.3f);
            break;

            case "Sala4_3":
                Debug.Log("SALA 4_ 3");
                jugador.transform.position = new Vector2(47.9f, -78.3f);
            break;

            case "Sala4_4":
                Debug.Log("SALA 4_ 4");
                jugador.transform.position = new Vector2(75.21f, -78.3f);
            break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
