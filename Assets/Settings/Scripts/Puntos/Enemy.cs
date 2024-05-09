using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float pointsOnDeath = 10f; // Puntos que se suman cuando el enemigo muere
    private PointsSystem pointsSystem; // Referencia al sistema de puntos

    void Start()
    {
        // Obtener referencia al sistema de puntos
        pointsSystem = FindObjectOfType<PointsSystem>();
    }

    void OnDestroy()
    {
        // Agregar puntos al sistema cuando el enemigo es destruido
        pointsSystem.AddPointsOnEnemyKill();
    }
}
