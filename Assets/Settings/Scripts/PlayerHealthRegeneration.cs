using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRegeneration : MonoBehaviour
{
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador
    public float regenerationTime = 5f; // Tiempo en segundos para que comience la regeneración después de dejar de recibir daño
    public float regenerationRate = 1f; // Tasa de regeneración de la salud por segundo

    private float timeSinceLastDamage; // Tiempo transcurrido desde que el jugador recibió daño

    private void Start()
    {
        timeSinceLastDamage = regenerationTime; // Comenzar con el tiempo suficiente para comenzar la regeneración
    }

    private void Update()
    {
        // Si ha pasado suficiente tiempo desde el último daño y la salud actual no está al máximo
        if (timeSinceLastDamage >= regenerationTime && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            // Incrementar la salud del jugador según la tasa de regeneración
            playerHealth.currentHealth += regenerationRate * Time.deltaTime;
            playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth, playerHealth.maxHealth); // Asegurar que no supere la salud máxima
        }

        // Incrementar el tiempo transcurrido desde el último daño
        timeSinceLastDamage += Time.deltaTime;
    }

    public void DamageTaken()
    {
        // Restablecer el tiempo desde el último daño cuando el jugador recibe daño
        timeSinceLastDamage = 0f;
    }
}
