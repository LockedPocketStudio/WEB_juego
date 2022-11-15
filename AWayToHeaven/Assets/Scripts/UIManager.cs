using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Control de Inicio
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button buttonModoHordas;
    [SerializeField] private Button buttonModoHistoria;
    [SerializeField] public Button btnTutorial;

    public GameObject Tutorial;
 

    //   public int modoJuego = -1;//0 - Modo historia  // 1 - Modo hordas 

    //Control Hordas
    // [Header("Hordas Mode")]
    // [SerializeField] public Text timer;
    // float time = 0f;

    private void Awake()
    {
        
    }
    void Start()
    {
      
       // Tutorial.SetActive(false);

        // buttonModoHistoria.onClick.AddListener(() => { mainMenu.SetActive(false); modoJuego = 0;});
        buttonModoHistoria.onClick.AddListener(() => { 
            PlayerPrefs.SetString("selectedLevel", "Sala1_1");
            SceneManager.LoadScene(2);});
        //  buttonModoHordas.onClick.AddListener(() => { mainMenu.SetActive(false); modoJuego = 1 ;}) ; 
        buttonModoHordas.onClick.AddListener(() => { SceneManager.LoadScene(1);});

        btnTutorial.onClick.AddListener(() =>  SceneManager.LoadScene(11));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(modoJuego == 1)
        {
            time += Time.deltaTime;
            string t = time.ToString("F2");
            timer.text = t;
        }*/
    }

}
