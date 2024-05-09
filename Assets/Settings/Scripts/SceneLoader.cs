using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nombre de la escena a cargar
    public string sceneToLoad;

    // M�todo llamado cuando un objeto colisiona con el jugador
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colision� es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar la escena especificada
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
