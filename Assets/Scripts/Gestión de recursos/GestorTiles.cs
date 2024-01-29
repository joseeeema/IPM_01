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
            bool encontrado = false;
            var lotes = Inventario.instance.gestorInventario.lotes;
            foreach (GestorInventario.Lote l in lotes)
            {
                if (l.tipo == TipoObjeto.SEMILLAS_PATATAS)
                {
                    if (l.numero > 0)
                    {
                        l.numero += GestorRecursos.instancia.PlantarCultivo(posicion); 
                    }
                    else
                    {
                        UI_Dialogos.instance.MostrarDialogo(9);
                    }
                    encontrado = true;
                }
            }
            if(!encontrado)
            {
                UI_Dialogos.instance.MostrarDialogo(10);
            }
        }
    }

    public void ReiniciarCasilla(Vector3Int posicion)
    {
        areaInteractuable.SetTile(posicion, tierraInicial);
        foreach(Vector3Int v in casillasAradas)
        {
            if(v==posicion)
            {
                casillasAradas.Remove(v);
                //casillasAradas.Sort();
                return;
            }
        }
    }
}

