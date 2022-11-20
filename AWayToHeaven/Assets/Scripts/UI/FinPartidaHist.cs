using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class FinPartidaHist : MonoBehaviour
{
    [Header("End Game")]
    [SerializeField] private GameObject EndGame;
    [SerializeField] private Button buttonReiniciar;
    [SerializeField] private Button buttonVolver;
    [SerializeField] private Text tex;
    public GameManager GM;

    public int currentScene;


    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;

        EndGame.SetActive(false);
        buttonVolver.onClick.AddListener(() => { SceneManager.LoadScene(0);});
        buttonReiniciar.onClick.AddListener(() => { LoadLevel();});
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.estadoJugador == -1)
        {
            EndGame.SetActive(true);
        }
    }

    void LoadLevel()
    {
        //Cambiar a la escena correspondiente según en qué anillo se encuentre el jugador
        //Si el jugador muere en una sala, tiene la opción de volver a empezar en ese anillo
        switch(currentScene)
        {
            case 2: //Anillo 1
                    //  SceneManager.LoadScene(3);  //recibe el nombre de la escena -> LevelMenuA1
                SceneManager.LoadScene(2);
                break;

            case 5: //Anillo 2
                SceneManager.LoadScene(5);  
                break;
            
            case 7: //Anillo 3
                SceneManager.LoadScene(6);
                break;
            
            case 9: //Anillo 4
                SceneManager.LoadScene(8);
                break;

        }
    }
}
