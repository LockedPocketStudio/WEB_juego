using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

    #region variables

    public GameManager GM;
    //  protected Transform turretTransform;
    public GameObject bulletPrefab;


    public float fireCooldown = 0.75f;
    public float fireCooldownLeft = 1f;

    public float radius = 5f;
    //  protected Transform radiusSprite;

    //Control bala
    public int bulletDamage = 1;
    public int bulletHealth = 1;

    //Sierra
    public GameObject[] Sierras = new GameObject[4];
    

    //Control estadisticas Personaje
    public int VidaActual = 3; //salud en tiempo real
    public int VidaMaxima = 3; //salud maxima
    public Image BarraVida;
    public float InvencibleTime = 2;
    public float InvencibleTimeLeft = 0f;
    public Image BarraExp;
    public static int experiencia = 0;

    //Control power ups

    public int nivelSierra = 0;
    protected int nivelSierraAnterior = 0;

    //Experiencia necesaria para power ups
   
    public List<int> LevelUpReq = new List<int>();
    protected int nextLevel = 0;

    //Define el power up que ha tocado
    public int AleatorioPowerUps;

    //Nivel Del power up
    public Image[] PowersUP = new Image[7];
    public float tImage = 3;
    public float tLeft = 0;
    public int ImagenActivada = 0; //0- false 1-true
    public int NImagenActiva;
    public static int velocidadDisparo = 0; //0
    public static int dobleDisparo = 0; public  int CantidadDisparo = 1; //1
    public static int Masvida = 0; //2
    public static int recuperarvida = -1; //3
    public static int controlsierra = 0;  //4
    public static int aumentarDanodisparo = 0; //5
    public static int aumentarAlcance = 0;  //6
    public static int aumentarVelocidadMovimiento = 0;  //7
    public static int[] Powers = { 0, 0, 0, 0, 0, 0, 0, 0 };
    public GameObject Ayuda;
    public TextMeshProUGUI AyudaPower;

    //Control del Modo historia
    public static int nivelHistoria =0 ;
    public bool LevelUp = false;

    #endregion

    #region Unity
    protected void Start()
    {
        for(int i = 0; i < PowersUP.Length; i++)
        {
            PowersUP[i].gameObject.SetActive(false);
        }
        /*
         for (int i=2;i<160;i = i * 2)
         {
             LevelUpReq.Add(i);
         }*/
        if(GM.modoJuego == 1)
        {
            for (int i = 2; i < 20; i += 2)
            {
                LevelUpReq.Add(i);
            }

        }
        else  //Modo historia
        {
           
                LevelUpReq.Add(1); //Cada 10 niveles un power up;
            
            
        }


        for (int i = 0; i < 4; i++)
        {
          Sierras[i].SetActive(false);
        }
        BarraExp.fillAmount = experiencia;
        Ayuda.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    
        fireCooldownLeft -= Time.deltaTime;
        BarraVida.fillAmount = (float)VidaActual / VidaMaxima;
        if(experiencia != 0)
        {
            BarraExp.fillAmount = (float)experiencia / LevelUpReq[0];
        }
     if(ImagenActivada == 1)
        {
            tLeft += Time.deltaTime;
            if(tLeft >= tImage)
            {
                PowersUP[NImagenActiva].gameObject.SetActive(false);
                Ayuda.SetActive(false);
                tLeft = 0;
            }
        }
       /*

      if(nivelSierra != nivelSierraAnterior)
        {
            PowerUpSierra(nivelSierra);
            nivelSierraAnterior = nivelSierra;
        }*/
      if(LevelUpReq[0] <= experiencia && GM.modoJuego ==1)
        {
          GetPower();
            LevelUpReq.RemoveAt(0);
            experiencia = 0;
            BarraExp.fillAmount = 0;
        }

        if (LevelUpReq[0] <= experiencia && GM.modoJuego == 0)
        {
            LevelUp = true;
        }
    }
    #endregion
  /*  protected Enemy FindFurthestEnemy()
    {
        
        // Create sphere collider of radius
        Enemy furthestEnemy = null;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in cols)
        {
            if (c.gameObject.tag == "Enemy")
            {
                Enemy e = c.gameObject.GetComponent<Enemy>();
                // If we collided with an enemy, check if it's distanced traveled
                if (furthestEnemy == null )
                {
                    furthestEnemy = e;
                }
            }
        }

        return furthestEnemy;
    }*/

    protected List<Enemy> FindFurthestEnemy()
    {
        List<Enemy> list = new List<Enemy>();

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D c in cols)
        {
            if (c.gameObject.tag == "Enemy")
            {
                list.Add(c.gameObject.GetComponent<Enemy>());
            }
        }


        return list;
    }

   
    protected virtual void ShootAt(Enemy e)
    {
      //  PointTurretAt(e);
    }

    protected void PointTurretAt(Enemy e)
    {
        /*
        // Find direction to enemy
        Vector3 dir = e.transform.position - this.transform.position;
        // Calculate angle to enemy
        Quaternion lookRot = Quaternion.LookRotation(dir, Vector3.up);

        // Turn turret to enemy
        float rotation = lookRot.eulerAngles.x + 90f;
        if (lookRot.eulerAngles.y != 270)
        {
            rotation = -lookRot.eulerAngles.x - 90f;
        }
       // turretTransform.rotation = Quaternion.Euler(0, 0, rotation);*/
    }

  

    #region PowerUps


    public void AumentarVelocidadDisparo(int n)
    {
        
    
        fireCooldown -= 0.15f;
        AyudaPower.text=("AumentarVelocidadDisparo: "+n);


    }
    public void DobleDisparo(int n)
    {
        CantidadDisparo++;
        AyudaPower.text = ("DobleDisparo: " + n);
    }
    public void MasVida(int n)
    {
        VidaMaxima++;
        VidaActual++;
        AyudaPower.text = ("Aumento de Vida");
    }
    public void RecuperarVida()
    {
        VidaActual = VidaMaxima;
        AyudaPower.text = ("Recuperar vida");
    }
    public void AumentarDanoDisparo(int n)
    {
        bulletDamage++;
        AyudaPower.text = ("AumentarDano: "+n);
    }
    public void AumentarAlcance(int n)
    {
        radius++;
        AyudaPower.text = ("AumentarAlcanze: " + n);
    }
   
    public void AumentarVelocidadMovimiento(int n)
    {
        AyudaPower.text = ("AumentarVelocidadMovimiento: " + n);
    }
    protected void PowerUpSierra(int nivel)
    {
        switch (nivel)
        {
            case 1:
                Sierras[0].SetActive(true);
                break;
            case 2:
                //   Sierras[0].SetActive(false);
                // Sierras[0].SetActive(true);
                Sierras[1].SetActive(true);
                PathSierra s = Sierras[0].GetComponent<PathSierra>();
                PathSierra s1 = Sierras[1].GetComponent<PathSierra>();
                s.Colocar(0);
                s1.Colocar(1);
                break;
            case 3:
                Sierras[0].SetActive(false);
                Sierras[0].SetActive(true);
                Sierras[1].SetActive(false);
                Sierras[1].SetActive(true);
                Sierras[2].SetActive(true);
                PathSierra s_1 = Sierras[0].GetComponent<PathSierra>();
                PathSierra s1_1 = Sierras[1].GetComponent<PathSierra>();
                PathSierra s2_1 = Sierras[2].GetComponent<PathSierra>();
                s_1.Colocar(0);
                s1_1.Colocar(1);
                s2_1.Colocar(2);
                break;
            case 4:
                Sierras[0].SetActive(false);
                Sierras[0].SetActive(true);
                Sierras[1].SetActive(false);
                Sierras[1].SetActive(true);
                Sierras[2].SetActive(false);
                Sierras[2].SetActive(true);
                Sierras[3].SetActive(true);
                PathSierra s_2 = Sierras[0].GetComponent<PathSierra>();
                PathSierra s1_2 = Sierras[1].GetComponent<PathSierra>();
                PathSierra s2_2 = Sierras[2].GetComponent<PathSierra>();
                PathSierra s3_2 = Sierras[3].GetComponent<PathSierra>();
                s_2.Colocar(0);
                s1_2.Colocar(1);
                s2_2.Colocar(2);
                s3_2.Colocar(3);
                break;
        }
        AyudaPower.text = ("Sierra: " + nivel);


    }

    public void GetPower()
    {
        
        int random = (int)Random.Range(0, 7);

        if (random != 3)
        {
            while (Powers[random] == 4)
            {
                random = (int)Random.Range(0, 5);
            }
            Powers[random]++;
        }

        //modo debug 
      //  int random = 1;
      //  Powers[random]++;
        //fin 

        switch (random)
        {
            case 0:
                AumentarVelocidadDisparo(Powers[random]);
                break;
            case 1:
                DobleDisparo(Powers[random]);
                break;
            case 2:
                MasVida(Powers[random]);
                break;
            case 3:
                RecuperarVida();
                break;
            case 4:
                PowerUpSierra(Powers[random]);
                break;
              
            case 5:
                AumentarDanoDisparo(Powers[random]);
                break;
            case 6:
                AumentarAlcance(Powers[random]);
                break;
                /*
          case 7:
              AumentarVelocidadMovimiento(Powers[random]);
              break;*/
        }
        PowersUP[random].gameObject.SetActive(true);
        Ayuda.SetActive(true);
        NImagenActiva = random;
        ImagenActivada = 1;
    }
    #endregion
    
}
