using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3; // Número máximo de vidas
    public int currentLives; // Número actual de vidas
    public string gameOverSceneName; // Nombre de la escena de Game Over

    public event Action<int> OnLivesChanged; // Evento que se activa cuando cambian las vidas del jugador

    private void Start()
    {
        currentLives = maxLives; // Establecer el número inicial de vidas
    }

    // Método público para perder una vida
    public void LoseLife()
    {
        currentLives--; // Reducir el número de vidas
        // Aquí puedes agregar lógica adicional, como mostrar un mensaje de pérdida de vida o reiniciar el nivel si el jugador se queda sin vidas
        Debug.Log("¡Has perdido una vida! Vidas restantes: " + currentLives);

        // Invocar el evento OnLivesChanged para notificar a los suscriptores que las vidas han cambiado
        OnLivesChanged?.Invoke(currentLives);

        if (currentLives <= 0)
        {
            // Cargar la escena de Game Over
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameOverSceneName);
        }
    }

    // Método para detectar si el jugador se transportó o colisionó con la trampa
    public void PlayerTransportedOrHitTrap()
    {
        LoseLife(); // Llamar al método LoseLife() cuando el jugador se transporte o colisione con la trampa
    }
}





