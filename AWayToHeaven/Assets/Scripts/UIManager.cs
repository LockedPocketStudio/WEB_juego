using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Control de Inicio
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button buttonModoHordas;
    [SerializeField] private Button buttonModoHistoria;
    private void Awake()
    {
        
    }
    void Start()
    {
        buttonModoHordas.onClick.AddListener(() => mainMenu.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
