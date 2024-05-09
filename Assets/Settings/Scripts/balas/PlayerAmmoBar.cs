using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoBar : MonoBehaviour
{
    public Image ammoBar; // Referencia a la barra de balas en el UI
    public CantidadBalas playerAmmo; // Referencia al script de la cantidad de balas del jugador

    void Start()
    {
        // Actualizar la barra de balas al inicio
        UpdateAmmoBar();
    }

    void Update()
    {
        // Actualizar la barra de balas en cada frame (opcional, dependiendo del rendimiento)
        UpdateAmmoBar();
    }

    // Método para actualizar la barra de balas
    void UpdateAmmoBar()
    {
        // Calcular el porcentaje de balas actuales del jugador
        float ammoPercent = (float)playerAmmo.currentBalas / playerAmmo.maxBalas;

        // Actualizar la barra de balas en el UI
        ammoBar.fillAmount = ammoPercent;
    }
}
