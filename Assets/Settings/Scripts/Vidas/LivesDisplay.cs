using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public TextMeshProUGUI livesText; // Referencia al componente TextMeshPro que mostrar� la cantidad de vidas
    public PlayerLives playerLives; // Referencia al componente PlayerLives para obtener la cantidad de vidas

    private void Start()
    {
        // Asegurarse de que se asign� el componente TextMeshPro en el Inspector
        if (livesText == null)
        {
            Debug.LogError("No se asign� el componente TextMeshPro para mostrar las vidas.");
            return;
        }

        // Asegurarse de que se asign� el componente PlayerLives en el Inspector
        if (playerLives == null)
        {
            Debug.LogError("No se asign� el componente PlayerLives para obtener la cantidad de vidas.");
            return;
        }

        // Actualizar el texto inicialmente
        UpdateLivesText(playerLives.currentLives);
    }

    // M�todo para actualizar el texto que muestra la cantidad de vidas
    private void UpdateLivesText(int lives)
    {
        livesText.text =  lives.ToString(); // Actualizar el texto con la cantidad actual de vidas
    }

    // M�todo que se suscribe al evento de p�rdida de vida en PlayerLives
    private void OnEnable()
    {
        playerLives.OnLivesChanged += UpdateLivesText; // Suscribirse al evento OnLivesChanged para actualizar el texto cuando cambien las vidas
    }

    // M�todo que se desuscribe del evento de p�rdida de vida en PlayerLives
    private void OnDisable()
    {
        playerLives.OnLivesChanged -= UpdateLivesText; // Desuscribirse del evento OnLivesChanged
    }
}


