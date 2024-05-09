using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExplosion : MonoBehaviour
{
    public float explosionForce = 500f; // Fuerza de la explosión
    public float explosionRadius = 5f; // Radio de la explosión

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el otro Collider es el jugador
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calcular la dirección desde el centro del área de explosión hasta el jugador
                Vector2 direction = (other.transform.position - transform.position).normalized;

                // Aplicar la fuerza de explosión al jugador
                rb.AddForce(direction * explosionForce);
            }
        }
    }
}
