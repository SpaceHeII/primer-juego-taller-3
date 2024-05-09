using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObject : MonoBehaviour
{
    public int pointsToAdd = 100; // Cantidad de puntos a agregar al jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Agregar puntos al jugador
            PointsSystem.Instance.AddPoints(pointsToAdd);

            // Destruir este objeto
            Destroy(gameObject);
        }
    }
}