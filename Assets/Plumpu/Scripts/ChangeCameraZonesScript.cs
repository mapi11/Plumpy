using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraZonesScript : MonoBehaviour
{
    private GameObject _btn1D;
    private GameObject _btn2D;
    private GameObject _btn3D;

    [SerializeField] private bool _1D;
    [SerializeField] private bool _2D = true;
    [SerializeField] private bool _3D;

    MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _btn1D = GameObject.Find("Btn1D");
        _btn2D = GameObject.Find("Btn2D");
        _btn3D = GameObject.Find("Btn3D");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_1D &&  _2D && !_3D) // 1D + 2D
            {
                _btn3D.SetActive(false);

                if (_mainCharacterControllerScript.Active1D)
                {

                }
                else if (!_mainCharacterControllerScript.Active2D)
                {
                    _mainCharacterControllerScript.PlayerActive2D();
                }
            }
            else if (_1D && !_2D && _3D) // 1D + 3D
            {
                _btn2D.SetActive(false);

                if (_mainCharacterControllerScript.Active1D)
                {
                    
                }
                else if (!_mainCharacterControllerScript.Active3D)
                {
                    _mainCharacterControllerScript.PlayerActive1D();
                }
            }
            else if (!_1D && _2D && _3D) // 2D + 3D
            {
                _btn1D.SetActive(false);

                if (_mainCharacterControllerScript.Active2D)
                {

                }
                else if (!_mainCharacterControllerScript.Active3D)
                {
                    _mainCharacterControllerScript.PlayerActive2D();
                }
            }
            else if (!_1D && _2D && _3D) // 1D + 3D
            {
                _btn1D.SetActive(false);

                if (_mainCharacterControllerScript.Active1D)
                {

                }
                else if (!_mainCharacterControllerScript.Active3D)
                {
                    _mainCharacterControllerScript.PlayerActive1D();
                }
            }

            else if (_1D) // 1D
            {
                _btn2D.SetActive(false);
                _btn3D.SetActive(false);
                if (!_mainCharacterControllerScript.Active1D)
                {
                    _mainCharacterControllerScript.PlayerActive1D();
                }
            }
            else if (_2D) // 2D
            {
                _btn1D.SetActive(false);
                _btn3D.SetActive(false);
                if (!_mainCharacterControllerScript.Active2D)
                {
                    _mainCharacterControllerScript.PlayerActive2D();
                }
            }
            else if (_3D) // 3D
            {
                _btn2D.SetActive(false);
                _btn1D.SetActive(false);
                if (!_mainCharacterControllerScript.Active3D)
                {
                    _mainCharacterControllerScript.PlayerActive3D();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _btn1D.SetActive(true);
            _btn2D.SetActive(true);
            _btn3D.SetActive(true);
        }
    }
}
