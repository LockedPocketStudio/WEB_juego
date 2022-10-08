using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  //  protected Transform turretTransform;
    public GameObject bulletPrefab;
 

    public float fireCooldown;
    protected float fireCooldownLeft = 1f;

    public float radius;
  //  protected Transform radiusSprite;

    //Control bala
    public int bulletDamage = 1;
    public int bulletHealth = 1;

    //Control estadisticas Personaje
    public int life = 1;
    public float InvencibleTime = 2;
    public float InvencibleTimeLeft = 0f;

    protected virtual void Start()
    {
     // turretTransform = transform.Find("Player");
      //  radiusSprite = transform.Find("Radius");
    //    Vector3 radiusScale = new Vector3(radius * 2, radius * 2, 1);
      //  radiusSprite.localScale = radiusScale;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    
        fireCooldownLeft -= Time.deltaTime;
      //  InvencibleTimeLeft -= Time.deltaTime;
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

   

    

}
