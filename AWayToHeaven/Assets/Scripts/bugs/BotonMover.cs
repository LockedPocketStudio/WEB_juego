using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMover : MonoBehaviour
{
    public GameObject player;
    public movement m; 
    public void OnPointerClick(PointerEventData eventData)
    {
       // m.Mover();
        Debug.LogError("que pasa aqui");
    }

    // Start is called before the first frame update
    void Start()
    {
        m = player.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
