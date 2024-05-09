using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificarVida : MonoBehaviour
{
    public PlayerLives playerLives; // Referencia al script PlayerLives que contiene las vidas del jugador
    public string escenaNuevaNombre; // Nombre de la escena que se cargará si las vidas son menores o iguales a cero

    void Start()
    {
        // Suscribir el método a la acción OnLivesChanged para que se ejecute cuando cambien las vidas del jugador
        playerLives.OnLivesChanged += VerificarVidas;
    }

    // Método para verificar si las vidas son menores o iguales a cero
    void VerificarVidas(int vidas)
    {
        if (vidas <= 0)
        {
            // Cargar la escena nueva
            SceneManager.LoadScene(escenaNuevaNombre);
        }
    }

    void OnDestroy()
    {
        // Asegúrate de desuscribir el método de la acción cuando el objeto se destruya para evitar fugas de memoria
        playerLives.OnLivesChanged -= VerificarVidas;
    }
}