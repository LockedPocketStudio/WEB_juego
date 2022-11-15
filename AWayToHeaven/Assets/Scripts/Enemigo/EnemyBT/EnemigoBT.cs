using System;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBT : MonoBehaviour
{
    
    #region variables
    [Header("Destinos")]
    public GameObject jugador;
    public GameManager GM;

    //  protected Transform turretTransform;
    public GameObject bulletPrefab;

    //Control bala
    public int bulletDamage = 1;
    public int bulletHealth = 1;

    //árbol de comportamiento
    private BehaviourTreeEngine behaviourTree;

    [Header("Variables de control")]
    [SerializeField] private string nodoActual;

    //
    public bool veJugador = false;
    public bool haAvanzado = false;
    public bool haDisparado = false;
    private Vector2 destino;    //la posicion del jugador en ese momento

    //Otras variables
    private int health = 1;
    private float speed = 2f;

    //Control sprite
    SpriteRenderer sprite;
    private Vector2 destinoAnterior;

    #endregion variables

    // Start is called before the first frame update
    void Start()
    {
        //Buscar objetos de la escena 
        GM = GameManager.FindObjectOfType<GameManager>();
        jugador = GameObject.Find("Player");

        //Coger sprite
        sprite = this.GetComponent<SpriteRenderer>();


        CreateBehaviourTree();
    }

    private void CreateBehaviourTree()
    {
        behaviourTree = new BehaviourTreeEngine();

        //Leaf Nodes
        LeafNode jugadorNode = behaviourTree.CreateLeafNode("Ve al jugador", () => moving(), comprobarJugadorVisible); //(name, action, evaluation function)
                                                                                                                       // LeafNode disparaNode = behaviourTree.CreateLeafNode("Dispara al jugador", () => ShootAt(jugador), yaHaDisparado);
                                                                                                                       //LeafNode patrullaNode = behaviourTree.CreateLeafNode("Patrullar", () => moving(), haPatrullado);
        LeafNode ComprobacionArmaNode = behaviourTree.CreateLeafNode("armaRecargada", () => { }, comprobarArmaRecargada); //(name, action, evaluation function)
        LeafNode RecargaNode = behaviourTree.CreateLeafNode("Recargar", () => Recargar(), comprobarRecargada);
        LeafNode disparaNode = behaviourTree.CreateLeafNode("Disparar", () => ShootAt(jugador), comprobarJugadorVisible);
        TimerDecoratorNode timer = behaviourTree.CreateTimerNode("timer", RecargaNode, 2);

        //Sequence node
        SequenceNode sequenceRoute = behaviourTree.CreateSequenceNode("Sequence route", false); //es false para que los nodos hijos se recorran en el orden
        SelectorNode selectorNode = behaviourTree.CreateSelectorNode("selecion");                                                                                            //en el que se han añadido
        //SelectorNode
        selectorNode.AddChild(ComprobacionArmaNode);
        selectorNode.AddChild(timer);



        //Añadir secuencia
        sequenceRoute.AddChild(jugadorNode);
        sequenceRoute.AddChild(selectorNode);
        sequenceRoute.AddChild(disparaNode);


        //Primer selector node

        LoopDecoratorNode loopNode = behaviourTree.CreateLoopNode("Loop root", sequenceRoute);

        behaviourTree.SetRootNode(loopNode);
    }

    // Update is called once per frame
    void Update()
    {
        //si el jugador muere, el enemigo para de actualizarse
        if (GM.estadoJugador != 1)
        {
            return;
        }


        if (GM.modoJuego == -1)
        {
            return;
        }

        if (GM.modoJuego == 1 && GM.ModoHordasDificultad == -1)
        {
            return;
        }
        behaviourTree.Update();

        actualizarDestino();
        moving();  //Para que solo se mueva si el jugador se encuenta a una distacia de 40
        
    }


    void actualizarDestino()
    {
        float PosAnterior = this.transform.position.x;
        destino = new Vector2(jugador.transform.position.x, jugador.transform.position.y);

        if (destino.x > PosAnterior)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
    private ReturnValues comprobarArmaRecargada()
    {
        var a = this.GetComponent<Enemy>();
        int recarga = a.bala;
        if (recarga == 0)
        {
            Debug.Log("No hay bala , RECARGAR");
            return ReturnValues.Failed;
        }
        else
        {
            return ReturnValues.Succeed;
        }
    }

    private ReturnValues comprobarRecargada()
    {
        var a = this.GetComponent<Enemy>();
        int recarga = a.bala;
        if (recarga == 1)
        {
            Debug.Log("Tengo el arma recargada");
            return ReturnValues.Succeed;
        }
        else
        {
            return ReturnValues.Failed;

        }
    }
    private void Recargar()
    {
        var a = this.GetComponent<Enemy>();
        a.bala = 1;
    }

    //Acciones
    private void moving()
    {
        haDisparado = false;

        // Debug.Log("enemyBT is moving");
        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("-----El enemigo está a distancia" + distanceTo);   //comprobar que la distancia se está calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le verá y comenzará a acercarse a él.
        if (distanceTo <= 20)
        {

            //Va hacia el jugador
            Vector2 posInicial = transform.position;
            float step = speed * Time.deltaTime;
            //     Debug.Log("step " + step);
            transform.position = Vector2.MoveTowards(transform.position, destino, step);    //MoveTowards(posicion actual, destino, distancia máxima)
            Vector2 posFinal = transform.position;

            if ((posInicial != posFinal))
            {
                //     Debug.Log("Ha avanzado");
                haAvanzado = true;
            }
            else
            {
                //      Debug.Log("NO ha avanzado");
                haAvanzado = false;
            }

        }
            //Comprobar si el movimiento se ha realizado correctamente
          
    
    }

    private void ShootAt(GameObject p)  
    {
        //base.ShootAt(p);

      //  Debug.Log("enemyBT is SHOOTING");

        // Create bullet
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
        EnemyBullet b = bulletGO.GetComponent<EnemyBullet>();
        b.dir = p.transform.position - this.transform.position;
        b.damage = bulletDamage;
        b.health = bulletHealth;

        var a = this.GetComponent<Enemy>();
        a.bala = 0;

        haAvanzado = false;
        haDisparado = true;

    }


    //Evaluaciones

    private ReturnValues comprobarJugadorVisible()
    {

       // Debug.Log("enemyBT is CHECKING PLAYERS POSITION");

        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("-----El enemigo está a distancia" + distanceTo);   //comprobar que la distancia se está calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le verá y comenzará a acercarse a él.
        if(distanceTo <= 20){
           // Debug.Log("player VISIBLE");
            veJugador = true;
            return ReturnValues.Succeed;
        }
        else
        {
         //   Debug.Log("player NOT VISIBLE");
            veJugador = false;
            return ReturnValues.Failed;
        }

    }

    private ReturnValues yaHaDisparado()
    {
        if(haDisparado == true)
        {
            return ReturnValues.Succeed;
        }
        else
        {
            return ReturnValues.Running;
        }

    }

    private ReturnValues haPatrullado()
    {
        if(haAvanzado == true)
        {
            return ReturnValues.Succeed;
        }
        else
        {
            return ReturnValues.Running;
        }
    }


    //Sistema de vida del enemigo
    public void TakeDamage(int amount)
    {
        //El enemigo muere cuando le alcanza una bala del jugador
        health = health - amount;
        if (health <= 0)
        {
            veJugador = false;
            Destroy(this.gameObject);
            
            return;
        }
    }


    
}
