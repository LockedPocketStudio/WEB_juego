using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static LevelSelection;



public class LevelManager : MonoBehaviour
{

    [System.Serializable]
    public class Level{
        public string levelText;
        public int unlocked;
        public bool isInteractable;
    }

    public GameObject levelButton;
    public Transform Spacer;

    public Sprite salaSubir;
    
    public List<Level> LevelList;

    public int currentScene;
    
    // Start is called before the first frame update
    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;
        FillList();
    }


    void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButton button = newButton.GetComponent<LevelButton>();
            button.levelText.text = level.levelText;

            if(PlayerPrefs.GetInt(button.levelText.text)==1)
            {
                level.unlocked = 1;
                level.isInteractable = true;
            }


            //En el menú de selección de nivel se marca la sala con la escalera para subir al siguiente anillo con un sprite distnto
            if(currentScene==3) //Anillo 1
            {
                if(button.levelText.text == "Sala3_3")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                }
            }else if(currentScene==4)   //Anillo 2
            {
                if(button.levelText.text == "Sala1_1")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                }
            }else if(currentScene==6)   //Anillo 3
            {
                if(button.levelText.text == "Sala2_4")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                }
            }else if(currentScene==8)   //Anillo 4
            {
                if(button.levelText.text == "Sala4_2")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                }
            }

            button.unlockedButton = level.unlocked;
            button.GetComponent<Button>().interactable = level.isInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels(button.levelText.text));

            if(PlayerPrefs.GetInt(button.levelText.text + "_score")>0)
            {
                button.SpriteSalaBloq.SetActive(false);
            }



            newButton.transform.SetParent(Spacer);
        }

        SaveAll();
    }


    void SaveAll()
    {

        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("levelButton");
        foreach(GameObject buttons in allButtons)
        {
            LevelButton button = buttons.GetComponent<LevelButton>();
            PlayerPrefs.SetInt(button.levelText.text, button.unlockedButton);
        }

    }

    void loadLevels(string value)
    {

        //Guardamos qué boton a pulsado el jugador en el PlayerPrefs para poder consultarlo en la escena con las distintas salas
        //y poder saber en qué sala aparece el personaje
        PlayerPrefs.SetString("selectedLevel", value);

        //Cambiar a la escena correspondiente según en qué anillo se encuentre el jugador
        switch(currentScene)
         {
            case 3: //Anillo 1
                SceneManager.LoadScene(2);  //recibe el nombre de la escena
                break;

            case 4: //Anillo 2
                SceneManager.LoadScene(5);  
                break;
            
            case 6: //Anillo 3
                SceneManager.LoadScene(7);
                break;
            
            case 8: //Anillo 4
                SceneManager.LoadScene(9);
                break;

         }

        

    }

}
