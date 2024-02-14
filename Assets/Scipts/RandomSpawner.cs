using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float contador = 0;
    public int maxTempo = 4;

    private bool tutorial = false;

    void Start()
    {
        
    }
    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= maxTempo && ComprobarCultivos())
        {
            contador = 0;
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
            if(!tutorial)
            {
                tutorial = true;
                UI_Dialogos.instance.MostrarDialogo(15);
            }
        }
    }

    public bool ComprobarCultivos()
    {
        var listaCultivos = GestorRecursos.instancia.posicionesCultivos;

        foreach(Vector3Int v in listaCultivos)
        {
            if(v != null)
            {
                return true;
            }
        }
        return false;
    }
}
