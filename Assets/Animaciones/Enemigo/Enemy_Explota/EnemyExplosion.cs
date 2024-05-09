using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab del �rea de explosi�n
    public float explosionForce = 500f; // Fuerza de la explosi�n
    public float explosionRadius = 5f; // Radio de la explosi�n
    public LayerMask playerLayer; // Capa del jugador
    public AudioClip explosionSound; // Sonido de la explosi�n
    public float volume = 1f; // Volumen del sonido

    void OnDestroy()
    {
        // Instanciar el objeto de explosi�n
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Obtener todos los colliders en el radio de la explosi�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        // Reproducir el sonido de la explosi�n
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, volume);
        }

        // Aplicar fuerza de explosi�n al jugador
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Calcular la direcci�n desde el centro del �rea de explosi�n hasta el jugador
                    Vector2 direction = (collider.transform.position - transform.position).normalized;

                    // Aplicar la fuerza de explosi�n al jugador
                    rb.AddForce(direction * explosionForce);
                }
            }
        }
    }
}

