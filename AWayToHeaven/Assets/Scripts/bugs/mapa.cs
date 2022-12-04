using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapa : MonoBehaviour
{
    public GameObject player;
    public Vector2 lastClick;
    movement m;
    void Start()
    {
        m = player.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //  m.Mover(lastClick);
    }
}
