using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip; // Referencia al clip de audio a reproducir
    [Range(0f, 1f)] public float volume = 1f; // Volumen del audio
    public float triggerRadius = 5f; // Radio del área de activación
    public AudioSource enemyAudioSource; // Referencia al AudioSource del enemigo

    private bool hasPlayed = false; // Variable para rastrear si el audio se ha reproducido

    void Start()
    {
        // Asegúrate de que el AudioSource del enemigo esté apagado al inicio
        if (enemyAudioSource != null)
        {
            enemyAudioSource.Stop();
            enemyAudioSource.volume = volume; // Establece el volumen del AudioSource
        }
    }

    // Método llamado cuando un objeto entra en el área del collider
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró en el área del collider es el jugador
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Reproducir el clip de audio al entrar el jugador en el área definida por el collider
            if (audioClip != null && enemyAudioSource != null)
            {
                enemyAudioSource.clip = audioClip;
                enemyAudioSource.Play();
                hasPlayed = true; // Marcar como reproducido para evitar que se reproduzca más de una vez
            }
        }
    }

    // Método para dibujar el gizmo en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}



