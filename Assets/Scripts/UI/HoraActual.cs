using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoraActual : MonoBehaviour
{
    public TMP_Text hora;
    public int segundoInicial;
    public int minutoInicial;
    public int numMinutos;
    public int minutosTranscurridos = 0;
    public TMP_Text tiempo_transcurrido;

    private void Start()
    {
        segundoInicial = System.DateTime.Now.Second;
        minutoInicial = System.DateTime.Now.Minute;
    }

    // Update is called once per frame
    void Update()
    {
        hora.text =
            System.DateTime.Now.Hour.ToString("00") + ":" +
            System.DateTime.Now.Minute.ToString("00") + ":" +
            System.DateTime.Now.Second.ToString("00");

        CalcularTiempo();
        TransformarMinutos();

        if(numMinutos >= 10)
        {
            StartCoroutine(FinJuego());
        }
    }

    IEnumerator FinJuego()
    {
        UI_Dialogos.instance.MostrarDialogo(14);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);

    }

public void CalcularTiempo()
    {
        if(System.DateTime.Now.Second == segundoInicial && minutoInicial != System.DateTime.Now.Minute)
        {
            minutosTranscurridos++;
            minutoInicial = System.DateTime.Now.Minute;
        }
    }

    public void TransformarMinutos()
    {
        int numHoras = minutosTranscurridos / 60;
        int numMinutos = minutosTranscurridos % 60;
        int numDias = numHoras / 24;
        numHoras = numHoras % 24;

        ActualizarTexto(numDias, numHoras, numMinutos);
    }

    public void ActualizarTexto(int numDias, int numHoras, int numMinutos)
    {
        tiempo_transcurrido.text = numDias.ToString() +" Dias "+numHoras.ToString() + " Horas "+numMinutos.ToString()+" Minutos ";
    }
}
