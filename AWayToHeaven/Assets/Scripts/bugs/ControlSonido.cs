using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSonido : MonoBehaviour
{
    public Slider musica;
    public float volumen;
    public float volumenEscenas;
    AudioSource audio;
    void Start()
    {
        audio = this.GetComponent<AudioSource>();

        if(musica != null)
        {
            musica.value = audio.volume = PlayerPrefs.GetFloat("Volumen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(musica != null)
        {
            volumen = musica.normalizedValue;
            PlayerPrefs.SetFloat("Volumen", volumen);

            audio.volume = musica.normalizedValue;
        }
       // else
        //{
            audio.volume = PlayerPrefs.GetFloat("Volumen");
        //}
        
       
       volumenEscenas = PlayerPrefs.GetFloat("Volumen");
    }
}
