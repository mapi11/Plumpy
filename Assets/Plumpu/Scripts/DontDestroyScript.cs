using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    private static DontDestroyScript instance;
    private void Awake()
    {
        // Отключаем VSync
        QualitySettings.vSyncCount = 0;

        // Устанавливаем высокое значение для targetFrameRate
        Application.targetFrameRate = 300;

        Debug.Log("VSync Count: " + QualitySettings.vSyncCount);
        Debug.Log("Target Frame Rate: " + Application.targetFrameRate);

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
