using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Dialogos : MonoBehaviour
{
    public static UI_Dialogos instance;
    public GameObject cuadroDialogo;
    public TMP_Text textoDialogo;
    public string[] dialogos;
    private bool mostrandoTexto = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cuadroDialogo.SetActive(false);
        textoDialogo.text = "";
    }

    // Método con el que se hace aparecer el recuadro y se escribe el texto
    public void MostrarDialogo(int id)
    {
        // De esta manera se consigue que no se solapen las frases
        if (!mostrandoTexto)
        {
            cuadroDialogo.SetActive(true);
            StartCoroutine(MostrarCaracteres(dialogos[id]));
        }
    }

    // Corrutina con la que se muestran los caracteres del texto uno por uno
    IEnumerator MostrarCaracteres(string frase)
    {
        mostrandoTexto = true;
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(LimpiarCuadroTexto());
    }

    // Corrutina que hace desaparecer el texto después de unos segundos
    IEnumerator LimpiarCuadroTexto()
    {
        yield return new WaitForSeconds(3.5f);
        cuadroDialogo.SetActive(false);
        mostrandoTexto = false;
    }
}
