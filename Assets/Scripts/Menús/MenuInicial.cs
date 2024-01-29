using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void Jugar()
    {
        SceneManager.LoadScene(4);
    }
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
