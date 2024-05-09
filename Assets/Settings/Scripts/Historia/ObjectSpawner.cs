using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Objeto que se creará
    public Transform respawnPoint; // Punto de respawn para el objeto
    public float spawnDelay = 5f; // Tiempo de espera antes de crear el objeto

    private bool hasSpawned = false;

    void Start()
    {
        Invoke("SpawnObject", spawnDelay);
    }

    void SpawnObject()
    {
        if (!hasSpawned)
        {
            if (respawnPoint != null)
            {
                Instantiate(objectToSpawn, respawnPoint.position, Quaternion.identity);
                hasSpawned = true;
            }
            else
            {
                Debug.LogWarning("Respawn point not assigned in ObjectSpawner!");
            }
        }
    }
}


