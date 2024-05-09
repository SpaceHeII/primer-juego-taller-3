using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Referencia al panel de pausa
    private bool isPaused = false; // Variable para rastrear si el juego está pausado

    void Update()
    {
        // Si se presiona la tecla Escape y el juego no está pausado
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Congelar el tiempo
        Time.timeScale = 0f;

        // Activar el panel de pausa
        pausePanel.SetActive(true);

        // Actualizar el estado de la pausa
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Descongelar el tiempo
        Time.timeScale = 1f;

        // Desactivar el panel de pausa
        pausePanel.SetActive(false);

        // Actualizar el estado de la pausa
        isPaused = false;
    }

    public void RestartScene()
    {
        // Cargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reanudar el juego
        ResumeGame();
    }

    public void QuitGame()
    {
        // Salir del juego
        Application.Quit();
    }
}



