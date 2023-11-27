using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeInteractuable : MonoBehaviour
{
    public float rango;
    public GameObject iconoTexto;
    public bool interactuable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarInteractuable();
    }

    public void ComprobarInteractuable()
    {
        if(Vector3.Distance(transform.position, MovimientoPersonaje.instancia.posicionActual)<=rango)
        {
            interactuable = true;
            iconoTexto.SetActive(true);
        }
        else
        {
            interactuable = false;
            iconoTexto.SetActive(false);
        }
    }
}
