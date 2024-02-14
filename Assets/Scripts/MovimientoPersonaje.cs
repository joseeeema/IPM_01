using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public static MovimientoPersonaje instancia;
    public Vector3 posicionActual;
    public float velocidad;
    public Vector3 direccionMovimiento;

    private bool tutorial = false;

    public Animator animator;

    private void Awake()
    {
        instancia = this;
    }
    void Update()
    {
        posicionActual = transform.position;
        CalcularDireccion();
        if(GestorControles.instancia.controlTeclado && Input.GetKeyDown(KeyCode.Space))
        {
            Interactuar();
        }
    }

    public void Interactuar()
    {
        Vector3Int posicion = new Vector3Int((int)transform.position.x - 1, (int)transform.position.y, 0);
        if(GestorTiles.instancia.esInteractuable())
        {
            if(!tutorial)
            {
                tutorial = true;
                UI_Objetivos.instance.CambiarObjetivo(1);
            }
            GestorTiles.instancia.SetInteractuado(posicion);
            Debug.Log("Es interactuable");
        }
    }

    private void FixedUpdate()
    {
        if(!GestorControles.instancia.juegoDetenido)
        {
            Movimiento();
            Animacion();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void CalcularDireccion()
    {
        // Control mediante teclado y mando
        // Se evita que se pueda andar en diagonal
        float posX = Input.GetAxisRaw("Horizontal");
        if (posX != 0)
        {
            direccionMovimiento = new Vector3(posX, 0, 0);
        }
        else
        {
            float posY = Input.GetAxisRaw("Vertical");
            direccionMovimiento = new Vector3(0, posY, 0);
        }

    }

    public void Movimiento()
    {
        transform.position += direccionMovimiento * velocidad * Time.deltaTime;
    }

    public void Animacion()
    {
        if(animator != null)
        {
            if(direccionMovimiento.magnitude>0)
            {
                animator.SetBool("enMovimiento", true);
                animator.SetFloat("Horizontal", direccionMovimiento.x);
                animator.SetFloat("Vertical", direccionMovimiento.y);
            }
            else
            {
                animator.SetBool("enMovimiento", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
        }
    }
}
