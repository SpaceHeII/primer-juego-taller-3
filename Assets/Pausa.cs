using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject munePausa;
    public void PausA()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        munePausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        munePausa.SetActive(false);
    }

    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("Cerrando Juego");
    }

    public void Reiniciar()
    {
       Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
