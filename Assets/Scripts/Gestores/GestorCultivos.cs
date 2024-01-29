using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestorCultivos : MonoBehaviour
{
    public TMP_Text _numeroPatatas;
    public TMP_Text _numeroTomates;

    public int numPatatas;
    public int numTomates;

    public GameObject panelCultivos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPatatas();
        ActualizarTomates();
    }

    public void ActualizarPatatas()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;

        foreach(GestorInventario.Lote l in lotes)
        {
            if(l.tipo == TipoObjeto.PATATAS)
            {
                numPatatas = l.numero;
            }
        }

        _numeroPatatas.text = "Patatas restantes: " + numPatatas.ToString();
    }

    public void ActualizarTomates()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.TOMATES)
            {
                numTomates = l.numero;
            }
        }

        _numeroTomates.text = "Tomates restantes: " + numTomates.ToString();
    }

    public void VenderPatata()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.PATATAS)
            {
                if(l.numero>0)
                {
                    numPatatas--;
                    l.numero = numPatatas;
                    Inventario.instance.AumentarDinero(5);
                }
                else
                {
                    UI_Dialogos.instance.MostrarDialogo(6);
                }
            }
        }
    }

    public void Vender5Patatas()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.PATATAS)
            {
                if (l.numero > 4)
                {
                    numPatatas-=5;
                    l.numero = numPatatas;
                    Inventario.instance.AumentarDinero(25);
                }
                else
                {
                    UI_Dialogos.instance.MostrarDialogo(6);
                }
            }
        }
    }

    public void VenderTomate()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.TOMATES)
            {
                if (l.numero > 0)
                {
                    numTomates--;
                    l.numero = numTomates;
                    Inventario.instance.AumentarDinero(8);
                }
                else
                {
                    UI_Dialogos.instance.MostrarDialogo(7);
                }
            }
        }
    }

    public void Vender5Tomates()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.TOMATES)
            {
                if (l.numero > 4)
                {
                    numTomates-=5;
                    l.numero = numTomates;
                    Inventario.instance.AumentarDinero(40);
                }
                else
                {
                    UI_Dialogos.instance.MostrarDialogo(7);
                }
            }
        }
    }

    public void Salir()
    {
        panelCultivos.SetActive(false);
    }
}
