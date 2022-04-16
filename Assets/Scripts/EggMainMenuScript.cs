using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMainMenuScript : MonoBehaviour
{
    private int TapCount;
    [SerializeField] private GameObject _image;

    public void Taps()
    {
        TapCount++;
    }
    private void FixedUpdate()
    {
        if (TapCount == 5)
        {
            _image.SetActive(true);
        }
        if (TapCount == 6)
        {
            _image.SetActive(false);
            Destroy(gameObject);
        }
    }
}
