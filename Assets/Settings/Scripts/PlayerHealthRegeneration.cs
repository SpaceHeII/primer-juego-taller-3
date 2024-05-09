using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRegeneration : MonoBehaviour
{
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador
    public float regenerationTime = 5f; // Tiempo en segundos para que comience la regeneraci�n despu�s de dejar de recibir da�o
    public float regenerationRate = 1f; // Tasa de regeneraci�n de la salud por segundo

    private float timeSinceLastDamage; // Tiempo transcurrido desde que el jugador recibi� da�o

    private void Start()
    {
        timeSinceLastDamage = regenerationTime; // Comenzar con el tiempo suficiente para comenzar la regeneraci�n
    }

    private void Update()
    {
        // Si ha pasado suficiente tiempo desde el �ltimo da�o y la salud actual no est� al m�ximo
        if (timeSinceLastDamage >= regenerationTime && playerHealth.currentHealth < playerHealth.maxHealth)
        {
            // Incrementar la salud del jugador seg�n la tasa de regeneraci�n
            playerHealth.currentHealth += regenerationRate * Time.deltaTime;
            playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth, playerHealth.maxHealth); // Asegurar que no supere la salud m�xima
        }

        // Incrementar el tiempo transcurrido desde el �ltimo da�o
        timeSinceLastDamage += Time.deltaTime;
    }

    public void DamageTaken()
    {
        // Restablecer el tiempo desde el �ltimo da�o cuando el jugador recibe da�o
        timeSinceLastDamage = 0f;
    }
}
