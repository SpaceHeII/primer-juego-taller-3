using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrearTexto : MonoBehaviour
{
    public TextMeshPro textoPrefab; // Prefab del objeto TextMeshPro
    public Transform spawnPoint; // Punto de creación del texto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Crear una instancia del objeto TextMeshPro en el spawnPoint
            Instantiate(textoPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
