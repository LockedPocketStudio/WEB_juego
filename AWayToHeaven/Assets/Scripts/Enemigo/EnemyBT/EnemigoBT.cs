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

    //  protected Transform turretTransform;
    public GameObject bulletPrefab;

    //Control bala
    public int bulletDamage = 1;
    public int bulletHealth = 1;

    //árbol de comportamiento
    private BehaviourTreeEngine behaviourTree;

    [Header("Variables de control")]
    [SerializeField] private string nodoActual;

    //Percepciones
    public bool veJugador = false;
    public bool haAvanzado = false;
    public bool haDisparado = false;

    //Otras variables
    private int health = 1;
    private float speed = 6f;
    //private float changeDir = 1f; //El enemigoBT cambiará la dirección en la que anda cada 1 segundos
    //private float walkingTime = 0f; 
    public GameManager GM;
   
    #endregion variables
    
    // Start is called before the first frame update
    void Start()
    {
        CreateBehaviourTree();
    }

    private void CreateBehaviourTree()
    {
        behaviourTree = new BehaviourTreeEngine();

        //Leaf Nodes
        LeafNode jugadorNode = behaviourTree.CreateLeafNode("Ve al jugador", () => moving(), comprobarJugadorVisible); //(name, action, evaluation function)
        LeafNode disparaNode = behaviourTree.CreateLeafNode("Dispara al jugador", () => ShootAt(jugador), yaHaDisparado);
        LeafNode patrullaNode = behaviourTree.CreateLeafNode("Patrullar", () => moving(), haPatrullado);

        //Sequence node
        SequenceNode sequenceRoute = behaviourTree.CreateSequenceNode("Sequence route", false); //es false para que los nodos hijos se recorran en el orden
                                                                                                //en el que se han añadido
        sequenceRoute.AddChild(jugadorNode);
        sequenceRoute.AddChild(disparaNode);     
        
        //Primer selector node
        SelectorNode selectorRoute = behaviourTree.CreateSelectorNode("Selector route");
        selectorRoute.AddChild(sequenceRoute);
        selectorRoute.AddChild(patrullaNode);

        LoopDecoratorNode loopNode = behaviourTree.CreateLoopNode("Loop root", selectorRoute);

        behaviourTree.SetRootNode(loopNode);
    }

    // Update is called once per frame
    void Update()
    {
        //si el jugador muere, el enemigo para de actualizarse
        if(GM.estadoJugador != 1)
        {
            return;
        }
        behaviourTree.Update();
        
    }

    //Acciones
    private void moving()
    {
        haDisparado = false;

        Debug.Log("enemyBT is moving");

            //Se mueve de forma aleatoria
            Vector2 posInicial = transform.position;
            float step = speed * Time.deltaTime;
            float x = Range(-2f, 2f);
            float y = Range(-2f, 2f);
            Vector2 nextPos = new Vector2(x, y);
            Debug.Log("NEXT POS " + nextPos);
            transform.position = Vector2.MoveTowards(transform.position, nextPos, step);    //MoveTowards(posicion actual, destino, distancia máxima)
            Vector2 posFinal = transform.position;


            //Comprobar si el movimiento se ha realizado correctamente
            if ((posInicial != posFinal))
            {
                Debug.Log("Ha avanzado");
                haAvanzado = true;
            }
            else
            {
                Debug.Log("NO ha avanzado");
                haAvanzado = false;
            }
    
    }

    private void ShootAt(GameObject p)  
    {
        //base.ShootAt(p);

        Debug.Log("enemyBT is SHOOTING");

        // Create bullet
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
        bullet b = bulletGO.GetComponent<bullet>();
        b.dir = p.transform.position - this.transform.position;
        b.damage = bulletDamage;
        b.health = bulletHealth;

        haAvanzado = false;
        haDisparado = true;

    }


    //Evaluaciones

    private ReturnValues comprobarJugadorVisible()
    {

        Debug.Log("enemyBT is CHECKING PLAYERS POSITION");

        float distanceTo = Vector2.Distance(jugador.transform.position, transform.position);
        //Debug.Log("-----El enemigo está a distancia" + distanceTo);   //comprobar que la distancia se está calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le verá y comenzará a acercarse a él.
        if(distanceTo <= 5){
            Debug.Log("player VISIBLE");
            veJugador = true;
            return ReturnValues.Succeed;
        }
        else
        {
            Debug.Log("player NOT VISIBLE");
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
