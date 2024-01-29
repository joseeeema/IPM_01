using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 puntoDestino; // Punto al que queremos ir
    public float velocidad = 5f; // Velocidad a la que se moverá el enemigo
    void Start()
    {
        
    }
    void Update()
    {
        // Calculamos la dirección hacia el punto de destino
        Vector3 direccion = puntoDestino - transform.position;

        // Si la distancia al punto es mayor que una pequeña tolerancia, movemos el objeto
        if (direccion.magnitude > 0.1f)
        {
            // Normalizamos la dirección para que tenga magnitud 1 (mantiene la velocidad constante)
            direccion.Normalize();

            // Movemos el objeto en la dirección calculada a la velocidad especificada
            transform.position += direccion * velocidad * Time.deltaTime;
        }

        else { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cultivo")
        {
            Cultivos cultivos = collision.gameObject.GetComponent<Cultivos>();
            if(cultivos != null)
            {
            foreach (var c in GestorRecursos.instancia.posicionesCultivos)
            {
                if (c.Equals(cultivos.posicionTile))
                {
                    GestorRecursos.instancia.posicionesCultivos.Remove(c);
                        //posicionesCultivos.Sort();
                        Destroy(collision.gameObject);
                        Destroy(gameObject);
                        return;
                }
            }
            }
            Cultivos2 cultivoT = collision.gameObject.GetComponent<Cultivos2>();
            if (cultivoT != null)
            {
                foreach (var c in GestorRecursos.instancia.posicionesCultivos)
                {
                    if (c.Equals(cultivoT.posicionTile))
                    {
                        GestorRecursos.instancia.posicionesCultivos.Remove(c);
                        //posicionesCultivos.Sort();
                        Destroy(collision.gameObject);
                        Destroy(gameObject);
                        return;
                    }
                }
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


 }


