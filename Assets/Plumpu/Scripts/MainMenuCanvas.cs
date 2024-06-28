using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private bool _pause = true;

    [Space]
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

        if (_pause == true)
        {
            Time.timeScale = 0;
        }
    }
}
