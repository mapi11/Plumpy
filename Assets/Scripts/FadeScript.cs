using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private GameObject AlphgObj;
    private Image AlphaImage;
    public bool IsFade = false;

    private void Update()
    {
        //if (IsFade == true)
        //{
        //    AlphaImage = AlphgObj.GetComponent<Image>();
        //    AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a + 0.5f * Time.deltaTime);
        //    if (AlphaImage.color.a >= 1.0f)
        //    {
        //        IsFade = true;
        //    }
        //}
        //else if (IsFade == false)
        //{
        //    AlphaImage = AlphgObj.GetComponent<Image>();
        //    AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a - 0.5f * Time.deltaTime);
        //    if (AlphaImage.color.a <= 0.0f)
        //    {
        //        IsFade = false;
        //    }
        //}
    }

    public void Fade()
    {
        AlphaImage = AlphgObj.GetComponent<Image>();
        AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a + 0.5f * Time.deltaTime);
        //if (AlphaImage.color.a >= 1.0f)
        //{
        //    IsFade = true;
        //}
    }
    public void NotFade()
    {
        AlphaImage = AlphgObj.GetComponent<Image>();
        AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.g, AlphaImage.color.b, AlphaImage.color.a - 0.5f * Time.deltaTime);
        //if (AlphaImage.color.a <= 0.0f)
        //{
        //    IsFade = false;
        //}
    }
}
