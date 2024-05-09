using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeBar : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    public float tiempoDeRegeneracion = 5f; // Tiempo en segundos para regenerar la vida.
    private float tiempoPasadoDesdeRegeneracion = 0f;
    private bool regenerando = false;

    [System.Serializable]
    public class TagDanio
    {
        public string tag;
        public float cantidadDeDanio;
    }

    public List<TagDanio> tagsConDanio = new List<TagDanio>(); // Lista para almacenar tags y sus cantidades de daño asociadas.

    void Update()
    {
        if (!regenerando)
        {
            tiempoPasadoDesdeRegeneracion += Time.deltaTime;
            if (tiempoPasadoDesdeRegeneracion >= tiempoDeRegeneracion)
            {
                RegenerarVida();
                tiempoPasadoDesdeRegeneracion = 0f;
            }
        }
    }

    void RegenerarVida()
    {
        if (vidaActual < vidaMaxima)
        {
            vidaActual += 10f; // Ajusta el valor de regeneración como prefieras.
            vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
            ActualizarBarraDeVida();
        }
        else
        {
            regenerando = false;
        }
    }

    void ActualizarBarraDeVida()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    public void ReducirVida(string tag)
    {
        foreach (TagDanio tagDanio in tagsConDanio)
        {
            if (tag == tagDanio.tag)
            {
                vidaActual -= tagDanio.cantidadDeDanio;
                vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
                ActualizarBarraDeVida();
                break; // Terminar el bucle después de encontrar la primera coincidencia.
            }
        }
    }
}

