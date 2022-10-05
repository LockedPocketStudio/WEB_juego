using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlayer : Player
{
   
    protected override void Update()
    {
        base.Update();

       
        Enemy furthestEnemy = FindFurthestEnemy();

        if (furthestEnemy == null)
        {
            return;
        }

        if (fireCooldownLeft <= 0 && furthestEnemy!= null)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(furthestEnemy);
        }
    }

    protected override void ShootAt(Enemy e)
    {
        base.ShootAt(e);

        // Create bullet
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, rot);
        bullet b = bulletGO.GetComponent<bullet>();
        b.dir = e.transform.position - this.transform.position;
        b.damage = bulletDamage;
        b.health = bulletHealth;
    }

  
}
