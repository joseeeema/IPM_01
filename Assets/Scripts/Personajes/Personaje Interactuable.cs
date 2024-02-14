using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeInteractuable : MonoBehaviour
{
    public float rango;
    public GameObject iconoTexto;
    public bool interactuable;
    public GameObject panelPiezas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarInteractuable();
        if(Input.GetKeyDown(KeyCode.Space) )
        {
            if(interactuable)
            {
                UI_Dialogos.instance.MostrarDialogo(4);
                if(UI_Objetivos.instance.hablarPiezas==1)
                {
                    UI_Objetivos.instance.hablarPiezas++;
                    UI_Objetivos.instance.avisosVisuales[2].SetActive(false);
                }
                panelPiezas.SetActive(true);
            }
        }
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

    public void Salir()
    {
        panelPiezas.SetActive(false);
    }
}
