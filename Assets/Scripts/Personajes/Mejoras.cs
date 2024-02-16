using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejoras : MonoBehaviour
{
    public float rango;
    public GameObject iconoTexto;
    public bool interactuable;
    public GameObject panelCultivos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarInteractuable();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (interactuable)
            {
                if(UI_Objetivos.instance.hablarVendedor==1)
                {
                    UI_Objetivos.instance.hablarVendedor++;
                    UI_Objetivos.instance.CambiarObjetivo(3);
                }
                UI_Dialogos.instance.MostrarDialogo(17);
                panelCultivos.SetActive(true);
            }
        }
    }

    public void ComprobarInteractuable()
    {
        if (Vector3.Distance(transform.position, MovimientoPersonaje.instancia.posicionActual) <= rango)
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

    public void CambiarProbabilidad()
    {
        if(Inventario.instance.dinero >= 20 && GestorRecursos.instancia.probabilidad>1)
        {
            Inventario.instance.AumentarDinero(-20);
            GestorRecursos.instancia.probabilidad -= 2;
            UI_Dialogos.instance.MostrarDialogo(18);
        }
        else
        {
            UI_Dialogos.instance.MostrarDialogo(19);
        }
    }




    public void Salir()
    {
        panelCultivos.SetActive(false);
    }
}
