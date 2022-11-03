using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escalera : MonoBehaviour
{

    public bool colliding = false;
    public GameObject escaleraCol;

    public int currentScene;

    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;
        //escaleraCol = escaleraCol.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        colliding = false;

    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
                if (!colliding)
                {
                    colliding = true;
                    switch(currentScene)
                    {
                        case 2: //Anillo 1
                            SceneManager.LoadScene(4);  //recibe el nombre de la escena
                            break;

                        case 5: //Anillo 2
                            SceneManager.LoadScene(6);  
                            break;
                        
                        case 7: //Anillo 3
                            SceneManager.LoadScene(8);
                            break;
                        
                        case 9: //Anillo 4
                            SceneManager.LoadScene(0);
                            break;

                    }
                    
                }
        }
    }
}
