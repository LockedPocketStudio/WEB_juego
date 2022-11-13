using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static LevelSelection;



public class LevelManager : MonoBehaviour
{

    #region variables
    [System.Serializable]
    public class Level{
        public string levelText;
        public int unlocked = 0;
        public bool isInteractable = false;
    }

    public GameObject levelButton;
    public Transform Spacer;

    public Sprite salaSubir;
    public Sprite playerSpt;
    //public GameObject playerSpt;
    //float playerPosX;
    //float playerPosY;
    
    public List<Level> LevelList;

    public int currentScene;
    public string lastLevel = "Sala1_1";
    #endregion variables;
    
    // Start is called before the first frame update
    void Start()
    {
        //Movimiento entre escenaas
        currentScene = SceneManager.GetActiveScene().buildIndex;
        lastLevel = PlayerPrefs.GetString("selectedLevel");
                
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        //FillList();
    }


    void FillList()
    {
        foreach(var level in LevelList)
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButton button = newButton.GetComponent<LevelButton>();
            button.levelText.text = level.levelText;
            
            //En el menú de selección de nivel se marca la sala con la escalera para subir al siguiente anillo con un sprite distnto
            //Además, estos niveles siempre estarán desbloqueados desde el principio y serán interactuables
            if(currentScene==3) //Anillo 1
            {
                if(button.levelText.text == "Sala3_3")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                    button.unlockedButton = 1;
                    button.GetComponent<Button>().interactable = true;
                }
            }else if(currentScene==4)   //Anillo 2
            {
                if(button.levelText.text == "Sala1_1")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                    button.unlockedButton = 1;
                    button.GetComponent<Button>().interactable = true;
                }
            }else if(currentScene==6)   //Anillo 3
            {
                if(button.levelText.text == "Sala2_4")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                    button.unlockedButton = 1;
                    button.GetComponent<Button>().interactable = true;
                }
            }else if(currentScene==8)   //Anillo 4
            {
                if(button.levelText.text == "Sala4_2")
                {
                    button.GetComponent<Image>().sprite = salaSubir;
                    button.unlockedButton = 1;
                    button.GetComponent<Button>().interactable = true;
                }
            }

            //Se muestra al jugador en qué sala se encuentra
            if(button.levelText.text == lastLevel)
                {
                    button.GetComponent<Image>().sprite = playerSpt;
                    button.unlockedButton = 1;
                    button.GetComponent<Button>().interactable = true;
                }

            //Se hacen interactuables los botones de las salas vecinas a la última en la que se ha estado
            //Para que el jugador solo pueda acceder a una de estas

            //Creamos un array que contenga el string lastLevel, con la forma: "SalaX_Y"
                char[] num = new char[lastLevel.Length];
                
                for(int i=0; i < lastLevel.Length; i++)
                {
                    num[i] = lastLevel[i];
                }

                //Seleccionamos las posiciones del array que correspondan a las coordenadas X, Y para
                //saber a qué posicion del grid nos referimos
                //Debug.Log(num[4]);    //Comprobamos que el array está cogiendo el valor correctamente
                int x = (int)char.GetNumericValue(num[4]);
                int y = (int)char.GetNumericValue(num[6]);

                //Desbloqueamos las salas vecinas
                //Si alguna de estas salas no existiera (por ejemplo si se comrpobase la sala 0_0)
                //No habría problema, ya que la condición del if nunca se va a cumplir, por lo que 
                //no se intentarán desbloquear salas inexistentes
                if(("Sala"+x+"_"+y) == button.levelText.text){
                    level.unlocked = 1;
                    level.isInteractable = true;

                }else if(("Sala"+(x+1)+"_"+y) == button.levelText.text){
                    level.unlocked = 1;
                    level.isInteractable = true;

                }else if(("Sala"+(x-1)+"_"+y) == button.levelText.text){
                    level.unlocked = 1;
                    level.isInteractable = true;

                }else if(("Sala"+x+"_"+(y+1)) == button.levelText.text){
                    level.unlocked = 1;
                    level.isInteractable = true;
                    
                }else if(("Sala"+x+"_"+(y-1)) == button.levelText.text){
                    level.unlocked = 1;
                    level.isInteractable = true;
                }else{
                    level.unlocked = 0;
                    level.isInteractable = false;
                }

            button.unlockedButton = level.unlocked;
            button.GetComponent<Button>().interactable = level.isInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => {
                lastLevel = button.levelText.text;
                PlayerPrefs.SetString("selectedLevel", lastLevel);
                button.unlockedButton = level.unlocked;
                button.GetComponent<Button>().interactable = level.isInteractable;
                loadLevels(button.levelText.text);});

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

    //función para cargar la escena con el anillo correspondiente 
    void loadLevels(string value)
    {

        //Guardamos qué boton a pulsado el jugador en el PlayerPrefs para poder consultarlo en la escena con las distintas salas
        //y poder saber en qué sala aparece el personaje --> se ultiliza esto en el MapManager
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
