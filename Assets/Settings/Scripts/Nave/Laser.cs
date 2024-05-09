using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float lifetime = 2f; // Tiempo de vida del láser

    void Start()
    {
        // Destruir el láser después de un cierto tiempo
        Destroy(gameObject, lifetime);
    }

    // Aquí puedes agregar lógica adicional para detectar colisiones u otras interacciones con el láser
}
