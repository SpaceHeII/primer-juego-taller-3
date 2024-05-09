using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionSystem : MonoBehaviour
{
    public UnityEvent onEnter, onStay, onExit;
    public string collisionTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onStay.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onExit.Invoke();
        }
    }
}
