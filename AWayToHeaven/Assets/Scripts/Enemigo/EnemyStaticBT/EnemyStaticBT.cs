using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyStaticBT : MonoBehaviour
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

    //�rbol de comportamiento
    private BehaviourTreeEngine behaviourTree;

    [Header("Variables de control")]
    [SerializeField] private string nodoActual;

    //
    public bool veJugador = false;
   // public bool haAvanzado = false;
    //public bool haDisparado = false;

    public bool JugadorRango = false;
    private Vector2 destino;    //la posicion del jugador en ese momento

    //Otras variables
    private int health = 1;
    private float speed = 4f;
    public GameObject c;
    VisorEnemigo visor;

    #endregion variables




    // Start is called before the first frame update
    void Start()
    {
        //Buscar objetos de la escena 
        GM = GameManager.FindObjectOfType<GameManager>();
        jugador = GameObject.Find("Player");
        var ene = this.GetComponent<Enemy>();
        ene.Esestatico(true);
        visor = this.GetComponent<VisorEnemigo>();
        CreateBehaviourTree();
    }

    public void CreateBehaviourTree()
    {
        behaviourTree = new BehaviourTreeEngine();

        //Leaf Nodes
        LeafNode jugadorRangoNode = behaviourTree.CreateLeafNode("Rango", () => { JugadorRango = true; } , comprobarJugadorVisible);
        LeafNode ComprobacionArmaNode = behaviourTree.CreateLeafNode("armaRecargada", () => { }, comprobarArmaRecargada); //(name, action, evaluation function)
        LeafNode RecargaNode = behaviourTree.CreateLeafNode("Recargar", () => Recargar(), comprobarRecargada);
        LeafNode disparaNode = behaviourTree.CreateLeafNode("Disparar", () => ShootAt(jugador), comprobarJugadorVisible);
        TimerDecoratorNode timer = behaviourTree.CreateTimerNode("timer", RecargaNode, 2);

        //Sequence node
        SequenceNode sequenceRoute = behaviourTree.CreateSequenceNode("Sequence route", false); //es false para que los nodos hijos se recorran en el orden
        SelectorNode selectorNode = behaviourTree.CreateSelectorNode("selecion");                                                                                   //en el que se han a�adido

        
        //SelectorNode
        selectorNode.AddChild(ComprobacionArmaNode);
        selectorNode.AddChild(timer);
       


        //A�adir secuencia
        sequenceRoute.AddChild(jugadorRangoNode);
        sequenceRoute.AddChild(selectorNode);
        sequenceRoute.AddChild(disparaNode);


        //Primer selector node

        LoopDecoratorNode loopNode = behaviourTree.CreateLoopNode("Loop root", sequenceRoute);

        behaviourTree.SetRootNode(loopNode);
    }
   
    private ReturnValues comprobarJugadorVisible()
    {

      //  Debug.Log("enemyBT is CHECKING PLAYERS POSITION");

        float distanceTo = Vector2.Distance(destino, transform.position);
        //Debug.Log("-----El enemigo est� a distancia" + distanceTo);   //comprobar que la distancia se est� calculando correctamente 

        //Si el jugador se encuentra a una distancia menos de X del enemigo, el enemigo le ver� y comenzar� a acercarse a �l.
       // if (distanceTo <= 100)
        if(visor.detected ==true)
        {
      //  Debug.Log("player VISIBLE");
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
    private ReturnValues comprobarArmaRecargada()
    {
        var a = this.GetComponent<Enemy>();
        int recarga = a.bala;
        if(recarga == 0)
        {
        //    Debug.Log("No hay bala , RECARGAR");
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
           // Debug.Log("Tengo el arma recargada");
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
    private void ShootAt(GameObject p)
    {
        //Script DisparoAl
        //base.ShootAt(p);

      //  Debug.Log("enemyBT is SHOOTING");

        // Create bullet
        //Quaternion rot = new Quaternion(0, 0, 0, 0);
     

        //(GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
        /*
        Color a = new Color(255,0,0,0);
        SpriteRenderer a2 = c.GetComponent<SpriteRenderer>();
        a2.Color = a;
        */
        /*
        EnemyBullet b = bulletGO.GetComponent<EnemyBullet>();
        b.dir = p.transform.position - this.transform.position;
        b.damage = bulletDamage;
        b.health = bulletHealth;

        var go=this.GetComponent<GameObject>();
        Destroy(this.gameObject);
        Debug.LogWarning("rompe");

        var a = this.GetComponent<Enemy>();
        a.bala = 0; 


        haAvanzado = false;
        haDisparado = true;*/

   

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
        if (GM.modoJuego == 3)
        {
            return;
        }

        destino = jugador.transform.position;
        behaviourTree.Update();

    }
}
