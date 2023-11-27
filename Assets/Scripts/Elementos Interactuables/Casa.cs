using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Inventario personaje = collision.gameObject.GetComponent<Inventario>();
        if(personaje!= null)
        {
            UI_Dialogos.instance.MostrarDialogo(0);
        }
    }
}
