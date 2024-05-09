using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Animator animator;
    public float bigDetectionRadius = 10f; // Radio de detección de la esfera grande
    public float smallDetectionRadius = 5f; // Radio de detección de la esfera pequeña
    public LayerMask playerLayer;

    private bool playerDetected = false; // Variable para rastrear si el jugador ha sido detectado por la esfera grande
    private bool playerEntered = false; // Variable para rastrear si el jugador ha entrado en la zona de la esfera pequeña
    public GameObject objetoPrefab; // Objeto que se lanzará
    public Transform puntoInicial; // Punto desde donde se lanzará el objeto
    public float fuerzaMinima = 5f; // Fuerza mínima para el lanzamiento
    public float fuerzaMaxima = 10f; // Fuerza máxima para el lanzamiento
    public float tiempoEspera = 3f; // Tiempo de espera entre lanzamientos

    private Rigidbody2D rb2D; // Rigidbody2D del objeto lanzado

    void Update()
    {
        // Detectar al jugador en el rango de detección de la esfera grande
        Collider2D[] bigColliders = Physics2D.OverlapCircleAll(transform.position, bigDetectionRadius, playerLayer);

        if (bigColliders.Length > 0 && !playerDetected)
        {
            // Si hay al menos un collider de jugador detectado por la esfera grande y el jugador no ha sido detectado antes, activar la animación de lanzamiento de granada
            playerDetected = true;
            animator.SetBool("LanzarGranada", true);
            StartCoroutine(LanzarConIntervalo());
        }
        else if (bigColliders.Length == 0)
        {
            // Si no hay colliders de jugador detectados por la esfera grande, desactivar la animación de lanzamiento de granada y detener la corutina
            playerDetected = false;
            animator.SetBool("LanzarGranada", false);
            StopCoroutine(LanzarConIntervalo());
        }

        // Detectar al jugador en el rango de detección de la esfera pequeña
        Collider2D[] smallColliders = Physics2D.OverlapCircleAll(transform.position, smallDetectionRadius, playerLayer);

        if (smallColliders.Length > 0)
        {
            // Si hay al menos un collider de jugador detectado por la esfera pequeña, el jugador ha entrado en la zona
            playerEntered = true;
        }
        else
        {
            // Si no hay colliders de jugador detectados por la esfera pequeña, el jugador no está en la zona
            playerEntered = false;
            // Detener la corutina cuando el jugador sale de la zona pequeña
            StopCoroutine(LanzarConIntervalo());
        }

        // Determinar qué animación activar en función de las condiciones
        if (playerEntered)
        {
            // Si el jugador está en la zona de la esfera pequeña, activar la animación "Escondido"
            animator.SetBool("Escondido", true);
        }
        else
        {
            // Si el jugador no está en la zona de la esfera pequeña, desactivar la animación "Escondido"
            animator.SetBool("Escondido", false);
        }
    }

    IEnumerator LanzarConIntervalo()
    {
        while (true)
        {
            // Lanzar el objeto
            LanzarObjeto();

            // Esperar un tiempo antes de lanzar otro objeto
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    void LanzarObjeto()
    {
        // Instanciar el objeto y obtener su Rigidbody2D
        GameObject objetoLanzado = Instantiate(objetoPrefab, puntoInicial.position, puntoInicial.rotation);
        rb2D = objetoLanzado.GetComponent<Rigidbody2D>();

        // Calcular una fuerza aleatoria
        float fuerza = Random.Range(fuerzaMinima, fuerzaMaxima);

        // Obtener la dirección de lanzamiento basada en la rotación del punto inicial
        Vector2 direccion = puntoInicial.up;

        // Aplicar la fuerza en la dirección obtenida
        rb2D.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    // Método para dibujar los WireSpheres en el editor
    void OnDrawGizmosSelected()
    {
        // Dibujar el WireSphere de la esfera grande
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bigDetectionRadius);

        // Dibujar el WireSphere de la esfera pequeña
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, smallDetectionRadius);
    }
}


