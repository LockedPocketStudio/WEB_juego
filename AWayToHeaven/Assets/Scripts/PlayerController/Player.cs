using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
  //  protected Transform turretTransform;
    public GameObject bulletPrefab;
 

    public float fireCooldown = 2f;
    public float fireCooldownLeft = 1f;

    public float radius = 5f;
    //  protected Transform radiusSprite;

    //Control bala
    public int bulletDamage = 1;
    public int bulletHealth = 1;

    //Sierra
    public GameObject[] Sierras = new GameObject[4];

    //Control estadisticas Personaje
    public int life = 3; //salud en tiempo real
    public int BaseLife = 3; //salud maxima
    public float InvencibleTime = 2;
    public float InvencibleTimeLeft = 0f;
    public int experiencia = 0;

    //Control power ups
    public int nivelSierra = 0;
    protected int nivelSierraAnterior = 0;

    //Experiencia necesaria para power ups
    protected int[] LevelUp = {5,10,20,40,60,80};
    protected int nextLevel = 0;

    protected  void Start()
    {
   
     for(int i = 0; i < 4; i++)
        {
          Sierras[i].SetActive(false);
        }
     
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    
        fireCooldownLeft -= Time.deltaTime;
        if(experiencia == LevelUp[nextLevel])
        {
            nivelSierra++;
            nextLevel++;
        }
      if(nivelSierra != nivelSierraAnterior)
        {
            PowerUpSierra(nivelSierra);
            nivelSierraAnterior = nivelSierra;
        }
    }

    protected Enemy FindFurthestEnemy()
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

    protected void PowerUpSierra(int nivel)
    {
        switch (nivel)
        {
            case 1:
              Sierras[0].SetActive(true);
                break;
            case 2:
                Sierras[0].SetActive(false);
                Sierras[0].SetActive(true);
                Sierras[1].SetActive(true);
                break;
            case 3:
                Sierras[0].SetActive(false);
                Sierras[0].SetActive(true);
                Sierras[1].SetActive(false);
                Sierras[1].SetActive(true);
                Sierras[2].SetActive(true);
                break;
            case 4:
                Sierras[0].SetActive(false);
                Sierras[0].SetActive(true);
                Sierras[1].SetActive(false);
                Sierras[1].SetActive(true);
                Sierras[2].SetActive(false);
                Sierras[2].SetActive(true);
                Sierras[3].SetActive(true);
                break;
        }
           
        

       


    }

    

}
