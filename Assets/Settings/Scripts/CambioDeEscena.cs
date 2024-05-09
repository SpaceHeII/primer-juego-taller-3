using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public KeyCode teclaParaCambio = KeyCode.Space; // Tecla que activar� el cambio de escena
    public string nombreDeLaEscenaACargar; // Nombre de la escena a la que se cambiar�

    void Update()
    {
        // Verificar si se ha presionado la tecla para cambio de escena
        if (Input.GetKeyDown(teclaParaCambio))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nombreDeLaEscenaACargar);
        }
    }
}
