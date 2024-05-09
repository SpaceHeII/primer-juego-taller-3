using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float letterDelay = 0.1f;
    public float startDelay = 2f; // Tiempo de espera antes de que comience a escribirse el texto

    private string fullText;
    private bool isTyping = false;

    void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = "";

        StartCoroutine(StartTypingAfterDelay());
    }

    IEnumerator StartTypingAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        isTyping = true;
        foreach (char c in fullText)
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(letterDelay);
        }
        isTyping = false;
    }

    // Método para mostrar todo el texto inmediatamente
    public void ShowAllText()
    {
        if (isTyping)
        {
            StopCoroutine(ShowText());
            textMeshPro.text = fullText;
            isTyping = false;
        }
    }
}

