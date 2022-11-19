using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 3f;
    Vector2 lastClick;
    bool moving;
    public GameManager GM;

    //Animacion
    Animator animacion;
    SpriteRenderer sprite;
    private Vector2 destinoAnterior;

    void Start()
    {
        animacion = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.modoJuego == -1)
        {
            return;
        }
        if(GM.estadoJugador == -1)
        {
            return;
        }
        if(GM.modoJuego ==1 && GM.ModoHordasDificultad == -1)
        {
            return;
        }
        if (GM.modoJuego == 3)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
               
        }
        if (Input.touchCount > 0) //Control del movil
        {
            Touch touch = Input.GetTouch(0);
              lastClick = Camera.main.ScreenToWorldPoint(touch.position);
            moving = true;
        }
        if(moving && (Vector2)transform.position != lastClick)
        {
            float step = speed * Time.deltaTime;
            destinoAnterior = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, lastClick, step);

            if (transform.position.x > destinoAnterior.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else
        {
            moving = false;
        }
        if(moving == true)
        {
            animacion.SetBool("mov", true);
        }
        else{
            animacion.SetBool("mov", false);
        }
    }
}
