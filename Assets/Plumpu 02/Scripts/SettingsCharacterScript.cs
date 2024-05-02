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

    [SerializeField] private Button _btnDelSave;

    [Space]
    [Header("Music Buttons")]
    [SerializeField] private Button[] _btnMusic;
    [SerializeField] private Button[] _btnGraphic;

    MenuMusicScript _menuMusicScript;

    void Awake()
    {
        _menuMusicScript = FindAnyObjectByType<MenuMusicScript>();

        SetMusic(SavePrefScript.Load(SavePrefScript.PrefTypes.Music));
        SetGraphic(SavePrefScript.Load(SavePrefScript.PrefTypes.Graphic));

        _btnMusic[0].onClick.AddListener(() => SetMusic(0));
        _btnMusic[1].onClick.AddListener(() => SetMusic(1));
        _btnMusic[2].onClick.AddListener(() => SetMusic(2));
        _btnMusic[3].onClick.AddListener(() => SetMusic(3));
        _btnMusic[4].onClick.AddListener(() => SetMusic(4));
        _btnMusic[5].onClick.AddListener(() => SetMusic(5));
        _btnMusic[6].onClick.AddListener(() => SetMusic(6));
        _btnMusic[7].onClick.AddListener(() => SetMusic(7));

        _btnGraphic[0].onClick.AddListener(() => SetGraphic(0));
        _btnGraphic[1].onClick.AddListener(() => SetGraphic(1));
        _btnGraphic[2].onClick.AddListener(() => SetGraphic(2));
        _btnGraphic[3].onClick.AddListener(() => SetGraphic(3));

        _btnCloseSettings.onClick.AddListener(CloseSettings);

        _btnDelSave.onClick.AddListener(DelSave);
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

    private void SetGraphic(int SetGraph)
    {
        SavePrefScript.Save(SavePrefScript.PrefTypes.Graphic, SetGraph);
        QualitySettings.SetQualityLevel(SetGraph);
        _btnGraphic[0].GetComponent<Image>().color = SetGraph == 0 ? Color.gray : Color.white;
        _btnGraphic[1].GetComponent<Image>().color = SetGraph == 1 ? Color.gray : Color.white;
        _btnGraphic[2].GetComponent<Image>().color = SetGraph == 2 ? Color.gray : Color.white;
        _btnGraphic[3].GetComponent<Image>().color = SetGraph == 3 ? Color.gray : Color.white;
    }

    private void DelSave()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Save deleted");
    }
}
