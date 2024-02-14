using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivos2 : MonoBehaviour
{
    public TipoObjeto tipo;
    public Sprite icono;

    public GameObject estado1, estado2, estado3, estado4, estado5, estado6;
    public int segundoInicial;
    public int numSegundos;
    public const int cambio1 = 15;
    public const int cambio2 = 30;
    public const int cambio3 = 45;
    public const int cambio4 = 60;
    public const int cambio5 = 80;
    public bool sePuedeRecoger = false;

    public Vector3Int posicionTile;

    // Start is called before the first frame update
    void Start()
    {
        segundoInicial = System.DateTime.Now.Second;
    }

    // Update is called once per frame
    void Update()
    {
        if(numSegundos <= 80)
        {
            CalcularTiempo();
            CambiarSprite();
        }
    }

    public void CalcularTiempo()
    {
        if (System.DateTime.Now.Second != segundoInicial)
        {
            numSegundos++;
            segundoInicial = System.DateTime.Now.Second;
        }
    }

    public void CambiarSprite()
    {
        switch(numSegundos)
        {
            case cambio1:
                estado1.SetActive(false);
                estado2.SetActive(true);
                break;
            case cambio2:
                estado2.SetActive(false);
                estado3.SetActive(true);
                break;
            case cambio3:
                estado3.SetActive(false);
                estado4.SetActive(true);
                break;
            case cambio4:
                estado4.SetActive(false);
                estado5.SetActive(true);
                break;
            case cambio5:
                estado5.SetActive(false);
                estado6.SetActive(true);
                sePuedeRecoger = true;
                if (!UI_Objetivos.instance.primerCultivo)
                {
                    UI_Objetivos.instance.CambiarObjetivo(2);
                    UI_Dialogos.instance.MostrarDialogo(16);
                    UI_Objetivos.instance.primerCultivo = true;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!sePuedeRecoger)
        {
            return;
        }
        Inventario jugador = collision.gameObject.GetComponent<Inventario>();

        if (jugador != null)
        {
            Recolectable cultivo = new Recolectable(tipo, icono);
            jugador.gestorInventario.AñadirObjeto(cultivo);
            UI_Inventario.instancia.aviso.SetActive(true);
            GestorTiles.instancia.ReiniciarCasilla(posicionTile);
            GestorRecursos.instancia.RecogerCultivo(posicionTile);
            Destroy(gameObject);
        }
    }
}
