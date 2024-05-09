using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Objeto del escudo
    public GameObject shieldObject;

    // Vida máxima del escudo
    public float maxShieldHealth = 4f;

    public float currentShieldHealth; // Vida actual del escudo
    private bool isActive = false; // Estado actual del escudo
    private Collider2D shieldCollider; // Collider2D del escudo

    private void Start()
    {
        currentShieldHealth = 0f; // Inicializar la vida del escudo en 0
        shieldCollider = GetComponent<Collider2D>(); // Obtener el Collider2D del escudo

        // Desactivar el escudo al inicio
        DeactivateShield();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comparar el GameObject colisionado con el objeto del escudo
        if (collision.gameObject == shieldObject)
        {
            // Activar el escudo
            ActivateShield();
            Debug.Log("¡Escudo adquirido!");
        }

        // Verificar si el objeto colisionado es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruir este objeto si colisiona con el jugador
            Destroy(gameObject);
        }
    }

    // Método para activar el escudo
    private void ActivateShield()
    {
        isActive = true;
        shieldCollider.enabled = false; // Desactivar la detección de colisiones físicas del Collider2D del escudo
        currentShieldHealth = maxShieldHealth; // Establecer la vida del escudo en su valor máximo
    }

    // Método para desactivar el escudo
    public void DeactivateShield()
    {
        isActive = false;
        shieldCollider.enabled = true; // Activar la detección de colisiones físicas del Collider2D del escudo
    }

    // Método para reducir la vida del escudo cuando recibe daño
    public void TakeDamage(float amount)
    {
        if (isActive)
        {
            currentShieldHealth -= amount; // Reducir la vida actual del escudo
            currentShieldHealth = Mathf.Clamp(currentShieldHealth, 0f, maxShieldHealth); // Asegurar que la vida no sea menor que 0 ni mayor que la vida máxima

            // Si la vida del escudo llega a 0, desactivarlo
            if (currentShieldHealth <= 0f)
            {
                DeactivateShield();
            }
        }
    }

    // Método para verificar si el escudo está activo
    public bool IsShieldActive()
    {
        return isActive;
    }

    // Método para recargar el escudo
    public void RechargeShield()
    {
        currentShieldHealth = maxShieldHealth; // Establecer la vida del escudo en su valor máximo
    }
}







