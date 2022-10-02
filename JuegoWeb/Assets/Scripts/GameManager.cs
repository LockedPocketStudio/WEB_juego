using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Instancia del GameManager
    private static GameManager _i;

    public static GameManager i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameManager>("GameManager"));
            return _i;
        }
    }

    public Transform pfFireBall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
