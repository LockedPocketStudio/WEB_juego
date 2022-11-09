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


    void Start()
    {
        EndGame.SetActive(false);
        buttonVolver.onClick.AddListener(() => { SceneManager.LoadScene(0);});
        buttonReiniciar.onClick.AddListener(() => { SceneManager.LoadScene(1);});
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.estadoJugador == -1)
        {
            EndGame.SetActive(true);
        }
    }
}
