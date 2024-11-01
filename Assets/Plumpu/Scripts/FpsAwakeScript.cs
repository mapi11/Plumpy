using UnityEngine;
using TMPro;

public class FpsAwakeScript : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // ������ �� ��� TextMeshProUGUI ���������
    public float updateInterval = 0.5f; // �������� ���������� FPS
    private float timeElapsed = 0f;
    private int frameCount = 0;

    private void Start()
    {
        QualitySettings.vSyncCount = 2; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 165;

        if (fpsText == null)
        {
            Debug.LogError("FPSDisplay: fpsText �� ��������!");
            return;
        }

        fpsText.alpha = 1; // ���������, ��� ����� �����
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        frameCount++;

        if (timeElapsed >= updateInterval)
        {
            // ������������ FPS
            float fps = frameCount / timeElapsed;
            fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";

            // ����� ���������
            timeElapsed = 0f;
            frameCount = 0;
        }
    }
}
