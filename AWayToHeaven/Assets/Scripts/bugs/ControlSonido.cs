using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSonido : MonoBehaviour
{
    public Slider musica;
    public float volumen;
    AudioSource audio;
    void Start()
    {
      volumen = musica.normalizedValue;
      audio = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        volumen = musica.normalizedValue;
        audio.volume = musica.normalizedValue;
        PlayerPrefs.SetFloat("Volumen", volumen);
    }
}
