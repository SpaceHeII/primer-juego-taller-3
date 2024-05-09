using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    private bool isIdle = true;
    private bool playerEntered = false; // Variable para rastrear si el jugador ha entrado en la zona de ataque

    public float delayBeforeDestroy = 2f; // Tiempo de espera antes de destruir el objeto después de la animación de ataque

    private bool isDestroying = false; // Variable para rastrear si el objeto está siendo destruido

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detectar al jugador en el rango de detección
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0)
        {
            // Si hay al menos un collider de jugador detectado, activamos la animación de ataque
            animator.SetBool("ZonaAtaque", true);
            isIdle = false;
            playerEntered = true;

            // Si el objeto no está siendo destruido y el jugador acaba de entrar en la zona de ataque, iniciar cuenta regresiva para destrucción
            if (!isDestroying)
            {
                isDestroying = true;
                StartCoroutine(DestruirDespuesDeTiempo(delayBeforeDestroy));
            }
        }
        else
        {
            // Si no hay colliders de jugador detectados, volvemos a la animación de espera (idle)
            animator.SetBool("ZonaAtaque", false);
            isIdle = true;
            playerEntered = false;
        }
    }

    // Método para activar la animación de ataque y empezar a contar el tiempo antes de destruir
    void ActivarAtaque()
    {
        // Activar la animación de ataque
        animator.SetTrigger("Ataque");

        // Iniciar la corutina para destruir el GameObject después de un tiempo
        StartCoroutine(DestruirDespuesDeTiempo(delayBeforeDestroy));
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Destruir el GameObject después del tiempo especificado
        Destroy(gameObject);
    }

    // Método para dibujar el WireSphere en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}