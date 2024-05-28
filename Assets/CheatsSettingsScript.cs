using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatsSettingsScript : MonoBehaviour
{
    [SerializeField] private Button _btnCloseCheats;
    [SerializeField] private Button _btnSaveCheats;

    [Space]
    [Header("Slider speed")]
    [SerializeField] private Slider SpeedSlider = null;
    [SerializeField] private TextMeshProUGUI SppeedSliderText = null;

    [Space]
    [Header("Slider speed")]
    [SerializeField] private Slider JumpSlider = null;
    [SerializeField] private TextMeshProUGUI JumpSliderText = null;

    MainCharacterControllerScript mainCharacterControllerScript = null;


    private void Awake()
    {
        mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _btnCloseCheats.onClick.AddListener(CloseCheats);
        _btnSaveCheats.onClick.AddListener(SaveCheats);


        SpeedSlider.onValueChanged.AddListener((V) =>
        {
            SppeedSliderText.text = V.ToString("0.00");
        });
        JumpSlider.onValueChanged.AddListener((V) =>
        {
            JumpSliderText.text = V.ToString("0.00");
        
        });


        LoadValues();
    }

    private void CloseCheats()
    {
        Time.timeScale = 1;

        Destroy(gameObject);
    }

    private void SaveCheats()
    {
        PlayerPrefs.SetFloat("SpeedValue", SpeedSlider.value);
        PlayerPrefs.SetFloat("JumpValue", JumpSlider.value);

        LoadValues();
    }

    private void LoadValues()
    {
        float SpeedValue = PlayerPrefs.GetFloat("SpeedValue", 0.1f);
        SpeedSlider.value = SpeedValue;
        mainCharacterControllerScript._speed = SpeedValue;
        SpeedSlider.onValueChanged.AddListener((V) =>
        {
            SppeedSliderText.text = V.ToString("0.00");
        });

        float jumpValue = PlayerPrefs.GetFloat("JumpValue", 4f);
        JumpSlider.value = jumpValue;
        mainCharacterControllerScript._jump = jumpValue;
        JumpSlider.onValueChanged.AddListener((V) =>
        {
            JumpSliderText.text = V.ToString("0.00");
        });
    }
}