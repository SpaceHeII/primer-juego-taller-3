using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 5f; // Tiempo de vida del objeto en segundos

    void Start()
    {
        // Destruir el objeto despu�s del tiempo especificado
        Destroy(gameObject, lifetime);
    }
}
