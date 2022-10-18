using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
   private Vector3 Playerpos;
    public GameObject player;
    public GameManager GM;
    void Start()
    {
        Playerpos = player.transform.position;
        this.transform.position = Playerpos;
    }

    // Update is called once per frame
    void Update()
    {
        Playerpos = player.transform.position;
        this.transform.position = Playerpos;
    }

    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "Enemy")
        {

            Player e = player.GetComponent<Player>();
            if (e.InvencibleTimeLeft <= 0)
            {
                e.life--;
                e.InvencibleTimeLeft = e.InvencibleTime;
                
                Debug.LogWarning("He perdido una vida");
            }
            if (e.life <= 0)
            {
          
               Destroy(e);
               
                GM.PlayerState(-1);
                Destroy(this);
            }

        }
        if (c.gameObject.tag == "Experiencia")
        {
            Player e = player.GetComponent<Player>();
            GameObject exp = c.GetComponent<GameObject>();
            e.experiencia++;
            Destroy(exp);
        }

    }
}
