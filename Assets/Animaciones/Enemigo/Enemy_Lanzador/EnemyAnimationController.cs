using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Animator animator;
    public float bigDetectionRadius = 10f; // Radio de detecci�n de la esfera grande
    public float smallDetectionRadius = 5f; // Radio de detecci�n de la esfera peque�a
    public LayerMask playerLayer;

    private bool playerDetected = false; // Variable para rastrear si el jugador ha sido detectado por la esfera grande
    private bool playerEntered = false; // Variable para rastrear si el jugador ha entrado en la zona de la esfera peque�a
    public GameObject objetoPrefab; // Objeto que se lanzar�
    public Transform puntoInicial; // Punto desde donde se lanzar� el objeto
    public float fuerzaMinima = 5f; // Fuerza m�nima para el lanzamiento
    public float fuerzaMaxima = 10f; // Fuerza m�xima para el lanzamiento
    public float tiempoEspera = 3f; // Tiempo de espera entre lanzamientos

    private Rigidbody2D rb2D; // Rigidbody2D del objeto lanzado

    void Update()
    {
        // Detectar al jugador en el rango de detecci�n de la esfera grande
        Collider2D[] bigColliders = Physics2D.OverlapCircleAll(transform.position, bigDetectionRadius, playerLayer);

        if (bigColliders.Length > 0 && !playerDetected)
        {
            // Si hay al menos un collider de jugador detectado por la esfera grande y el jugador no ha sido detectado antes, activar la animaci�n de lanzamiento de granada
            playerDetected = true;
            animator.SetBool("LanzarGranada", true);
            StartCoroutine(LanzarConIntervalo());
        }
        else if (bigColliders.Length == 0)
        {
            // Si no hay colliders de jugador detectados por la esfera grande, desactivar la animaci�n de lanzamiento de granada y detener la corutina
            playerDetected = false;
            animator.SetBool("LanzarGranada", false);
            StopCoroutine(LanzarConIntervalo());
        }

        // Detectar al jugador en el rango de detecci�n de la esfera peque�a
        Collider2D[] smallColliders = Physics2D.OverlapCircleAll(transform.position, smallDetectionRadius, playerLayer);

        if (smallColliders.Length > 0)
        {
            // Si hay al menos un collider de jugador detectado por la esfera peque�a, el jugador ha entrado en la zona
            playerEntered = true;
        }
        else
        {
            // Si no hay colliders de jugador detectados por la esfera peque�a, el jugador no est� en la zona
            playerEntered = false;
            // Detener la corutina cuando el jugador sale de la zona peque�a
            StopCoroutine(LanzarConIntervalo());
        }

        // Determinar qu� animaci�n activar en funci�n de las condiciones
        if (playerEntered)
        {
            // Si el jugador est� en la zona de la esfera peque�a, activar la animaci�n "Escondido"
            animator.SetBool("Escondido", true);
        }
        else
        {
            // Si el jugador no est� en la zona de la esfera peque�a, desactivar la animaci�n "Escondido"
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

        // Obtener la direcci�n de lanzamiento basada en la rotaci�n del punto inicial
        Vector2 direccion = puntoInicial.up;

        // Aplicar la fuerza en la direcci�n obtenida
        rb2D.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }

    // M�todo para dibujar los WireSpheres en el editor
    void OnDrawGizmosSelected()
    {
        // Dibujar el WireSphere de la esfera grande
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bigDetectionRadius);

        // Dibujar el WireSphere de la esfera peque�a
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, smallDetectionRadius);
    }
}


