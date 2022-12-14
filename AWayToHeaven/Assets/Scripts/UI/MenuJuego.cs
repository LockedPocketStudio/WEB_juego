using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJuego : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Exit;
    [SerializeField] private Button Reanudar;
    public GameObject panel;
    public GameObject panelOcultar;
    
    public bool pausa = false;
    public GameManager GM;
    void Start()
    {
        panelOcultar.SetActive(false);
        panel.SetActive(false);
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
            GM.modoJuego = 1;
            panel.SetActive(false);
            panelOcultar.SetActive(false);
        });
        Exit.onClick.AddListener(() => { SceneManager.LoadScene(0); });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
