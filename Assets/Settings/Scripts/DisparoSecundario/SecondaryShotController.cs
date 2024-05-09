using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryShotController : MonoBehaviour
{
    public float maxCharge = 100f; // Cantidad m�xima de carga
    public float rechargeTime = 3f; // Tiempo de recarga en segundos
    public Image progressBar; // Referencia a la barra de carga en la interfaz de usuario

    public float CurrentCharge { get; set; } // Progreso actual de la carga
    public bool CanShoot { get; set; } // Indica si se puede disparar

    private void Start()
    {
        // Al inicio de la partida, permitir que el jugador dispare y activar la recarga
        CanShoot = true;
    }

    private void Update()
    {
        // Si la carga est� completa y se presiona el bot�n derecho del rat�n, disparar
        if (CanShoot && Input.GetMouseButtonDown(1) && CurrentCharge >= maxCharge)
        {
            Shoot();
        }

        // Actualizar la barra de carga en la interfaz de usuario
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        // Incrementar la carga incluso si no se puede disparar
        CurrentCharge += (maxCharge / rechargeTime) * Time.deltaTime;
        CurrentCharge = Mathf.Clamp(CurrentCharge, 0f, maxCharge);

        // Actualizar la barra de carga en la interfaz de usuario
        progressBar.fillAmount = CurrentCharge / maxCharge;

        // Comprobar si la carga est� completa
        if (CurrentCharge >= maxCharge)
        {
            CanShoot = true;
        }
    }

    private void Shoot()
    {
        // Coloca aqu� la l�gica para realizar el disparo secundario
        Debug.Log("�Disparo secundario!");

        // Reiniciar la carga despu�s de disparar
        CurrentCharge = 0f;
        CanShoot = false;
    }
}










