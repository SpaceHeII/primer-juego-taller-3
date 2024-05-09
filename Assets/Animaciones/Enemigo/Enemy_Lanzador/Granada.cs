using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab de la explosión
    public GameObject luzExplosion; // Efecto de luz para la explosión
    public GameObject objetoACrear; // Objeto a crear al explotar la granada
    public float tiempoExplosion = 3f; // Tiempo antes de la explosión
    public float duracionLuzExplosion = 0.5f; // Duración de la luz de la explosión
    public float rebotePercentage = 0.5f; // Porcentaje de fuerza del rebote (entre 0 y 1)

    private bool explotado = false;

    private void Start()
    {
        // Comenzar la cuenta regresiva para la explosión
        Invoke("Explotar", tiempoExplosion);
    }

    private void Explotar()
    {
        if (!explotado)
        {
            explotado = true;

            // Instanciar la explosión
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Instanciar el efecto de luz temporal
            GameObject luz = Instantiate(luzExplosion, transform.position, Quaternion.identity);
            Destroy(luz, duracionLuzExplosion);

            // Crear el objeto especificado
            Instantiate(objetoACrear, transform.position, Quaternion.identity);

            // Destruir la granada
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Calcular la fuerza de rebote
        float reboteForce = rebotePercentage * collision.relativeVelocity.magnitude;

        // Obtener la dirección opuesta al impacto
        Vector3 direccionRebote = -collision.contacts[0].normal;

        // Aplicar una fuerza aleatoria en la dirección opuesta al impacto
        GetComponent<Rigidbody>().AddForce(direccionRebote * reboteForce, ForceMode.Impulse);
    }
}

