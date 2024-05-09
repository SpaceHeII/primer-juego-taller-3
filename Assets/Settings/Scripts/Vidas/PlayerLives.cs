using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3; // N�mero m�ximo de vidas
    public int currentLives; // N�mero actual de vidas
    public string gameOverSceneName; // Nombre de la escena de Game Over

    public event Action<int> OnLivesChanged; // Evento que se activa cuando cambian las vidas del jugador

    private void Start()
    {
        currentLives = maxLives; // Establecer el n�mero inicial de vidas
    }

    // M�todo p�blico para perder una vida
    public void LoseLife()
    {
        currentLives--; // Reducir el n�mero de vidas
        // Aqu� puedes agregar l�gica adicional, como mostrar un mensaje de p�rdida de vida o reiniciar el nivel si el jugador se queda sin vidas
        Debug.Log("�Has perdido una vida! Vidas restantes: " + currentLives);

        // Invocar el evento OnLivesChanged para notificar a los suscriptores que las vidas han cambiado
        OnLivesChanged?.Invoke(currentLives);

        if (currentLives <= 0)
        {
            // Cargar la escena de Game Over
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameOverSceneName);
        }
    }

    // M�todo para detectar si el jugador se transport� o colision� con la trampa
    public void PlayerTransportedOrHitTrap()
    {
        LoseLife(); // Llamar al m�todo LoseLife() cuando el jugador se transporte o colisione con la trampa
    }
}





