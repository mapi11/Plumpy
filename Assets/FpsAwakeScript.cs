using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAwakeScript : MonoBehaviour
{
    public Transform parentObject = null;
    public int showFps = 0;

    private void Awake()
    {
        parentObject = GameObject.Find("ParentFps").transform;
    }

    private void Start()
    {
        FpsAwake();
    }

    void FpsAwake()
    {
        int FpsBool = PlayerPrefs.GetInt("FpsBool");
        showFps = FpsBool;

        if (parentObject != null)
        {
            if (showFps == 0)
            {
                parentObject.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                parentObject.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
