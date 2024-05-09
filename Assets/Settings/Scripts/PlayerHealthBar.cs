using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBar; // Referencia a la barra de vida en el UI
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador

    void Start()
    {
        // Actualizar la barra de vida al inicio
        UpdateHealthBar();
    }

    void Update()
    {
        // Actualizar la barra de vida en cada frame (opcional, dependiendo del rendimiento)
        UpdateHealthBar();
    }

    // Método para actualizar la barra de vida
    void UpdateHealthBar()
    {
        // Calcular el porcentaje de vida actual del jugador
        float healthPercent = playerHealth.currentHealth / playerHealth.maxHealth;

        // Actualizar la barra de vida en el UI
        healthBar.fillAmount = healthPercent;
    }
}
