using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FpsCounterScript : MonoBehaviour
{
    [Header("Show FPS")]
    [SerializeField] private TextMeshProUGUI FpsCounter;
    private float fps;


    private void Awake()
    {
        InvokeRepeating("GetFps", 0.5f, 0.5f);
    }

    void GetFps()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        FpsCounter.text = "FPS: " + fps.ToString();
    }
}
