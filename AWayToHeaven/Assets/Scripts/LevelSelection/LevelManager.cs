using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Para poder usar eventos como el OnClick Button
using UnityEngine.SceneManagement;
 

[System.Serializable]
    public class Level  //Información de los botones
    {
        public string levelText; 
        //public Image levelImage;
        public int unlocked;
        public bool isInteractable;
    }

public class LevelManager : MonoBehaviour
{

    public GameObject levelButton;
    public Transform SpacerPanel;
    public List<Level> LevelList; 
    
    // Start is called before the first frame update
    void Start()
    {
        //DeleteAll();
        FillList();
    }

    void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButton button = newButton.GetComponent<LevelButton>();   //relacionamos este script con el script propio del botón
            button.levelText.text = level.levelText;  //cambiar por imágenes 

            //Selección de nivel por el jugador
            if(PlayerPrefs.GetInt("Level" + button.levelText.text) == 1)
            {
                level.unlocked = 1;
                level.isInteractable = true;
            }

            button.buttonUnlocked = level.unlocked;
            button.GetComponent<Button>().interactable = level.isInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels(button.levelText.text));

            if((PlayerPrefs.GetInt("Level" + button.levelText.text + "_score"))>0)
            {
                button.SpriteSalaBloq.SetActive(false);  //al superar el nivel, se hace más claro el sprite
            }


            newButton.transform.SetParent(SpacerPanel);
        }

        SaveAll();

    }

    void SaveAll()
    {
        
            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("levelButton");
            foreach(GameObject buttons in allButtons)
            {
                LevelButton button = buttons.GetComponent<LevelButton>();
                PlayerPrefs.SetInt("Level" +  button.levelText.text, button.buttonUnlocked);  //guardamos si cada nivel se ha desbloqueado o no 
            }
        
    }

    void loadLevels(string value)
    {
        //Application.LoadLevel(value);
        SceneManager.LoadScene(value);
    }

}
