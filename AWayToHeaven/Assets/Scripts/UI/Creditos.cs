using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public Button btnS;
    void Start()
    {
        btnS.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
