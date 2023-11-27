using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    public Vector3 distancia;

    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position - objetivo.position;
    }

    void FixedUpdate()
    {
        transform.position = distancia + objetivo.position;
    }
}
