using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    protected Transform turretTransform;
    public GameObject bulletPrefab;

    public float fireCooldown;
    protected float fireCooldownLeft = 0f;

    public float radius;
    protected Transform radiusSprite;

    public int bulletDamage = 1;
    public int bulletHealth = 1;

    protected bool placed = false;
    // Start is called before the first frame update
   protected virtual void Start()
    {
        turretTransform = transform.Find("Jugador");
      //  radiusSprite = transform.Find("Radius");
        Vector3 radiusScale = new Vector3(radius * 2, radius * 2, 1);
      //radiusSprite.localScale = radiusScale;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        turretTransform = transform.Find("Jugador");
        // Enemy furthestEnemy = FindFurthestEnemy();
        /*
         if (furthestEnemy == null)
         {
             // No enemies
             return;
         }

         if (fireCooldownLeft <= 0)
         {
             fireCooldownLeft = fireCooldown;
             ShootAt(furthestEnemy);
         }*/

        fireCooldownLeft -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy furthestEnemy = null;

        if (other.gameObject.tag == "Enemy")
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            // If we collided with an enemy, check if it's distanced traveled
            if (furthestEnemy == null)
            {
                furthestEnemy = e;
            }

            if (fireCooldownLeft <= 0)
            {
                fireCooldownLeft = fireCooldown;
                ShootAt(furthestEnemy);
            }
            
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
        PointTurretAt(e);
       Quaternion rot = new Quaternion(90, 0, 0 , 90);


        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
        bullet b = bulletGO.GetComponent<bullet>();
        b.dir = e.transform.position - this.transform.position;
        b.damage = bulletDamage;
        b.health = bulletHealth;
    }
    protected void PointTurretAt(Enemy e)
    {
     /*   // Find direction to enemy
        Vector3 dir = e.transform.position - this.transform.position;
        // Calculate angle to enemy
        Quaternion lookRot = Quaternion.LookRotation(dir, Vector3.up);

        // Turn turret to enemy
        float rotation = lookRot.eulerAngles.x + 90f;
        if (lookRot.eulerAngles.y != 270)
        {
            rotation = -lookRot.eulerAngles.x - 90f;
        }
      //  turretTransform.rotation = Quaternion.Euler(0, 0, rotation);
    */}
}


