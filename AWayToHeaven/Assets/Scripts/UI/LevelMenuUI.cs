using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuUI : MonoBehaviour
{
    [Header("Main Menu")]
    
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Exit;
    [SerializeField] private Button Reanudar;
    [SerializeField] private RectTransform Fondo;
    public bool pausa = false;
    public int currentScene;
    //public GameManager GM;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        Fondo.gameObject.SetActive(false);
        Reanudar.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        MainMenu.onClick.AddListener(() => { pausa = true; 
            
            Reanudar.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            Fondo.gameObject.SetActive(true);
            //GM.modoJuego = -1;
        });
        Reanudar.onClick.AddListener(() => {
            pausa = false; 
            Fondo.gameObject.SetActive(false);
            Reanudar.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);
            //GM.modoJuego = 1;
        });
        Exit.onClick.AddListener(() => { SceneManager.LoadScene(0); });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
