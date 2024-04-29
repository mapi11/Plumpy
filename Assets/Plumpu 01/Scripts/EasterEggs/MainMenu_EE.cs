using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_EE : MonoBehaviour
{
    private int TapCount;
    [SerializeField] private GameObject _image;
    [SerializeField] private GameObject Music;

    public void Taps()
    {
        TapCount++;
    }
    private void FixedUpdate()
    {
        if (TapCount == 3)
        {
            _image.SetActive(true);
            Music.SetActive(false);
        }
        if (TapCount == 4)
        {
            _image.SetActive(false);
            Music.SetActive(true);
            Destroy(gameObject);
        }
    }
}
