using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Cofres : MonoBehaviour
{
    #region variables
    public GameObject texto;
    public int consumido = 0; //1 - si ha sido consumido
    public int numerocofre;
    Animator anim;
    float tiempoanim = 1.2f;
    #endregion
    void Start()
    {
        anim = this.GetComponent<Animator>();
        texto.SetActive(false);
        consumido = PlayerPrefs.GetInt("Cofre"+numerocofre);

        if (consumido == 1){
            this.gameObject.SetActive(false);
           // Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (consumido ==1)
        {
            if(tiempoanim <= 0)
            {
                this.gameObject.SetActive(false);
            }
            tiempoanim -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            Player e = collision.gameObject.GetComponent<Player>();
            if(e.LevelUp == true)
            {
                e.GetPower();
                Player.experiencia = 0;
                PlayerPrefs.SetInt("exp", 0);
                e.BarraExp.fillAmount = 0;
                Player.nivelHistoria++;
                e.LevelUp = false;
                consumido = 1;
                
                PlayerPrefs.SetInt("Cofre"+numerocofre,1);
                anim.SetBool("Abrir", true);
                   //  Destroy(this.gameObject);
            }
            else
            {

                texto.SetActive(true);
            }
        }
    }
}
