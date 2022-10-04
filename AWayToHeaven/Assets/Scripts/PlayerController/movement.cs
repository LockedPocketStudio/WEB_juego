using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    Vector2 lastClick;
    bool moving;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
               
        }
        if(moving && (Vector2)transform.position != lastClick)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClick, step);
        }
        else
        {
            moving = false;
        }
    }
}
