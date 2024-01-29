using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario instance;
    public GestorInventario gestorInventario;
    public int dinero = 0;
    public TMP_Text textoDinero;

    private void Awake()
    {
        instance = this;
        gestorInventario = new GestorInventario(15);
    }

    public void AumentarDinero(int cantidad)
    {
        dinero += cantidad;
        textoDinero.text = "Ganancias: " + dinero.ToString() + "$";
    }
    
}
