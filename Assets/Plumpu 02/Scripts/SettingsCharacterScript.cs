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

    [Space]
    [Header("Music Buttons")]
    [SerializeField] private Button[] _btnMusic;

    MenuMusicScript _menuMusicScript;

    void Awake()
    {
        _menuMusicScript = FindAnyObjectByType<MenuMusicScript>();

        SetMusic(SavePrefScript.Load(SavePrefScript.PrefTypes.Music));

        _btnCloseSettings.onClick.AddListener(CloseSettings);

        _btnMusic[0].onClick.AddListener(() => SetMusic(0));
        _btnMusic[1].onClick.AddListener(() => SetMusic(1));
        _btnMusic[2].onClick.AddListener(() => SetMusic(2));
        _btnMusic[3].onClick.AddListener(() => SetMusic(3));
        _btnMusic[4].onClick.AddListener(() => SetMusic(4));
        _btnMusic[5].onClick.AddListener(() => SetMusic(5));
        _btnMusic[6].onClick.AddListener(() => SetMusic(6));
        _btnMusic[7].onClick.AddListener(() => SetMusic(7));
    }

    void CloseSettings()
    {
        Time.timeScale = 1;

        Destroy(gameObject);
    }

    private void SetMusic(int setMusic)
    {
        SavePrefScript.Save(SavePrefScript.PrefTypes.Music, setMusic);
        if (_menuMusicScript._int != setMusic)
        {
            _menuMusicScript._int = setMusic;
            _menuMusicScript.MakeMusic(setMusic);

            _btnMusic[0].GetComponent<Image>().color = setMusic == 0 ? Color.gray : Color.white;
            _btnMusic[1].GetComponent<Image>().color = setMusic == 1 ? Color.gray : Color.white;
            _btnMusic[2].GetComponent<Image>().color = setMusic == 2 ? Color.gray : Color.white;
            _btnMusic[3].GetComponent<Image>().color = setMusic == 3 ? Color.gray : Color.white;
            _btnMusic[4].GetComponent<Image>().color = setMusic == 4 ? Color.gray : Color.white;
            _btnMusic[5].GetComponent<Image>().color = setMusic == 5 ? Color.gray : Color.white;
            _btnMusic[6].GetComponent<Image>().color = setMusic == 6 ? Color.gray : Color.white;
            _btnMusic[7].GetComponent<Image>().color = setMusic == 7 ? Color.gray : Color.white;
        }
    }
}
