using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsCharacterScript : MonoBehaviour
{
    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _btnCloseSettings;

    void Awake()
    {
        _btnCloseSettings.onClick.AddListener(CloseSettings);
    }

    void CloseSettings()
    {
        Time.timeScale = 1;

        Destroy(gameObject);
    }
}
