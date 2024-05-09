using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LifeBar lifeBar; // Referencia al script de la barra de vida.

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            GameObject otherGameObject = contact.collider.gameObject;
            string tag = otherGameObject.tag;

            // Reducir la vida solo si el objeto colisionado tiene un tag válido para causar daño.
            if (IsValidTag(tag))
            {
                lifeBar.ReducirVida(tag);
                break; // Salir del bucle después de encontrar la primera colisión válida.
            }
        }
    }

    bool IsValidTag(string tag)
    {
        // Aquí puedes definir qué tags deben causar daño al jugador.
        // Por ejemplo, si solo quieres que los objetos con tag "Enemigo" causen daño:
        return tag == "Enemigo";
    }
}

