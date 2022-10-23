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
    
    public List<Level> LevelList;
    
    // Start is called before the first frame update
    void Start()
    {
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
        SceneManager.LoadScene(2);  //recibe el nombre de la escena

    }

}
