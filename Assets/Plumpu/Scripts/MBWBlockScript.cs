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
    private bool InsideTrigger = false;

    MainCharacterControllerScript _mainCharacterControllerScript;


    private void Start()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_mainCharacterControllerScript.Active2D == true)
            {
                _canvas1D.SetActive(false);
                _canvas2D.SetActive(true);
            }
            if (_mainCharacterControllerScript.Active1D == true)
            {
                _canvas1D.SetActive(true);
                _canvas2D.SetActive(false);
            }
            InsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas1D.SetActive(false);
            _canvas2D.SetActive(false);

            InsideTrigger = false;
        }
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
        if (_mainCharacterControllerScript.Active2D && ButtonIsClick == false)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(true);
            if (InsideTrigger == true)
            {
                _canvas2D.SetActive(true);
            }
        }
        if (_mainCharacterControllerScript.Active2D && ButtonIsClick == true)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(false);
            if (InsideTrigger == true)
            {
                _canvas2D.SetActive(false);
            }
        }
        if (_mainCharacterControllerScript.Active1D && ButtonIsClick == true)
        {
            MBW1D.SetActive(true);
            MBW2D.SetActive(false);
            if (InsideTrigger == true)
            {
                _canvas1D.SetActive(true);
            }
        }
        if (_mainCharacterControllerScript.Active1D && ButtonIsClick == false)
        {
            MBW1D.SetActive(false);
            MBW2D.SetActive(false);
            if (InsideTrigger == true)
            {
                _canvas1D.SetActive(false);
            }
        }
        if (_mainCharacterControllerScript.Active3D == true)
        {
            _canvas1D.SetActive(false);
            _canvas2D.SetActive(false);
        }
    }
}
