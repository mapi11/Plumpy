using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenSettingsScript : MonoBehaviour
{
    [SerializeField] private Transform WindowsContent;
    [Space]
    [Header("Pause")]
    [SerializeField] private Button _btnPauseOn;
    [SerializeField] private GameObject SettingsWindow;

    //[Space]
    //[Header("Settings")]
    //[SerializeField] private Button _btnCheatsOn;
    //[SerializeField] private GameObject CheatsWindow;

    private void Awake()
    {
        _btnPauseOn.onClick.AddListener(OpenSettings);
        //_btnCheatsOn.onClick.AddListener(OpenCheats);
    }

    void OpenSettings()
    {
        SettingsWindow.gameObject.SetActive(true);
        Instantiate(SettingsWindow, WindowsContent);

        Time.timeScale = 0;
    }

    //void OpenCheats()
    //{
    //    CheatsWindow.gameObject.SetActive(true);
    //    Instantiate(CheatsWindow, WindowsContent);

    //    Time.timeScale = 0;
    //}
}
