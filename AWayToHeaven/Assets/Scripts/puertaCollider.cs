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

        /*
        string nivel = PlayerPrefs.GetString("selectedLevel");
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        buscarEnemigos(nivel);
        */
        
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

    /*
    void buscarEnemigos(string nivel){

        //Enemigos en cada sala
        foreach(var e in enemigos){
            
            switch(nivel)
            {
                //Primera fila
                case "Sala1_1":
                    Debug.Log("SALA 1_ 1");
                    
                    //Se buscan los enemigos que se encuentren en esta sala
                    if((e.transform.position.x > -46.51)&&(e.transform.position.x < -28.19)){
                        if((e.transform.position.y > 7.34)&&(e.transform.position.y < 25.75)){
                            enemigosSala.Add(e);
                            numEnemigoSala++;
                            Debug.Log("hay "+numEnemigoSala+" enemigos en la sala"+ nivel);
                        }
                    }
                    
                break;

                case "Sala1_2":
                    Debug.Log("SALA 1_ 2");

                    if((e.transform.position.x > -3.16)&&(e.transform.position.x < 16.13)){
                        if((e.transform.position.y > 7.41)&&(e.transform.position.y < 26.08)){
                            enemigosSala.Add(e);
                            numEnemigoSala++;
                            Debug.Log("hay "+numEnemigoSala+" enemigos en la sala"+ nivel);
                        }
                    }
                    
                break;

                case "Sala1_3":
                    Debug.Log("SALA 1_ 3");

                    if((e.transform.position.x > 44.58)&&(e.transform.position.x < 64.93)){
                        if((e.transform.position.y > 7.41)&&(e.transform.position.y < 26.08)){
                            enemigosSala.Add(e);
                            numEnemigoSala++;
                            Debug.Log("hay "+numEnemigoSala+" enemigos en la sala"+ nivel);
                        }
                    }
                    
                break;

                case "Sala1_4":
                    Debug.Log("SALA 1_ 4");

                    if((e.transform.position.x > 93.62)&&(e.transform.position.x < 113.66)){
                        if((e.transform.position.y > 7.41)&&(e.transform.position.y < 26.08)){
                            enemigosSala.Add(e);
                            numEnemigoSala++;
                            Debug.Log("hay "+numEnemigoSala+" enemigos en la sala"+ nivel);
                        }
                    }
                    
                break;

                //Segunda fila
                case "Sala2_1":
                    Debug.Log("SALA 2_ 1");

                    if((e.transform.position.x > -47.49)&&(e.transform.position.x <-27.15)){
                        if((e.transform.position.y > -34.97)&&(e.transform.position.y < -14.89)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala2_2":
                    Debug.Log("SALA 2_ 2");

                    if((e.transform.position.x > -3.87)&&(e.transform.position.x < 16.62)){
                        if((e.transform.position.y > -34.97)&&(e.transform.position.y < -14.89)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala2_3":
                    Debug.Log("SALA 2_ 3");

                    if((e.transform.position.x > 44.4)&&(e.transform.position.x < 64.78)){
                        if((e.transform.position.y > -34.97)&&(e.transform.position.y < -14.89)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala2_4":
                    Debug.Log("SALA 2_ 4");

                    if((e.transform.position.x > 93.87)&&(e.transform.position.x < 114.31)){
                        if((e.transform.position.y > -34.97)&&(e.transform.position.y < -14.89)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                //Tercera fila
                case "Sala3_1":
                    Debug.Log("SALA 3_ 1");

                    if((e.transform.position.x > -47.46)&&(e.transform.position.x < -26.77)){
                        if((e.transform.position.y > -81.32)&&(e.transform.position.y < -61.81)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala3_2":
                    Debug.Log("SALA 3_ 2");

                    if((e.transform.position.x > -4.41)&&(e.transform.position.x < 16.59)){
                        if((e.transform.position.y > -81.32)&&(e.transform.position.y < -61.81)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala3_3":
                    Debug.Log("SALA 3_ 3");

                    if((e.transform.position.x > 45.27)&&(e.transform.position.x < 66.3)){
                        if((e.transform.position.y > -81.32)&&(e.transform.position.y < -61.81)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala3_4":
                    Debug.Log("SALA 3_ 4");

                    if((e.transform.position.x > 94.44)&&(e.transform.position.x < 116.08)){
                        if((e.transform.position.y > -81.32)&&(e.transform.position.y < -61.81)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                //Cuarta fila
                case "Sala4_1":
                    Debug.Log("SALA 4_ 1");

                    if((e.transform.position.x > -47.69)&&(e.transform.position.x < -26.05)){
                        if((e.transform.position.y > -127.55)&&(e.transform.position.y < -106.29)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala4_2":
                    Debug.Log("SALA 4_ 2");

                    if((e.transform.position.x > -3.98)&&(e.transform.position.x < 17.59)){
                        if((e.transform.position.y > -127.55)&&(e.transform.position.y < -106.29)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala4_3":
                    Debug.Log("SALA 4_ 3");

                    if((e.transform.position.x > 46.63)&&(e.transform.position.x < 67.86)){
                        if((e.transform.position.y > -127.55)&&(e.transform.position.y < -106.29)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                break;

                case "Sala4_4":
                    Debug.Log("SALA 4_ 4");

                    if((e.transform.position.x > 96.04)&&(e.transform.position.x < 117)){
                        if((e.transform.position.y > -127.55)&&(e.transform.position.y < -106.29)){
                            enemigosSala.Add(e);
                        }
                    }
                    
                    
                break;


            }

        }

    }
    */

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
