using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stacks : MonoBehaviour
{
    public Image iconoObjeto;
    public TMP_Text cantidad;

    public void SetItem(GestorInventario.Lote lote)
    {
        if(lote!=null)
        {
            iconoObjeto.sprite = lote.icono;
            iconoObjeto.color = new Color(1, 1, 1, 1);
            cantidad.text = lote.numero.ToString();
        }
    }

    public void SetEmpty()
    {
        iconoObjeto.sprite = null;
        iconoObjeto.color = new Color(1, 1, 1, 0);
        cantidad.text = "";
    }
}
