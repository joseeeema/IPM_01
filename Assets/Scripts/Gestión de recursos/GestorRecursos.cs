using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorRecursos : MonoBehaviour
{
    public static GestorRecursos instancia;

    public List<Vector3Int> posicionesCultivos = new List<Vector3Int>();

    public GameObject cultivoPatata;

    private void Awake()
    {
        instancia = this;
    }

    public void PlantarCultivo(Vector3Int cultivo)
    {
        Vector3 posicion = new Vector3(cultivo.x + 0.5f, cultivo.y + 0.75f, cultivo.z);
        foreach(var c in posicionesCultivos)
        {
            // Esto significa que hay un cultivo ya en esta posición
            if (c.Equals(cultivo)) {
                UI_Dialogos.instance.MostrarDialogo(3);
                return;
            } 
        }
        GameObject patata = Instantiate(cultivoPatata, posicion, Quaternion.identity);
        Cultivos p = patata.gameObject.GetComponent<Cultivos>();
        p.posicionTile = cultivo;
        posicionesCultivos.Add(cultivo);
    }

    public void RecogerCultivo(Vector3Int cultivo)
    {
        foreach(var c in posicionesCultivos)
        {
            if(c.Equals(cultivo))
            {
                posicionesCultivos.Remove(c);
                posicionesCultivos.Sort();
                return;
            }
        }
    }
}
