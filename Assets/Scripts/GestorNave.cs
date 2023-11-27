using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorNave : MonoBehaviour
{
    public static GestorNave instancia;
    public GameObject[] piezasNave;
    public bool[] piezasConseguidas;

    private void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CalcularNumeroPiezas();
    }

    // Update is called once per frame
    void Update()
    {
        MostrarNave();
    }

    public void PiezaConseguida(int id)
    {
        piezasNave[id].SetActive(true);
        piezasConseguidas[id] = true;
        CalcularNumeroPiezas();
    }

    public void CalcularNumeroPiezas()
    {
        int contador = 0;
        for(int i=0; i< piezasConseguidas.Length; i++)
        {
            if (piezasConseguidas[i])
            {
                contador++;
            }
        }
        UI_Nave.instance.ActualizarTextos(contador, piezasConseguidas);
    }

    public void MostrarNave()
    {
        for(int i=0; i< piezasConseguidas.Length; i++)
        {
            if (piezasConseguidas[i])
            {
                piezasNave[i].SetActive(true);
            }
        
        
        }
    }
}
