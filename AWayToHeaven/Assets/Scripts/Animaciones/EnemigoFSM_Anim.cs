using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoFSM_Anim : MonoBehaviour
{

    #region variables
    public int currentScene;

    public AnimationClip huesitosF;
    public AnimationClip huesitosT;
    public AnimationClip animacionFSM;

    #endregion variables

    // Start is called before the first frame update
    void Start()
    {

        //se elige cuál de las animaciones de esqueletos se usa, según en qué anillo se encuentre el jugador
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene == 2){  //Anillo 1
            animacionFSM = huesitosF;
        }else if(currentScene == 5){ //Anillo 2
            animacionFSM = huesitosT;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
