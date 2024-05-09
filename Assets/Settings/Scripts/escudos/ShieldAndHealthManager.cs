using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAndHealthManager : MonoBehaviour
{
    public Shield shield; // Referencia al script del escudo
    public PlayerHealth playerHealth; // Referencia al script de la salud del jugador

    private bool isShieldAcquired = false; // Variable para controlar si se adquiri� un escudo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtener el tag del objeto que colisiona con el jugador
        string otherTag = collision.gameObject.tag;

        // Verificar si el objeto que colisiona tiene un tag que puede da�ar al jugador
        if (IsValidTag(otherTag))
        {
            // Verificar si el escudo est� activo
            if (shield.IsShieldActive())
            {
                // Si el escudo est� activo, aplicar da�o al escudo
                shield.TakeDamage(1);

                if (shield.currentShieldHealth <= 0f)
                {
                    // Si el escudo se ha agotado, aplicar el da�o restante a la salud del jugador
                    float remainingDamage = Mathf.Abs(shield.currentShieldHealth);
                    playerHealth.TakeDamage(remainingDamage);
                    isShieldAcquired = false; // Indicar que el escudo ha sido agotado
                }
            }
            else
            {
                // Si el escudo no est� activo, aplicar directamente el da�o a la salud del jugador
                float damageAmount = GetDamageByTag(otherTag);
                playerHealth.TakeDamage(damageAmount);

                // Verificar si el jugador adquiri� un escudo
                if (!isShieldAcquired && otherTag == "Shield")
                {
                    // Si el jugador adquiri� un escudo, recargar el escudo
                    shield.RechargeShield();
                    isShieldAcquired = true; // Indicar que se ha adquirido un escudo
                }
            }
        }
    }

    // M�todo para verificar si un tag es v�lido para causar da�o al jugador
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

    // M�todo para obtener la cantidad de da�o asociada a un tag
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








