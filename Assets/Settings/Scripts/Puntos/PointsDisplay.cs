using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    private PointsSystem pointsSystem;
    private TMP_Text textField;

    void Start()
    {
        // Obtener referencia al sistema de puntos
        pointsSystem = FindObjectOfType<PointsSystem>();

        // Obtener referencia al componente TextMeshPro
        textField = GetComponent<TMP_Text>();

        // Actualizar el texto inicialmente
        UpdatePointsText();
    }

    void Update()
    {
        // Actualizar el texto si los puntos cambian
        UpdatePointsText();
    }

    // Método para actualizar el texto con los puntos acumulados
    void UpdatePointsText()
    {
        // Obtener los puntos acumulados del sistema de puntos
        float points = pointsSystem.GetPoints();

        // Formatear los puntos como números enteros
        int pointsAsInt = Mathf.RoundToInt(points);

        // Actualizar el texto en el TextMeshPro
        textField.text = "Puntos: " + pointsAsInt.ToString();
    }
}

