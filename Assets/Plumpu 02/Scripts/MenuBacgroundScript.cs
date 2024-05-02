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

    private void SetBackground(int SetGraph)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(_prefabBackground[SetGraph], gameObject.transform);

        _btnBackground[0].GetComponent<Image>().color = SetGraph == 0 ? Color.gray : Color.white;
        _btnBackground[1].GetComponent<Image>().color = SetGraph == 1 ? Color.gray : Color.white;
        _btnBackground[2].GetComponent<Image>().color = SetGraph == 2 ? Color.gray : Color.white;
        _btnBackground[3].GetComponent<Image>().color = SetGraph == 3 ? Color.gray : Color.white;
        _btnBackground[4].GetComponent<Image>().color = SetGraph == 4 ? Color.gray : Color.white;
        _btnBackground[5].GetComponent<Image>().color = SetGraph == 5 ? Color.gray : Color.white;

        SavePrefScript.Save(SavePrefScript.PrefTypes.Background, SetGraph);
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
