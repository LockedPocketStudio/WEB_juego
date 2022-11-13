using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puertaCollider : MonoBehaviour
{
   //public Text textoPuerta;
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
                            SceneManager.LoadScene(3);  //recibe el nombre de la escena
                            break;

                        case 5: //Anillo 2
                            SceneManager.LoadScene(4);  
                            break;
                        
                        case 7: //Anillo 3
                            SceneManager.LoadScene(6);
                            break;
                        
                        case 9: //Anillo 4
                            SceneManager.LoadScene(8);
                            break;

                    }
    }
}
