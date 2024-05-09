using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public List<string> dialogLines = new List<string>(); // Lista de diálogos

    private int currentLine = 0; // Índice del diálogo actual
    private int fPressCount = 0; // Contador de veces que se presiona la tecla F

    public int pressesToLoadScene = 5; // Cantidad de veces que se debe presionar "F" para cargar la escena
    public string sceneToLoad; // Nombre de la escena a cargar

    void Start()
    {
        dialogText.text = ""; // Limpiar el texto al iniciar
    }

    void Update()
    {
        // Avanzar al siguiente diálogo al presionar la tecla F
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
        // Verificar si hay más líneas de diálogo por mostrar
        if (currentLine < dialogLines.Count)
        {
            // Mostrar la siguiente línea de diálogo
            dialogText.text = dialogLines[currentLine];
            currentLine++;
        }
        else
        {
            // Si no hay más diálogo, limpiar el texto
            dialogText.text = "";
        }
    }

    void LoadNewScene()
    {
        // Cargar la escena nueva asignada desde el inspector
        SceneManager.LoadScene(sceneToLoad);
    }
}




