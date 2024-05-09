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

    public float delayBeforeDestroy = 2f; // Tiempo de espera antes de destruir el objeto despu�s de la animaci�n de ataque

    private bool isDestroying = false; // Variable para rastrear si el objeto est� siendo destruido

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detectar al jugador en el rango de detecci�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0)
        {
            // Si hay al menos un collider de jugador detectado, activamos la animaci�n de ataque
            animator.SetBool("ZonaAtaque", true);
            isIdle = false;
            playerEntered = true;

            // Si el objeto no est� siendo destruido y el jugador acaba de entrar en la zona de ataque, iniciar cuenta regresiva para destrucci�n
            if (!isDestroying)
            {
                isDestroying = true;
                StartCoroutine(DestruirDespuesDeTiempo(delayBeforeDestroy));
            }
        }
        else
        {
            // Si no hay colliders de jugador detectados, volvemos a la animaci�n de espera (idle)
            animator.SetBool("ZonaAtaque", false);
            isIdle = true;
            playerEntered = false;
        }
    }

    // M�todo para activar la animaci�n de ataque y empezar a contar el tiempo antes de destruir
    void ActivarAtaque()
    {
        // Activar la animaci�n de ataque
        animator.SetTrigger("Ataque");

        // Iniciar la corutina para destruir el GameObject despu�s de un tiempo
        StartCoroutine(DestruirDespuesDeTiempo(delayBeforeDestroy));
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Destruir el GameObject despu�s del tiempo especificado
        Destroy(gameObject);
    }

    // M�todo para dibujar el WireSphere en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}