using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSceneScript : MonoBehaviour
{
    [SerializeField] GameObject Hide;
    [SerializeField] GameObject Show;
    public void HideAndShow()
    {
        Hide.SetActive(false);
        Show.SetActive(true);
    }
    //public void ShowObject()
    //{
    //    gameObject.SetActive(false);
    //}
}
