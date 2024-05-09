using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActivator : MonoBehaviour
{
    public GameObject explosionObject; // Referencia al objeto de explosión

    void OnDestroy()
    {
        // Verificar si el objeto de explosión está configurado
        if (explosionObject != null)
        {
            // Activar el objeto de explosión
            explosionObject.SetActive(true);
        }
    }
}
