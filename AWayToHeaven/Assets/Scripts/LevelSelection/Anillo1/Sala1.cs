using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala1 : MonoBehaviour
{

    int score = 1000;//para comprobar que las estrellas funcionan correctamente
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level2", 1);
        PlayerPrefs.SetInt("Level1_score", score);
        StartCoroutine(Time());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //solo para comprobar que se están desbloqyeando correctamente los niveles
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);

        Application.LoadLevel(5);//poner el numero de escena a la que se quiera ir -> mirar en build settings
    }
}
