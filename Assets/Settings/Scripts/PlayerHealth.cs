using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class TagDamage
{
    public string tag;
    public float damageAmount;
}

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jugador
    public float currentHealth;
    public event Action OnPlayerDeath; // Evento que se activa cuando el jugador muere

    public List<TagDamage> damagePerTag; // Lista de tags y su cantidad de daño asociada
    private CheckPointSystem checkPointSystem;
    private PlayerLives playerLives; // Referencia al componente PlayerLives para descontar vidas cuando el jugador muere

    private void Start()
    {
        currentHealth = maxHealth; // Establecer la vida inicial del jugador
        checkPointSystem = CheckPointSystem.instance; // Obtener la referencia al CheckPointSystem
        playerLives = GetComponent<PlayerLives>(); // Obtener el componente PlayerLives
    }

    // Método para reducir la vida del jugador cuando recibe daño
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Reducir la vida actual
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Asegurar que la vida no sea menor que 0 ni mayor que la vida máxima

        // Aquí puedes agregar cualquier lógica adicional, como comprobar si el jugador ha muerto
        if (currentHealth <= 0f)
        {
            Die(); // Llamar al método de muerte
        }
    }

    // Método para manejar la muerte del jugador
    private void Die()
    {
        // Llamar al método LoseLife() en PlayerLives para descontar una vida
        playerLives.LoseLife();

        // Mover al jugador a la última posición conocida del punto de control
        transform.position = checkPointSystem.UltimaPos;
        // Reiniciar la salud del jugador
        currentHealth = maxHealth;

        // Llamar al evento de muerte del jugador si hay suscriptores
        OnPlayerDeath?.Invoke();
    }
}











