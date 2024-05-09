using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificarVida : MonoBehaviour
{
    public PlayerLives playerLives; // Referencia al script PlayerLives que contiene las vidas del jugador
    public string escenaNuevaNombre; // Nombre de la escena que se cargar� si las vidas son menores o iguales a cero

    void Start()
    {
        // Suscribir el m�todo a la acci�n OnLivesChanged para que se ejecute cuando cambien las vidas del jugador
        playerLives.OnLivesChanged += VerificarVidas;
    }

    // M�todo para verificar si las vidas son menores o iguales a cero
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
        // Aseg�rate de desuscribir el m�todo de la acci�n cuando el objeto se destruya para evitar fugas de memoria
        playerLives.OnLivesChanged -= VerificarVidas;
    }
}