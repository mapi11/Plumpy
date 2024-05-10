using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenSettingsScript : MonoBehaviour
{
    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _btnPauseOn;

    [Space]
    [Header("Windows")]
    [SerializeField] private Transform WindowsContent;
    [SerializeField] private GameObject Settings;

    private void Awake()
    {
        _btnPauseOn.onClick.AddListener(OpenSettings);
    }

    void OpenSettings()
    {
        Settings.gameObject.SetActive(true);
        Instantiate(Settings, WindowsContent);

        Time.timeScale = 0;
    }
}
