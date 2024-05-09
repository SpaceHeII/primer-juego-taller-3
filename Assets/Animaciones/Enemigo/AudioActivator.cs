using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip; // Referencia al clip de audio a reproducir
    [Range(0f, 1f)] public float volume = 1f; // Volumen del audio
    public float triggerRadius = 5f; // Radio del �rea de activaci�n
    public AudioSource enemyAudioSource; // Referencia al AudioSource del enemigo

    private bool hasPlayed = false; // Variable para rastrear si el audio se ha reproducido

    void Start()
    {
        // Aseg�rate de que el AudioSource del enemigo est� apagado al inicio
        if (enemyAudioSource != null)
        {
            enemyAudioSource.Stop();
            enemyAudioSource.volume = volume; // Establece el volumen del AudioSource
        }
    }

    // M�todo llamado cuando un objeto entra en el �rea del collider
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entr� en el �rea del collider es el jugador
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Reproducir el clip de audio al entrar el jugador en el �rea definida por el collider
            if (audioClip != null && enemyAudioSource != null)
            {
                enemyAudioSource.clip = audioClip;
                enemyAudioSource.Play();
                hasPlayed = true; // Marcar como reproducido para evitar que se reproduzca m�s de una vez
            }
        }
    }

    // M�todo para dibujar el gizmo en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}



