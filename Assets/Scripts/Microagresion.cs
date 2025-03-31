using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Microagresion : MonoBehaviour
{
    public AudioClip microaggressionAudio; // Audio de la microagresión
    public string microaggressionSubtitle; // Texto del subtítulo
    public GameObject subtitlesPanel; // Panel UI para mostrar subtítulos (TextMesh Pro Text)
    public TextMeshProUGUI subtitlesText; // Componente TextMesh Pro para los subtítulos
    public GameObject decisionPanel; // Panel UI para las decisiones (Ignorar/Confrontar)
    private bool microaggressionActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !microaggressionActive) // Comprueba si es el jugador y si la microagresión no está activa ya
        {
            TriggerMicroaggression();
        }
    }

    public void TriggerMicroaggression()
    {
        microaggressionActive = true;
        // Activar audio
        if (microaggressionAudio != null)
        {
            AudioSource.PlayClipAtPoint(microaggressionAudio, transform.position); // Reproduce el audio en la posición de la zona
        }

        // Mostrar subtítulos
        if (subtitlesPanel != null && subtitlesText != null)
        {
            subtitlesText.text = microaggressionSubtitle;
            subtitlesPanel.SetActive(true); // Muestra el panel de subtítulos
        }

        // Mostrar panel de decisiones (lo implementaremos en el siguiente paso)
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(true); // Muestra el panel de decisiones
        }
    }

    public void HideSubtitlesAndDecisionPanel() // Función para ocultar subtítulos y decisiones después de la interacción
    {
        if (subtitlesPanel != null) subtitlesPanel.SetActive(false);
        if (decisionPanel != null) decisionPanel.SetActive(false);
        microaggressionActive = false; // Permite activar la microagresión de nuevo si el usuario vuelve a entrar en la zona (opcional, depende de cómo quieres que funcione)
    }
}
