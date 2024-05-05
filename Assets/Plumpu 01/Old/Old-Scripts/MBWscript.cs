using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBWscript : MonoBehaviour
{
    public GameObject Canvas2D;
    public GameObject Canvas1D;

    //public GameObject MBWbutton;

    public GameObject MBWblock2D;
    public GameObject MBWblock1D;

    NewPlayerScript MBWPlayer;

    private void Update()
    {

    }

    private void Start()
    {
        MBWPlayer = FindAnyObjectByType<NewPlayerScript>();
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag.Equals("Player") && MBWPlayer.MBWactive2D == true) 
        {
            Canvas2D.SetActive(true); //2D
        }
        if (collision.gameObject.tag.Equals("Player") && MBWPlayer.MBWactive1D == true)
        {
            Canvas1D.SetActive(true); //1D
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Canvas2D.SetActive(false); //2D
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            Canvas1D.SetActive(false); //1D
        }
    }
    public void MBWblockBtton2D()
    {
        if (MBWPlayer.MBWactive2D == true)
        {
            MBWblock2D.SetActive(false);
            MBWblock1D.SetActive(true);
        }
    }
    public void MBWblockBtton1D()
    {
        if (MBWPlayer.MBWactive1D == true)
        {
            MBWblock2D.SetActive(true);
            MBWblock1D.SetActive(false);
        }
    }
}
