using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_EE : MonoBehaviour
{
    [SerializeField] private Button _btnEgg;
    [SerializeField] private Button _btnVideo;
    [SerializeField] private GameObject _image;
    private GameObject Music;
    private int TapCount;

    private void Awake()
    {
        _btnEgg.onClick.AddListener(Taps);
        _btnVideo.onClick.AddListener(Taps);

        Music = GameObject.Find("GameMusic");
    }
    public void Taps()
    {
        TapCount++;

        if (TapCount == 3)
        {
            _image.SetActive(true);
            Music.SetActive(false);
        }
        else if (TapCount == 4)
        {
            _image.SetActive(false);
            Music.SetActive(true);
            Destroy(gameObject);
        }
    }
}
