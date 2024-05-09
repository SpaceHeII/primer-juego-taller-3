using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public List<string> dialogLines = new List<string>(); // Lista de di�logos

    private int currentLine = 0; // �ndice del di�logo actual
    private int fPressCount = 0; // Contador de veces que se presiona la tecla F

    public int pressesToLoadScene = 5; // Cantidad de veces que se debe presionar "F" para cargar la escena
    public string sceneToLoad; // Nombre de la escena a cargar

    void Start()
    {
        dialogText.text = ""; // Limpiar el texto al iniciar
    }

    void Update()
    {
        // Avanzar al siguiente di�logo al presionar la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            fPressCount++; // Incrementar el contador de presiones de F
            NextLine();

            // Comprobar si se ha presionado F la cantidad de veces necesarias para cargar la escena
            if (fPressCount == pressesToLoadScene)
            {
                // Cargar la escena nueva asignada desde el inspector
                LoadNewScene();
            }
        }
    }

    void NextLine()
    {
        // Verificar si hay m�s l�neas de di�logo por mostrar
        if (currentLine < dialogLines.Count)
        {
            // Mostrar la siguiente l�nea de di�logo
            dialogText.text = dialogLines[currentLine];
            currentLine++;
        }
        else
        {
            // Si no hay m�s di�logo, limpiar el texto
            dialogText.text = "";
        }
    }

    void LoadNewScene()
    {
        // Cargar la escena nueva asignada desde el inspector
        SceneManager.LoadScene(sceneToLoad);
    }
}




