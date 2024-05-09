using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject objetoAReaparecer; // Objeto que reaparecerá
    public Transform[] puntosDeRespawn; // Puntos de respawn asignados en el editor
    public float tiempoEntreRespawn = 2f; // Tiempo entre cada respawn
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde el último respawn

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si ha pasado el tiempo de respawn
        if (tiempoTranscurrido >= tiempoEntreRespawn)
        {
            // Reaparecer el objeto
            ReaparecerObjeto();

            // Reiniciar el tiempo transcurrido
            tiempoTranscurrido = 0f;
        }
    }

    // Método para reaparecer el objeto
    private void ReaparecerObjeto()
    {
        // Elegir aleatoriamente uno de los puntos de respawn
        int indiceAleatorio = Random.Range(0, puntosDeRespawn.Length);
        Transform puntoRespawn = puntosDeRespawn[indiceAleatorio];

        // Reaparecer el objeto en la posición del punto de respawn seleccionado
        Instantiate(objetoAReaparecer, puntoRespawn.position, Quaternion.identity);
    }

    // Dibujar gizmos en el editor para representar los puntos de respawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (Transform puntoRespawn in puntosDeRespawn)
        {
            Gizmos.DrawWireSphere(puntoRespawn.position, 0.1f);
        }
    }
}
