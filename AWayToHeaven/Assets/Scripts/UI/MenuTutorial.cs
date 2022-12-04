using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTutorial : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Exit;
    [SerializeField] private Button Reanudar;
    public GameObject PasarTexto;
    public GameObject Panel;
    public bool pausa = false;
    public int currentScene;
    public GameManager GM;
    void Start()
    {
        Panel.SetActive(false);
        Reanudar.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        MainMenu.onClick.AddListener(() => {
            PasarTexto.SetActive(false);
            pausa = true; Reanudar.gameObject.SetActive(true);
            Exit.gameObject.SetActive(true);
            GM.modoJuego = -1;
            Panel.SetActive(true);
          
        });
        Reanudar.onClick.AddListener(() => {
            PasarTexto.SetActive(true);
            pausa = false; Reanudar.gameObject.SetActive(false);
            Panel.SetActive(false);
            Exit.gameObject.SetActive(false);
            if (GM.iniciopelea==true){
                GM.modoJuego = 2;
            }
            else
            {
                GM.modoJuego = -1;
            }
            
           
        });
        Exit.onClick.AddListener(() =>  SceneManager.LoadScene(0) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
