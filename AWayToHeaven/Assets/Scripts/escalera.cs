using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escalera : MonoBehaviour
{

   #region variables
    public int currentScene;
    

    #endregion variables

    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;
        //escaleraCol = escaleraCol.GetComponent<Collider2D>();
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
            newScene(currentScene);
        }
    }

    public void newScene(int sceneNum){

        //dependiendo de en qué anillo se encuentre, deberá moverse a una escena u otra
        switch(sceneNum)
                    {
                        case 2: //Anillo 1
                            SceneManager.LoadScene(5);  //recibe el nombre de la escena
                            break;

                        case 5: //Anillo 2
                            if(PlayerPrefs.GetString("selectedLevel")=="Sala3_3"){  //volver al anillo 1
                                SceneManager.LoadScene(2);
                            }else{
                                SceneManager.LoadScene(10);  //Sala Final 
                            }
                            
                            break;
                    }
    }
}
