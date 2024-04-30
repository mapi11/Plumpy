using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuCanvas : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Button _settingsButton;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private Transform SettingsContent;

    private void Awake()
    {
        _settingsButton.onClick.AddListener(OpenSettings);
    }

    void OpenSettings()
    {
        _settingsWindow.gameObject.SetActive(true);
        Instantiate(_settingsWindow, SettingsContent);

        Time.timeScale = 0;
    }

}
