using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAndHealthManager : MonoBehaviour
{
    public Shield shield; // Referencia al script del escudo
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador

    private bool isShieldAcquired = false; // Variable para controlar si se adquirió un escudo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtener el tag del objeto que colisiona con el jugador
        string otherTag = collision.gameObject.tag;

        // Verificar si el objeto que colisiona tiene un tag que puede dañar al jugador
        if (IsValidTag(otherTag))
        {
            // Verificar si el escudo está activo
            if (shield.IsShieldActive())
            {
                // Si el escudo está activo, aplicar daño al escudo
                shield.TakeDamage(1);

                if (shield.currentShieldHealth <= 0f)
                {
                    // Si el escudo se ha agotado, aplicar el daño restante a la salud del jugador
                    float remainingDamage = Mathf.Abs(shield.currentShieldHealth);
                    playerHealth.TakeDamage(remainingDamage);
                    isShieldAcquired = false; // Indicar que el escudo ha sido agotado
                }
            }
            else
            {
                // Si el escudo no está activo, aplicar directamente el daño a la salud del jugador
                float damageAmount = GetDamageByTag(otherTag);
                playerHealth.TakeDamage(damageAmount);

                // Verificar si el jugador adquirió un escudo
                if (!isShieldAcquired && otherTag == "Shield")
                {
                    // Si el jugador adquirió un escudo, recargar el escudo
                    shield.RechargeShield();
                    isShieldAcquired = true; // Indicar que se ha adquirido un escudo
                }
            }
        }
    }

    // Método para verificar si un tag es válido para causar daño al jugador
    private bool IsValidTag(string tag)
    {
        foreach (var tagDamage in playerHealth.damagePerTag)
        {
            if (tagDamage.tag == tag)
            {
                return true;
            }
        }
        return false;
    }

    // Método para obtener la cantidad de daño asociada a un tag
    private float GetDamageByTag(string tag)
    {
        foreach (var tagDamage in playerHealth.damagePerTag)
        {
            if (tagDamage.tag == tag)
            {
                return tagDamage.damageAmount;
            }
        }
        return 0f; // Devolver 0 si no se encuentra el tag en la lista
    }
}








