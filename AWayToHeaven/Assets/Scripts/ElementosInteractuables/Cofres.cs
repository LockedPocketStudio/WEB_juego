using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    #region variables

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            Player e = collision.gameObject.GetComponent<Player>();
            if(e.LevelUp == true)
            {
                e.GetPower();
                Player.experiencia = 0;
                e.BarraExp.fillAmount = 0;
                Player.nivelHistoria++;
                e.LevelUp = false;
           //     Destroy(this);
            }
        }
    }
}
