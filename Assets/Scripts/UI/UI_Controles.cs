using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Controles : MonoBehaviour
{
    public TMP_Text controlInventario;
    public TMP_Text controlControles;
    public TMP_Text controlOpciones;

    public GameObject panelControles;

    public ControlesMando controlesMando;

    public EventSystem controlador;
    public GameObject botonDefecto;

    private void Awake()
    {
        controlesMando = new ControlesMando();
        controlesMando.Enable();
        controlesMando.ControlesGamepad.Controles.performed += ctx => ComprobarControles();

        controlador = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventSystem>();
    }
    void Update()
    {
          if(Input.GetKeyDown(KeyCode.Q)&&GestorControles.instancia.controlTeclado)
          {
              MostrarMenu();
          }
     
    }



    public void ComprobarControles()
    {
        if(GestorControles.instancia.controlMando)
        {
            MostrarMenu();
        }
    }

    public void CambiarControlAMando()
    {
        // Modificar el texto con los controles
        controlInventario.text = "L1 - Abrir inventario";
        controlControles.text = "L2 - Menu de controles";
        controlOpciones.text = "R1 - Menu de opciones";

        // Modificar variables globales
        GestorControles.instancia.controlMando = true;
        GestorControles.instancia.controlTeclado = false;
    }

    public void CambiarControlATeclado()
    {
        // Modificar el texto con los controles
        controlInventario.text = "Tab - Abrir inventario";
        controlControles.text = "Q - Menu de controles";
        controlOpciones.text = "E - Menu de opciones";

        // Modificar variables globales
        GestorControles.instancia.controlMando = false;
        GestorControles.instancia.controlTeclado = true;
    }

    public void OcultarMenu()
    {
        panelControles.SetActive(false);
        GestorControles.instancia.IniciarJuego();
    }

    public void MostrarMenu()
    {
      
        if(!GestorControles.instancia.juegoDetenido)
        {
            panelControles.SetActive(true);
            if (GestorControles.instancia.controlMando)
            {
                controlador.firstSelectedGameObject = botonDefecto;
                botonDefecto.GetComponent<Button>().Select();
            }
            GestorControles.instancia.DetenerJuego();
        }
        }

    

}
