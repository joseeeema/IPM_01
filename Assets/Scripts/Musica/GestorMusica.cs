using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorMusica : MonoBehaviour
{
    public static GestorMusica instancia;
    public bool iniciado = false;

    private void Awake()
    {
        instancia = this;
    }

    public void Start()
    {
        iniciado = true;
    }
    public static void PonerMusica(AudioClip cancion, AudioSource reproductor, bool debeRepetirse)
    {
        reproductor.clip = cancion;
        reproductor.loop = debeRepetirse;
        reproductor.Play();
    }

    public static void QuitarMusica(AudioSource reproductor)
    {
        reproductor.Stop();
    }
}
