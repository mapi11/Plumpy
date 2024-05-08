using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounterScript : MonoBehaviour
{
    [Space]
    [Header("Show FPS")]
    private float fps;
    [SerializeField] private TMPro.TextMeshProUGUI FpsCounter;

    private void Awake()
    {
        InvokeRepeating("GetFps", 0.1f, 0.1f);
    }
    void GetFps()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        FpsCounter.text = "FPS: " + fps.ToString();
    }
}
