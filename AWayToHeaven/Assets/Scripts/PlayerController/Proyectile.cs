using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Create(Vector3 spawnPosition)
    {
        Instantiate(GameManager.i.pfFireBall, spawnPosition, Quaternion.identity);
    }
}
