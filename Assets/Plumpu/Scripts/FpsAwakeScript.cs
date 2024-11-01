using UnityEngine;
using TMPro;

public class FpsAwakeScript : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // Ссылка на ваш TextMeshProUGUI компонент
    public float updateInterval = 0.5f; // Интервал обновления FPS
    private float timeElapsed = 0f;
    private int frameCount = 0;

    private void Start()
    {
        QualitySettings.vSyncCount = 2; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 165;

        if (fpsText == null)
        {
            Debug.LogError("FPSDisplay: fpsText не назначен!");
            return;
        }

        fpsText.alpha = 1; // Убедитесь, что текст видим
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        frameCount++;

        if (timeElapsed >= updateInterval)
        {
            // Рассчитываем FPS
            float fps = frameCount / timeElapsed;
            fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";

            // Сброс счетчиков
            timeElapsed = 0f;
            frameCount = 0;
        }
    }
}
