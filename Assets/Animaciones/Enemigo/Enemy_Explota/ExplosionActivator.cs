using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActivator : MonoBehaviour
{
    public GameObject explosionObject; // Referencia al objeto de explosi�n

    void OnDestroy()
    {
        // Verificar si el objeto de explosi�n est� configurado
        if (explosionObject != null)
        {
            // Activar el objeto de explosi�n
            explosionObject.SetActive(true);
        }
    }
}
