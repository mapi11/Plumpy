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
    [Header("Music Buttons")]
    [SerializeField] private Button _btnOffMusic;
    [SerializeField] private Button _btnChangeMusic;
    [SerializeField] private GameObject _windowChangeMusic;

    [Space]
    [Header("Image Buttons")]
    [SerializeField] private GameObject ImgOn;
    [SerializeField] private GameObject ImgOff;

    int muted = 1;
    bool SettingsBool = true;

    private void Awake()
    {
        LoadMusic();
        MusicController();

        _btnChangeMusic.onClick.AddListener(ChangeMusic);

        _btnOffMusic.onClick.AddListener(MusicController);

        volumeSlider.onValueChanged.AddListener((V) =>
        {
            volumeText.text = V.ToString("0.00");
            PlayerPrefs.SetFloat("volumeValue", V);
        });
        AudioListener.volume = 0.5f;
        LoadValues();
    }

    private void Update()
    {
        float volumeValue = volumeSlider.value;
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

    void ChangeMusic()
    {
        if (SettingsBool != false)
        {
            _windowChangeMusic.gameObject.SetActive(true);
            SettingsBool = false;
        }
        else
        {
            _windowChangeMusic.gameObject.SetActive(false);
            SettingsBool = true;
        }
    }
}
