using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class AddZoneScript : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;

    [SerializeField] private TextMeshProUGUI _txtReward;
    [SerializeField] private int _intReward;

    public MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _intReward = PlayerPrefs.GetInt("intAdd");
        _txtReward.text = _intReward.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sdk._RewardedShow(1);
            _mainCharacterControllerScript.ButtonStop();
        }
    }

    public void AddReward()
    {
        _intReward += 1;
        _txtReward.text = _intReward.ToString();
        PlayerPrefs.SetInt("intAdd", _intReward);
    }
}
