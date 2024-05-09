using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeapon : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserSpawnPoint;
    public Animator animator;

    public float chargeTime = 2f;
    public float attackTime = 1f;
    public float cooldownTime = 3f;

    private enum WeaponState { Charging, Attacking, Cooldown }
    private WeaponState currentState = WeaponState.Charging;
    private float stateTimer = 0f;

    private void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            switch (currentState)
            {
                case WeaponState.Charging:
                    animator.SetTrigger("Charge"); // Reproduce la animación de carga
                    stateTimer = chargeTime;
                    currentState = WeaponState.Attacking;
                    break;
                case WeaponState.Attacking:
                    FireLaser();
                    stateTimer = attackTime;
                    currentState = WeaponState.Cooldown;
                    break;
                case WeaponState.Cooldown:
                    stateTimer = cooldownTime;
                    currentState = WeaponState.Charging;
                    break;
            }
        }
    }

    private void FireLaser()
    {
        animator.SetTrigger("Fire"); // Reproduce la animación de disparo
        Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
    }
}

