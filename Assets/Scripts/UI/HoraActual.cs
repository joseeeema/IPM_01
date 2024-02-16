using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoraActual : MonoBehaviour
{
    public static HoraActual instance;

    public float numMinutos = 0;
    public const int maxMinutos = 7;
    private int segundoInicial;
    private int minutoActual;

    public Slider slider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        segundoInicial = System.DateTime.Now.Second;
        minutoActual = System.DateTime.Now.Minute;
    }

    private void Update()
    {
        if(System.DateTime.Now.Second == segundoInicial && System.DateTime.Now.Minute != minutoActual)
        {
            numMinutos++;
            minutoActual= System.DateTime.Now.Minute;
            CambioSlider();
        }
        if(numMinutos >= maxMinutos)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void CambioSlider()
    {
        slider.value = maxMinutos - numMinutos;
    }
}
