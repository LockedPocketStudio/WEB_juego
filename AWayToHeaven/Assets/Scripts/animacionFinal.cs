using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class animacionFinal : MonoBehaviour
{
    float TiempoTotalAparecer = 5f;
    float tiempoRestante = 6f;
    public Image letras;
    public Image fondo;
    public Image fondoNormal;
    float avance = 0.3f;
    float avance2 = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var a = letras.color.a;
        var b = fondo.color.a;
        var c = fondoNormal.color.a;
        a += avance * Time.deltaTime;
        b += avance2 * Time.deltaTime;
        c -= avance * Time.deltaTime;
        Color nuevo = new Color(1, 1, 1, a);
        Color nuevo2 = new Color(1, 1, 1, a);
        Color nuevo3 = new Color(1, 1, 1, c);

        letras.color = nuevo;
        fondo.color = nuevo2;
        fondoNormal.color = nuevo3;

        if (tiempoRestante <= 0)
        {
            SceneManager.LoadScene(12);
        }
        tiempoRestante -= Time.deltaTime;
       
        
    }
}
