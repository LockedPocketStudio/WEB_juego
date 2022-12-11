using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class movement : MonoBehaviour, IPointerDownHandler
{
    public float speed = 3f;
    Vector2 lastClick;
    bool moving;
    public bool puedeMoverse =false;
    public GameManager GM;


   public Button Mover;
    //Animacion
    Animator animacion;
    SpriteRenderer sprite;
    private Vector2 destinoAnterior;

    public bool hacerRuido = false;

    void Start()
    {
        animacion = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
        Mover.onClick.AddListener(() => Puede());
       
        //PointerEventData a;
      // Mover.OnPointerDown(a);


    }

    
    public void Movera(Vector2 a)
    {


        lastClick = a;
       /*
        if (moving && (Vector2)transform.position != a)
        {
            float step = speed * Time.deltaTime;
            destinoAnterior = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, a, step);
/*
            if (transform.position.x > destinoAnterior.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }*/
       // }
        /*else
        {
            moving = false;
        }
        if (moving == true)
        {
            animacion.SetBool("mov", true);
        }
        else
        {
            animacion.SetBool("mov", false);
        }*/
    }

    public void Puede()
    {
        if(GM.modoJuego != -1) {
            puedeMoverse = true;
            lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.modoJuego == -1)
        {
            if (!animacion.GetBool("Muerte")) 
            animacion.enabled = false;

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
        if (animacion.enabled == false)
            animacion.enabled = true;

      
        //if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))  && puedeMoverse == true)
        if(puedeMoverse){
         //   lastClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            puedeMoverse = false;
        }
        if (Input.touchCount > 0 && puedeMoverse == true) //Control del movil
        {
            Touch touch = Input.GetTouch(0);
              lastClick = Camera.main.ScreenToWorldPoint(touch.position);
            moving = true;
        }
        
        if (moving && (Vector2)transform.position != lastClick)
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

            hacerRuido = true;
        }
        else
        {
            moving = false;
            hacerRuido = false;
        }
        
        
         
        
        if(moving == true)
        {
            animacion.SetBool("mov", true);
        }
        else{
            animacion.SetBool("mov", false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Puede();
    }
}
