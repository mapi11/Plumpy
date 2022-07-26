using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    //[SerializeField] Image SoundOnIcon;
    //[SerializeField] Image SoundOffIcon;
    private bool muted = false;


    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
             AudioListener.pause = false;
        }
    }
}
