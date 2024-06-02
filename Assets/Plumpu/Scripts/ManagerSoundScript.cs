using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSoundScript : MonoBehaviour
{
    [Space]
    [Header("Slider")]
    [SerializeField] private GameObject Slider;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TextMeshProUGUI volumeText = null;

    [Space]
    [Header("Fps Buttons")]
    [SerializeField] private Button _btnShowFps;
    [SerializeField] private GameObject _thxShowFps;
    [SerializeField] private GameObject _thxHideFps;
    [SerializeField] private GameObject _txtFpsPrefab;
    Transform parentObject = null;

    [HideInInspector]
    public int showFps = 0;

    [Space]
    [SerializeField] private Transform _windowsContent;

    [Space]
    [Header("Second content")]
    [SerializeField] private Button _btnSecondContent;
    [SerializeField] private GameObject _windowSecondContent;
    [SerializeField] private GameObject _imgSecondOn;
    [SerializeField] private GameObject _imgSecondOff;

    [Space]
    [Header("Music Buttons")]
    [SerializeField] private Button _btnOffMusic;
    [SerializeField] private Button _btnChangeMusic;
    [SerializeField] private GameObject _windowChangeMusic;
    [SerializeField] private GameObject ImgOn;
    [SerializeField] private GameObject ImgOff;
    int muted = 1;

    [Space]
    [Header("Graphic Buttons")]
    [SerializeField] private Button _btnChangeGraphic;
    [SerializeField] private GameObject _windowChangeGraphic;

    [Space]
    [Header("Language Buttons")]
    [SerializeField] private Button _btnChangeLanguage;
    [SerializeField] private GameObject _windowChangeLanguag;

    [Space]
    [Header("Cheats")]
    [SerializeField] private Transform WindowsContent;

    [SerializeField] private Button _btnCheatsOn;
    [SerializeField] private GameObject CheatsWindow;

    private bool SecondContentBool = true;
    private bool MusicBool = true;
    private bool GraphicBool = true;
    private bool LanguageBool = true;

    private void Awake()
    {
        parentObject = GameObject.Find("ParentFps").transform;
        WindowsContent = GameObject.Find("WindowsContent").transform;

        LoadMusic();
        MusicController();
        LoadFps();
        FpsAwake();

        _btnSecondContent.onClick.AddListener(ChangeSecondContent);
        _btnChangeMusic.onClick.AddListener(ChangeMusic);
        _btnChangeGraphic.onClick.AddListener(ChangeGraphic);
        _btnChangeLanguage.onClick.AddListener(ChangeLanguage);

        _btnOffMusic.onClick.AddListener(MusicController);
        _btnShowFps.onClick.AddListener(FpsController);

        _btnCheatsOn.onClick.AddListener(OpenCheats);

        volumeSlider.onValueChanged.AddListener((V) =>
        {
            volumeText.text = V.ToString("0.00");
            PlayerPrefs.SetFloat("volumeValue", V);

            AudioListener.volume = V;
        });

        AudioListener.volume = 0.5f;
        LoadValues();
    }
    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue", 0.1f);
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    void LoadMusic()
    {
        int musicBool = PlayerPrefs.GetInt("MutedBool");
        muted = musicBool * -1;
    }

    void LoadFps()
    {
        int FpsBool = PlayerPrefs.GetInt("FpsBool");
        showFps = FpsBool;
    }

    public void MusicController()
    {
        if (muted == 1)
        {
            muted = -1;
            PlayerPrefs.SetInt("MutedBool", muted);
            AudioListener.pause = true;
            Slider.gameObject.SetActive(false);
            ImgOn.SetActive(true);
            ImgOff.SetActive(false);
            _btnChangeMusic.gameObject.SetActive(false);
        }
        else
        {
            muted = 1;
            PlayerPrefs.SetInt("MutedBool", muted);
            AudioListener.pause = false;
            Slider.gameObject.SetActive(true);
            ImgOn.SetActive(false);
            ImgOff.SetActive(true);
            _btnChangeMusic.gameObject.SetActive(true);
        }
    }

    public void FpsController()
    {
        if (parentObject != null)
        {
            if (showFps == 0)
            {
                showFps = 1;

                _thxShowFps.SetActive(false);
                _thxHideFps.SetActive(true);

                parentObject.GetChild(0).gameObject.SetActive(true);
                PlayerPrefs.SetInt("FpsBool", showFps);
            }
            else
            {
                showFps = 0;

                _thxShowFps.SetActive(true);
                _thxHideFps.SetActive(false);

                parentObject.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("FpsBool", showFps);
            }

            return;
        }
    }

    void FpsAwake()
    {
        int FpsBool = PlayerPrefs.GetInt("FpsBool");
        showFps = FpsBool;

        if (parentObject != null)
        {
            if (showFps == 0)
            {
                _thxShowFps.SetActive(true);
                _thxHideFps.SetActive(false);
                parentObject.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                _thxShowFps.SetActive(false);
                _thxHideFps.SetActive(true);
                parentObject.GetChild(0).gameObject.SetActive(true);
            }

            return;
        }
    }

    void OpenCheats()
    {
        CheatsWindow.gameObject.SetActive(true);
        Instantiate(CheatsWindow, WindowsContent);

        Time.timeScale = 0;
    }

    void ChangeSecondContent()
    {
        if (SecondContentBool != false)
        {
            _windowSecondContent.gameObject.SetActive(true);
            SecondContentBool = false;
            _imgSecondOn.SetActive(false);
            _imgSecondOff.SetActive(true);
        }
        else
        {
            _windowSecondContent.gameObject.SetActive(false);
            SecondContentBool = true;
            _imgSecondOn.SetActive(true);
            _imgSecondOff.SetActive(false);
        }
    }

    void ChangeMusic()
    {
        if (MusicBool != false)
        {
            _windowChangeMusic.gameObject.SetActive(true);
            MusicBool = false;
        }
        else
        {
            _windowChangeMusic.gameObject.SetActive(false);
            MusicBool = true;
        }
    }

    void ChangeGraphic()
    {
        if (GraphicBool != false)
        {
            _windowChangeGraphic.gameObject.SetActive(true);

            GraphicBool = false;

        }
        else
        {
            _windowChangeGraphic.gameObject.SetActive(false);
            GraphicBool = true;
        }
    }

    void ChangeLanguage()
    {
        if (LanguageBool != false)
        {
            _windowChangeLanguag.gameObject.SetActive(true);

            LanguageBool = false;
        }
        else
        {
            _windowChangeLanguag.gameObject.SetActive(false);
            LanguageBool = true;
        }
    }
}
