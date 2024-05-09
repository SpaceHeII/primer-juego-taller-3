using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryShot : MonoBehaviour
{
    public float impulseForce = 500f; // Fuerza del impulso
    public GameObject directionObject; // Objeto que define la direcci�n del impulso

    private SecondaryShotController shotController; // Referencia al controlador de disparo secundario

    private void Start()
    {
        // Obtener el componente SecondaryShotController adjunto al jugador
        shotController = GetComponent<SecondaryShotController>();
    }

    private void Update()
    {
        // Si se hace clic derecho y la carga est� al m�ximo, ejecutar el disparo secundario
        if (Input.GetMouseButtonDown(1) && shotController != null && shotController.CanShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calcular la direcci�n desde el objeto hacia la posici�n del rat�n
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Aplicar el impulso en la direcci�n especificada
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * impulseForce, ForceMode2D.Impulse);
        }

        // Restablecer la carga despu�s de disparar
        shotController.CurrentCharge = 0f;
        shotController.CanShoot = false; // Evitar que se dispare autom�ticamente despu�s de reiniciar la carga
    }
}




