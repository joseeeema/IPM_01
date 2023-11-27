using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GestorTiles : MonoBehaviour
{
    public static GestorTiles instancia;
    public Tilemap areaInteractuable;
    public Tile tierraPreparada;
    public Tile tierraInicial;
    public bool pisandoTerreno = false;

    public bool explicado = false;

    public List<Vector3Int> casillasAradas = new List<Vector3Int>();

    private void Awake()
    {
        instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!explicado)
        {
            if(GestorControles.instancia.controlMando)
            {
                UI_Dialogos.instance.MostrarDialogo(2);
            }
            else
            {
                UI_Dialogos.instance.MostrarDialogo(1);
            }
            explicado = true;
        }
        Inventario personaje = collision.gameObject.GetComponent<Inventario>();
        if (personaje != null)
        {
            pisandoTerreno = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Inventario personaje = collision.gameObject.GetComponent<Inventario>();
        if (personaje != null)
        {
            pisandoTerreno = false;
        }
    }

    public bool esInteractuable()
    {
        if (pisandoTerreno) return true;
        return false;
    }

    public void SetInteractuado(Vector3Int posicion)
    {
        bool arado = false;
        areaInteractuable.SetTile(posicion, tierraPreparada);
        foreach(Vector3Int v in casillasAradas)
        {
            if(v.Equals(posicion)) arado = true;
        }
        if(!arado)
        {
            casillasAradas.Add(posicion);
        }
        else
        {
            // Se planta un cultivo
            GestorRecursos.instancia.PlantarCultivo(posicion);
        }
    }

    public void ReiniciarCasilla(Vector3Int posicion)
    {
        areaInteractuable.SetTile(posicion, tierraInicial);
        foreach(Vector3Int v in casillasAradas)
        {
            if(v.Equals(posicion))
            {
                casillasAradas.Remove(v);
                casillasAradas.Sort();
                return;
            }
        }
    }
}

