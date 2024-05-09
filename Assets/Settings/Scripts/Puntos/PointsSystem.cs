using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public float pointsPerSecond = 1f; // Puntos que se suman por segundo
    public float pointsPerEnemyKill = 10f; // Puntos que se suman por cada enemigo derrotado
    private float points = 0f; // Puntos acumulados
    public static PointsSystem Instance { get; private set; }

    private void Awake()
    {
        // Configurar la instancia única al iniciar
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // Incrementar los puntos basado en el tiempo transcurrido
        points += pointsPerSecond * Time.deltaTime;
    }

    // Método para agregar puntos adicionales
    public void AddPoints(float amount)
    {
        points += amount;
    }

    // Método para reiniciar los puntos
    public void ResetPoints()
    {
        points = 0f;
    }

    // Método para obtener los puntos acumulados
    public float GetPoints()
    {
        return points;
    }

    // Método para agregar puntos cuando se mata un enemigo
    public void AddPointsOnEnemyKill()
    {
        points += pointsPerEnemyKill;
    }
}

