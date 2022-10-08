using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    
   /* public void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.tag == "PlayerCollider")
        {
           
           Player e = c.gameObject.GetComponent<Player>();
            if (e.InvencibleTimeLeft <= 0)
            {
                e.life--;
                e.InvencibleTimeLeft = e.InvencibleTime;
                Debug.LogWarning("He perdido una vida");
            }
            if (e.life <= 0)
            {
                Destroy(e.gameObject);
            }

        }
       
    }*/
}
