using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuJuegoHist : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Exit;
    [SerializeField] private Button Reanudar;
    public bool pausa = false;
    public int currentScene;
    public GameManager GM;

    public GameObject panel;
    public GameObject panelOcultar;
    void Start()
    {
        panelOcultar.SetActive(false);
        panel.SetActive(false);

        currentScene = SceneManager.GetActiveScene().buildIndex;

        Reanudar.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        MainMenu.onClick.AddListener(() => { pausa = true; Reanudar.gameObject.SetActive(true);
           Exit.gameObject.SetActive(true);
            GM.modoJuego = -1;
            panel.SetActive(true);
            panelOcultar.SetActive(true);
        });
        Reanudar.onClick.AddListener(() => {
            pausa = false; Reanudar.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);
            GM.modoJuego = 0;
            panel.SetActive(false);
            panelOcultar.SetActive(false);
        });
        Exit.onClick.AddListener(() => { exitFunction(); });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Dependiendo de en qué momento se dé al botón de salir se volverá al menú
    // de selección de sala o al menú principal el juego
    void exitFunction()
    {
        //Cambiar a la escena correspondiente según en qué anillo se encuentre el jugador
        switch(currentScene)
        {
            case 2: //Anillo 1
                if(PlayerPrefs.GetString("selectedLevel") == "Sala1_1"){
                    SceneManager.LoadScene(0);  //Al iniciar el juego en modo historia
                                                //El jugador aparecerá en la primera sala del primer anillo
                                                //Para conocer un poco de narrativa
                }else{
                    SceneManager.LoadScene(3);  
                }
                break;

            case 5: //Anillo 2
                SceneManager.LoadScene(4);  
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
