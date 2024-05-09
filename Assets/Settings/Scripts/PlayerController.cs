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

            // Reducir la vida solo si el objeto colisionado tiene un tag v�lido para causar da�o.
            if (IsValidTag(tag))
            {
                lifeBar.ReducirVida(tag);
                break; // Salir del bucle despu�s de encontrar la primera colisi�n v�lida.
            }
        }
    }

    bool IsValidTag(string tag)
    {
        // Aqu� puedes definir qu� tags deben causar da�o al jugador.
        // Por ejemplo, si solo quieres que los objetos con tag "Enemigo" causen da�o:
        return tag == "Enemigo";
    }
}

