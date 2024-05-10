using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuBackgroundScript : MonoBehaviour
{
    [Space]
    [SerializeField] private Button _btnShowBgButtons;
    [SerializeField] private GameObject _btnWindowBgButtons;

    [Space]
    [Header("Background Buttons")]
    [SerializeField] private Button[] _btnBackground;

    [Space]
    [Header("Background Buttons")]
    [SerializeField] private GameObject[] _prefabBackground;

    bool BgBool = true;

    private void Awake()
    {
        _btnShowBgButtons.onClick.AddListener(ShowBgWindow);

        SetBackground(SavePrefScript.Load(SavePrefScript.PrefTypes.Background));

        _btnBackground[0].onClick.AddListener(() => SetBackground(0));
        _btnBackground[1].onClick.AddListener(() => SetBackground(1));
        _btnBackground[2].onClick.AddListener(() => SetBackground(2));
        _btnBackground[3].onClick.AddListener(() => SetBackground(3));
        _btnBackground[4].onClick.AddListener(() => SetBackground(4));
        _btnBackground[5].onClick.AddListener(() => SetBackground(5));

    }

    private void SetBackground(int SetBack)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(_prefabBackground[SetBack], gameObject.transform);

        _btnBackground[0].GetComponent<Button>().interactable = SetBack == 0 ? false : true;
        _btnBackground[1].GetComponent<Button>().interactable = SetBack == 1 ? false : true;
        _btnBackground[2].GetComponent<Button>().interactable = SetBack == 2 ? false : true;
        _btnBackground[3].GetComponent<Button>().interactable = SetBack == 3 ? false : true;
        _btnBackground[4].GetComponent<Button>().interactable = SetBack == 4 ? false : true;
        _btnBackground[5].GetComponent<Button>().interactable = SetBack == 5 ? false : true;

        SavePrefScript.Save(SavePrefScript.PrefTypes.Background, SetBack);
    }

    void ShowBgWindow()
    {
        if (BgBool != false)
        {
            _btnWindowBgButtons.gameObject.SetActive(true);
            BgBool = false;
        }
        else
        {
            _btnWindowBgButtons.gameObject.SetActive(false);
            BgBool = true;
        }
    }
}
