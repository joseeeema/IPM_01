using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float contador = 0;
    public int maxTempo = 4;
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
