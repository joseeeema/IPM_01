using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorRecursos : MonoBehaviour
{
    public static GestorRecursos instancia;

    public List<Vector3Int> posicionesCultivos = new List<Vector3Int>();

    public GameObject cultivoPatata;
    public GameObject cultivoTomate;

    private void Awake()
    {
        instancia = this;
    }

    public int PlantarCultivo(Vector3Int cultivo)
    {
        Vector3 posicion = new Vector3(cultivo.x + 0.5f, cultivo.y + 0.75f, cultivo.z);
        foreach(var c in posicionesCultivos)
        {
            // Esto significa que hay un cultivo ya en esta posición
            if (c.Equals(cultivo)) {
                UI_Dialogos.instance.MostrarDialogo(3);
                return 0;
            } 
        }
        int numRandom = Random.Range(0, 10);
        if(numRandom<7)
        {
            GameObject patata = Instantiate(cultivoPatata, posicion, Quaternion.identity);
            Cultivos p = patata.gameObject.GetComponent<Cultivos>();
            p.posicionTile = cultivo;
            posicionesCultivos.Add(cultivo);
        }
        else
        {
            GameObject tomate = Instantiate(cultivoTomate, posicion, Quaternion.identity);
            Cultivos2 t = tomate.gameObject.GetComponent<Cultivos2>();
            t.posicionTile = cultivo;
            posicionesCultivos.Add(cultivo);
        }


        return -1;
    }

    public void RecogerCultivo(Vector3Int cultivo)
    {
        foreach(var c in posicionesCultivos)
        {
            if(c.Equals(cultivo))
            {
                posicionesCultivos.Remove(c);
                //posicionesCultivos.Sort();
                return;
            }
        }
    }

    private void Update()
    {
        var lotes = Inventario.instance.gestorInventario.lotes;
        foreach (GestorInventario.Lote l in lotes)
        {
            if (l.tipo == TipoObjeto.SEMILLAS_PATATAS)
            {
                if (l.numero <= 0)
                {
                    StartCoroutine(FinJuego());
                }
              
            }
        }
    }

    IEnumerator FinJuego()
    {
        UI_Dialogos.instance.MostrarDialogo(13);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);

    } 
}
