using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorObjetos : MonoBehaviour
{
    public GameObject objetoPrefab; // Objeto que se lanzar�
    public Transform puntoInicial; // Punto desde donde se lanzar� el objeto
    public float fuerzaMinima = 5f; // Fuerza m�nima para el lanzamiento
    public float fuerzaMaxima = 10f; // Fuerza m�xima para el lanzamiento
    public float tiempoMinimo = 1f; // Tiempo m�nimo antes de lanzar otro objeto
    public float tiempoMaximo = 3f; // Tiempo m�ximo antes de lanzar otro objeto
    public bool tiempoAleatorio = false; // Opci�n para usar tiempo aleatorio entre lanzamientos

    private Rigidbody2D rb2D; // Rigidbody2D del objeto lanzado

    private void Start()
    {
        StartCoroutine(LanzarConIntervalo());
    }

    IEnumerator LanzarConIntervalo()
    {
        while (true)
        {
            // Esperar un tiempo antes de lanzar otro objeto
            float tiempoEspera = tiempoAleatorio ? Random.Range(tiempoMinimo, tiempoMaximo) : tiempoMinimo;
            yield return new WaitForSeconds(tiempoEspera);

            // Lanzar el objeto
            LanzarObjeto();
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
}

