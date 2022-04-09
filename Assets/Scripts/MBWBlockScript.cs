using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBWBlockScript : MonoBehaviour
{
    [SerializeField] private GameObject _canvas1D;
    [SerializeField] private GameObject _canvas2D;

    [SerializeField] private GameObject MBW1D;
    [SerializeField] private GameObject MBW2D;

    public bool ButtonIsClick = false;

    CharacterControllerScript Active;

    private void Start()
    {
        Active = FindObjectOfType<CharacterControllerScript>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Active.Active2D == true)
        {
            _canvas1D.SetActive(false);
            _canvas2D.SetActive(true);
        }
        if (Active.Active1D == true)
        {
            _canvas1D.SetActive(true);
            _canvas2D.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _canvas1D.SetActive(false);
        _canvas2D.SetActive(false);
    }

    public void Active2D()
    {
        ButtonIsClick = true;
    }
    public void Active1D()
    {
        ButtonIsClick = false;
    }

    private void Update()
    {
        if (Active.Active2D && ButtonIsClick == false)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(true);
        }
        if (Active.Active2D && ButtonIsClick == true)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(false);
        }
        if (Active.Active1D && ButtonIsClick == true)
        {
            MBW1D.SetActive(true);
            MBW2D.SetActive(false);
        }
        if (Active.Active1D && ButtonIsClick == false)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(false);
        }
    }
}
