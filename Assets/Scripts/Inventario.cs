using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario instance;
    public GestorInventario gestorInventario;

    private void Awake()
    {
        instance = this;
        gestorInventario = new GestorInventario(15);
    }
    
}
