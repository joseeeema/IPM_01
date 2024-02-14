using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Objetivos : MonoBehaviour
{
    public static UI_Objetivos instance;
    public string[] objetivos;
    public GameObject[] avisosVisuales;

    public TMP_Text objetivo;

    public bool primerCultivo = false;
    public int hablarVendedor = 0;
    public int hablarPiezas = 0;

    private void Awake()
    {
        instance = this; 
    }

    public void CambiarObjetivo(int id)
    {
        objetivo.text = objetivos[id];
        for(int i=0; i<avisosVisuales.Length; i++)
        {
            avisosVisuales[i].SetActive(false);
        }
        if(id==0)
        {
            avisosVisuales[id].SetActive(true);
        }
        if(id==2)
        {
            avisosVisuales[1].SetActive(true);
            hablarVendedor++;
        }
        if(id==3)
        {
            avisosVisuales[2].SetActive(true);
            hablarPiezas++;
        }
    }
}
