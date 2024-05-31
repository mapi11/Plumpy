using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;
using System.Threading;

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

    [Space]
    [Header("Language")]
    [SerializeField] private TMP_Dropdown _dropdown;
    //private int _intGraphic;

    MenuMusicScript _menuMusicScript;
    ManagerSceneScript _managerSceneScript;

    void Awake()
    {
        //_menuMusicScript = FindAnyObjectByType<MenuMusicScript>();
        _managerSceneScript = FindAnyObjectByType<ManagerSceneScript>();

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

        SetMusic(SavePrefScript.Load(SavePrefScript.PrefTypes.Music));
        SetGraphic(SavePrefScript.Load(SavePrefScript.PrefTypes.Graphic));
        LocaleSelected(SavePrefScript.Load(SavePrefScript.PrefTypes.Languages));

        //_btnMusic[_menuMusicScript._int].interactable = false;

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
        _menuMusicScript = FindAnyObjectByType<MenuMusicScript>();

        if (_menuMusicScript != null)
        {
            SavePrefScript.Save(SavePrefScript.PrefTypes.Music, setMusic);
            if (_menuMusicScript._int != setMusic)
            {
                _menuMusicScript._int = setMusic;
                _menuMusicScript.MakeMusic(setMusic);

                _btnMusic[0].GetComponent<Button>().interactable = setMusic == 0 ? false : true;
                _btnMusic[1].GetComponent<Button>().interactable = setMusic == 1 ? false : true;
                _btnMusic[2].GetComponent<Button>().interactable = setMusic == 2 ? false : true;
                _btnMusic[3].GetComponent<Button>().interactable = setMusic == 3 ? false : true;
                _btnMusic[4].GetComponent<Button>().interactable = setMusic == 4 ? false : true;
                _btnMusic[5].GetComponent<Button>().interactable = setMusic == 5 ? false : true;
                _btnMusic[6].GetComponent<Button>().interactable = setMusic == 6 ? false : true;
                _btnMusic[7].GetComponent<Button>().interactable = setMusic == 7 ? false : true;


            }
            _btnMusic[_menuMusicScript._int].interactable = false;
        }

    }

    private void SetGraphic(int SetGraph)
    {
        SavePrefScript.Save(SavePrefScript.PrefTypes.Graphic, SetGraph);
        QualitySettings.SetQualityLevel(SetGraph);

        _btnGraphic[0].GetComponent<Button>().interactable = SetGraph == 0 ? false : true;
        _btnGraphic[1].GetComponent<Button>().interactable = SetGraph == 1 ? false : true;
        _btnGraphic[2].GetComponent<Button>().interactable = SetGraph == 2 ? false : true;
        _btnGraphic[3].GetComponent<Button>().interactable = SetGraph == 3 ? false : true;

        //_intGraphic = SetGraph;
    }

    private void DelSave()
    {
        PlayerPrefs.DeleteAll();
        _managerSceneScript.ReloadScene();
        Debug.Log("Save deleted");
    }

    IEnumerator Start()
    {

        // Wait for the localization system to initialize
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        var options = new List<TMP_Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new TMP_Dropdown.OptionData(locale.name));
        }
        _dropdown.options = options;

        _dropdown.value = selected;
        _dropdown.onValueChanged.AddListener(LocaleSelected);
    }

    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        SavePrefScript.Save(SavePrefScript.PrefTypes.Languages, index);
    }
}