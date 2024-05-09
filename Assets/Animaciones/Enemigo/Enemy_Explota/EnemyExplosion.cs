using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab del área de explosión
    public float explosionForce = 500f; // Fuerza de la explosión
    public float explosionRadius = 5f; // Radio de la explosión
    public LayerMask playerLayer; // Capa del jugador
    public AudioClip explosionSound; // Sonido de la explosión
    public float volume = 1f; // Volumen del sonido

    void OnDestroy()
    {
        // Instanciar el objeto de explosión
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Obtener todos los colliders en el radio de la explosión
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        // Reproducir el sonido de la explosión
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, volume);
        }

        // Aplicar fuerza de explosión al jugador
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Calcular la dirección desde el centro del área de explosión hasta el jugador
                    Vector2 direction = (collider.transform.position - transform.position).normalized;

                    // Aplicar la fuerza de explosión al jugador
                    rb.AddForce(direction * explosionForce);
                }
            }
        }
    }
}

