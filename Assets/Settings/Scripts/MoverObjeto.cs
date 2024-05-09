using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public GameObject objetoAMover; // Objeto que se moverá
    public float velocidad = 5f; // Velocidad de movimiento

    private bool jugadorDentro = false; // Indica si el jugador está dentro de la zona

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }

    private void Update()
    {
        if (jugadorDentro)
        {
            // Mover el objeto hacia arriba
            objetoAMover.transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }
    }
}