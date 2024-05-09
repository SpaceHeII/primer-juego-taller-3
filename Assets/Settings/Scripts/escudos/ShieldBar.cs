using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Image shieldBar; // Referencia a la barra de escudo en el UI
    public Shield shield; // Referencia al script del escudo

    void Start()
    {
        // Actualizar la barra de escudo al inicio
        UpdateShieldBar();
    }

    void Update()
    {
        // Actualizar la barra de escudo en cada frame (opcional, dependiendo del rendimiento)
        UpdateShieldBar();
    }

    // Método para actualizar la barra de escudo
    void UpdateShieldBar()
    {
        // Calcular el porcentaje de vida actual del escudo
        float shieldPercent = shield.currentShieldHealth / shield.maxShieldHealth;

        // Actualizar la barra de escudo en el UI
        shieldBar.fillAmount = shieldPercent;
    }
}

