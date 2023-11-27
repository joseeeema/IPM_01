using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventario : MonoBehaviour
{
    public static UI_Inventario instancia;
    public GameObject panelInventario;
    public Inventario jugador;
    public List <UI_Stacks> stacks = new List <UI_Stacks>();

    public GameObject aviso;

    public ControlesMando controlesMando;

    public EventSystem controlador;
    public GameObject botonDefecto;

    private void Awake()
    {
        instancia = this;

        controlesMando = new ControlesMando();
        controlesMando.Enable();
        controlesMando.ControlesGamepad.Inventario.performed += ctx => ComprobarInventario();

        controlador = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)&&GestorControles.instancia.controlTeclado)
        {
            MostrarInventario();
        }
    }

    public void ComprobarInventario()
    {
        if(GestorControles.instancia.controlMando)
        {
            MostrarInventario();
        }
    }

    public void MostrarInventario()
    {
        if(!GestorControles.instancia.juegoDetenido)
        {
            panelInventario.SetActive(true);
            if (GestorControles.instancia.controlMando)
            {
                controlador.firstSelectedGameObject = botonDefecto;
                botonDefecto.GetComponent<Button>().Select();
            }
            GestorControles.instancia.DetenerJuego();
            aviso.SetActive(false);
            ActualizarInterfaz();
        }
    }

    public void OcultarInventario()
    {
        panelInventario.SetActive(false);
        GestorControles.instancia.IniciarJuego();
    }

    public void ActualizarInterfaz()
    {
        if(stacks.Count == jugador.gestorInventario.lotes.Count)
        {
            for(int i=0; i<stacks.Count; i++)
            {
                if (jugador.gestorInventario.lotes[i].tipo != TipoObjeto.NULL)
                {
                    stacks[i].SetItem(jugador.gestorInventario.lotes[i]);
                }
                else
                {
                    stacks[i].SetEmpty();
                }
            }
        }
    }
}
