using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorControles : MonoBehaviour
{
    public static GestorControles instancia;

    public bool controlTeclado = true;
    public bool controlMando = false;

    public bool juegoDetenido;

    private void Awake()
    {
        instancia = this;
    }

    private void Update()
    {
        if(controlMando)
        {
            // De esta manera no se ve el cursor del ratón
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void DetenerJuego()
    {
        juegoDetenido = true;
    }

    public void IniciarJuego()
    {
        juegoDetenido = false;
    }
}
