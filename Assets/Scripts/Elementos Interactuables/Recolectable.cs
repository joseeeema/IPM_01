using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public TipoObjeto tipo;
    public Sprite icono;

    public Recolectable(TipoObjeto tipo, Sprite icono)
    {
        this.tipo = tipo;
        this.icono = icono;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Inventario jugador = collision.gameObject.GetComponent<Inventario>();

        if(jugador!=null)
        {
            for(int i=0; i<50; i++)
            {
                jugador.gestorInventario.AñadirObjeto(this);
            }
            UI_Dialogos.instance.MostrarDialogo(8);
            UI_Inventario.instancia.aviso.SetActive(true);
            Destroy(gameObject);
        }
    }
}

public enum TipoObjeto
{
    NULL, SEMILLAS_PATATAS, PATATAS, TOMATES
}