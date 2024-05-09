using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float lifetime = 2f; // Tiempo de vida del l�ser

    void Start()
    {
        // Destruir el l�ser despu�s de un cierto tiempo
        Destroy(gameObject, lifetime);
    }

    // Aqu� puedes agregar l�gica adicional para detectar colisiones u otras interacciones con el l�ser
}
