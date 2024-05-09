using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CantidadBalas : MonoBehaviour
{
    public int maxBalas = 10; // Cantidad máxima de balas
    public float tiempoRecarga = 2f; // Tiempo de recarga en segundos

    [SerializeField]
    private int _currentBalas; // Cantidad actual de balas

    public int currentBalas
    {
        get { return _currentBalas; }
        private set { _currentBalas = value; }
    }

    private float tiempoRestanteRecarga; // Tiempo restante para la próxima recarga
    private bool recargando; // Estado de recarga

    // Evento que se activa cuando se dispara una bala
    public event Action<int> OnDisparo;

    private void Start()
    {
        currentBalas = maxBalas; // Inicializar la cantidad de balas
        tiempoRestanteRecarga = tiempoRecarga; // Inicializar el tiempo de recarga
        recargando = false; // Inicializar el estado de recarga
    }

    private void Update()
    {
        // Si no estamos recargando, comenzar el conteo de recarga
        if (!recargando)
        {
            tiempoRestanteRecarga -= Time.deltaTime;

            // Si el tiempo de recarga ha transcurrido, recargar una bala
            if (tiempoRestanteRecarga <= 0f)
            {
                RecargarBala();
            }
        }
    }

    // Método para disparar una bala
    public void Disparar()
    {
        if (currentBalas > 0)
        {
            currentBalas--; // Disminuir la cantidad de balas
            OnDisparo?.Invoke(currentBalas); // Activar el evento de disparo
        }
    }

    // Método para recargar una bala
    private void RecargarBala()
    {
        if (currentBalas < maxBalas)
        {
            currentBalas++; // Incrementar la cantidad de balas
            tiempoRestanteRecarga = tiempoRecarga; // Reiniciar el tiempo de recarga
        }
    }
}