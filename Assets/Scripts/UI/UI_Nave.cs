using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Nave : MonoBehaviour
{
    public static UI_Nave instance;
    public TMP_Text textoDescripcion;
    public TMP_Text totalPiezas;

    public GameObject panel;
    public EventSystem controlador;
    public GameObject botonDefecto;

    public string[] nombrePiezas;

    private void Awake()
    {
        instance = this;
        controlador = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventSystem>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && GestorControles.instancia.controlTeclado)
        {
            MostrarMenu();
        }
    }

    public void ActualizarTextos(int contador, bool[] piezasConseguidas)
    {
        totalPiezas.text = "Total piezas - " + contador.ToString();
        textoDescripcion.text = "";
        int numero = 0;
        for(int i=0; i<piezasConseguidas.Length; i++)
        {
            if (piezasConseguidas[i])
            {
                if(numero!=0)
                {
                    textoDescripcion.text += ", ";
                }
                textoDescripcion.text += nombrePiezas[i];
                numero++;
            }
        }
    }

    public void Salir()
    {
        panel.SetActive(false);
        GestorControles.instancia.IniciarJuego();
    }

    public void MostrarMenu()
    {
        if(!GestorControles.instancia.juegoDetenido)
        {
            panel.SetActive(true);
            if (GestorControles.instancia.controlMando)
            {
                controlador.firstSelectedGameObject = botonDefecto;
                botonDefecto.GetComponent<Button>().Select();
            }
            GestorControles.instancia.DetenerJuego();
        }
        
    }

}
