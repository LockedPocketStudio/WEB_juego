using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puertaCollider : MonoBehaviour
{
      //public Text textoPuerta;
    #region variables
    public int currentScene;

    public SpriteRenderer spriteRend;

    public Sprite pRojaCerrada;
    public Sprite pRojaAbierta;
    public Sprite pGrisCerrada;
    public Sprite pGrisAbierta;


    //Animacion
    //Animator animacion;

    //public GameObject[] enemigos;
    //public GameObject obj;
    //public List<GameObject> enemigosSala;
    //public int numEnemigoSala = 0;
    

    #endregion variables

    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
        if(currentScene == 2){
            spriteRend.sprite = pRojaCerrada;
        }else if(currentScene == 5){
            spriteRend.sprite = pGrisCerrada;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //Detect collisions
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("JUGADOR HA CHOCADO");
        }
    }

    void OnTriggerEnter2D(Collider2D col){

            if(col.gameObject.tag == "Player"){

            Player e = col.GetComponent<Player>();
            if (e.PasarSala)
            {
                if (currentScene == 2)
                {
                    spriteRend.sprite = pRojaAbierta;
                }
                else if (currentScene == 5)
                {
                    spriteRend.sprite = pGrisAbierta;
                }

                newScene(currentScene);
            }
           
        }
    }

    public void newScene(int sceneNum){

        //dependiendo de en qué anillo se encuentre, deberá moverse a una escena u otra
        switch(sceneNum)
        {
            case 2: //Anillo 1
                SceneManager.LoadScene(3);  //recibe el nombre de la escena
                break;

            case 5: //Anillo 2
                SceneManager.LoadScene(4);  
                break;
        }
    }
}
