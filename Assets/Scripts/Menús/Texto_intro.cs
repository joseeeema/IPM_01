using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Texto_intro : MonoBehaviour
{
    public TMP_Text texto;
    public string[] dialogos;
    public GameObject continuar;
    public bool mostrandoTexto = false;
    public int estado = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarCaracteres(dialogos[0]));
    }
    IEnumerator MostrarCaracteres(string frase)
    {
        continuar.SetActive(false);
        mostrandoTexto = true;
        texto.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            texto.text += letra;
            yield return new WaitForSeconds(0.03f);
        }

        continuar.SetActive(true);
        mostrandoTexto = false;
        estado++;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& mostrandoTexto==false)
        {
            switch (estado)
            {
                case 1:
                    StartCoroutine(MostrarCaracteres(dialogos[1]));
                    break;

                case 2:
                    StartCoroutine(MostrarCaracteres(dialogos[2]));
                    break;

                case 3:
                    StartCoroutine(MostrarCaracteres(dialogos[3]));
                    break;
                case 4:
                    StartCoroutine(MostrarCaracteres(dialogos[4]));
                    break;
                case 5:
                    StartCoroutine(MostrarCaracteres(dialogos[5]));
                    break;
                case 6:
                    StartCoroutine(MostrarCaracteres(dialogos[6]));
                    break;
                case 7:
                    StartCoroutine(MostrarCaracteres(dialogos[7]));
                    break;
                case 8:
                    StartCoroutine(MostrarCaracteres(dialogos[8]));
                    break;
                case 9:
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }
}
