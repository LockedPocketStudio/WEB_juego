using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpriteUI : MonoBehaviour
{

    public Image jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("playerPositionX") +"; "+ PlayerPrefs.GetFloat("playerPositionY"));
        jugador.transform.position = new Vector2(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"));        
    }
}
