using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMovementScript : MonoBehaviour
{
    //[SerializeField] private GameObject _disbledPart;
    //[SerializeField] private bool _is2D = true;

    [Space]
    [SerializeField] private bool _movement_1D;
    [SerializeField] private bool _movement_2D;
    [SerializeField] private bool _movement_3D;

    private GameObject _mainCharacter;
    //private GameObject _character2D;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float lastInvokeTime = 0f;

    [Space]
    [SerializeField] private bool _AutoChange;

    [Space]
    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnCanvas;

    MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _mainCharacter = GameObject.Find("MainCharacter");
        //_character2D = GameObject.Find("Character-2D");

        initialPosition = transform.position;
        initialRotation = _mainCharacter.transform.rotation;

        _btnCanvas.onClick.AddListener(RotateForward);

        _canvas.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_AutoChange)
            {
                RotateForward();
            }
            else
            {
                _canvas.SetActive(true);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(false);
        }
    }

    public void RotateForward()
    {
        if (Time.time - lastInvokeTime < 1f)
        {
            return; // Если не прошло достаточно времени, выходим из метода
        }

        lastInvokeTime = Time.time; // Запоминаем время последнего вызова

        Vector3 newPosition = new Vector3(transform.position.x, _mainCharacter.transform.position.y, transform.position.z);

        if (_mainCharacterControllerScript._movementRight)
        {
            _mainCharacter.transform.rotation = Quaternion.Euler(0, 90, 0);
            _mainCharacter.transform.position = newPosition;
            _mainCharacterControllerScript._movementRight = false;

        }
        else
        {
            _mainCharacter.transform.rotation = initialRotation;
            _mainCharacter.transform.position = newPosition;
            _mainCharacterControllerScript._movementRight = true;

        }

        if (_movement_1D)
        {
            _mainCharacterControllerScript.PlayerActive1D();
        }
        else if (_movement_2D)
        {
            _mainCharacterControllerScript.PlayerActive2D();
        }
        else if (_movement_3D)
        {
            _mainCharacterControllerScript.PlayerActive3D();
        }
    }

    ////------------------------------------------------------------------Check player
    //private bool PlayerInTrigger()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

    //    foreach (Collider collider in hitColliders)
    //    {
    //        if (collider.tag == "Player")
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //public void Disble()
    //{
    //    if (_is2D == true)
    //    {
    //        _disbledPart.SetActive(false);
    //    }
    //    else
    //    {
    //        _disbledPart.SetActive(true);
    //    }
    //}

    //public void Enable()
    //{
    //    if (_is2D == true)
    //    {
    //        _disbledPart.SetActive(true);
    //    }
    //    else
    //    {
    //        _disbledPart.SetActive(false);
    //    }

    //    _canvas.SetActive(PlayerInTrigger());
    //}
}
