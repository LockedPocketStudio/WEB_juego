using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveClick : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask capaTransitable;
    private NavMeshAgent miAgente;
    private Ray miRayo;

    private RaycastHit infomacionDelRayo;
    // Start is called before the first frame update
    void Start()
    {
        miAgente = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            miRayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(miRayo, out infomacionDelRayo, 100, capaTransitable))
            {
                miAgente.SetDestination(infomacionDelRayo.point);
            }
        }
    }
}
