using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UI_Opciones : MonoBehaviour
{
    public static UI_Opciones instance;

    public TMP_Text textoDialogos;
    public AudioMixer mezclador;
    public Image brillo;

    // Sliders
    public Slider sliderMusica;
    public Slider sliderBrillo;
    public Slider sliderSonido;

    public GameObject panel;

    public ControlesMando controlesMando;

    public EventSystem controlador;
    public GameObject botonDefecto;
    public int contador = 0;

    private void Awake()
    {
        controlesMando = new ControlesMando();
        controlesMando.Enable();
        controlesMando.ControlesGamepad.Opciones.performed += ctx => ComprobarOpciones();

        controlador = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& GestorControles.instancia.controlTeclado)
        {
            MostrarOpciones();
            contador++;
            if (Input.GetKeyDown(KeyCode.Escape)&&contador>1) {
                Salir();
                contador=0;
            }
        }
    }

    public void ComprobarOpciones()
    {
        if(GestorControles.instancia.controlMando)
        {
            MostrarOpciones();
        }
    }

    public void MostrarOpciones()
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

    public void AumentarTexto(int id)
    {
        if(id==0)
        {
            textoDialogos.fontSize = 30;
        }
        if(id==1)
        {
            textoDialogos.fontSize = 50;
        }
    }
    public void CambiarVolumenMusica(float volumenMusica)
    {
        mezclador.SetFloat("volumenMusica", volumenMusica);
    }

    public void CambiarVolumenSonido(float volumenSonido)
    {
        mezclador.SetFloat("volumenSonido", volumenSonido);
    }

    public void CambiarBrillo(float intensidad)
    {
        brillo.gameObject.SetActive(false);
        brillo.color = new Color(brillo.color.r, brillo.color.g, brillo.color.b, 1 - intensidad);
        brillo.gameObject.SetActive(true);
    }

    public void Salir()
    {
        panel.SetActive(false);
        GestorControles.instancia.IniciarJuego();
    }

    public void ModoDaltonico(int id)
    {
        ColorBlindFilter modo = Camera.main.GetComponent<ColorBlindFilter>();
        if(modo == null)
        {
            return;
        }
        switch(id)
        {
            case 0:
                modo.mode = ColorBlindMode.Normal;
                return;
            case 1:
                modo.mode = ColorBlindMode.Protanopia;
                return;
            case 2:
                modo.mode = ColorBlindMode.Protanomaly;
                return;
            case 3:
                modo.mode = ColorBlindMode.Deuteranopia;
                return;
            case 4:
                modo.mode = ColorBlindMode.Deuteranomaly;
                return;
            case 5:
                modo.mode = ColorBlindMode.Tritanopia;
                return;
            case 6:
                modo.mode = ColorBlindMode.Tritanomaly;
                return;
            case 7:
                modo.mode = ColorBlindMode.Achromatopsia;
                return;
            case 8:
                modo.mode = ColorBlindMode.Achromatomaly;
                return;
        }
    }

}
