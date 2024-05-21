using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class PickUpHatScript : MonoBehaviour
{
    [Space]
    [Header("Hat")]
    [SerializeField] private SpriteRenderer _hat;
    [SerializeField] private Transform _hatPivot;
    public bool _hatIsPicked;
    public bool _hatFliped;
    

    [Space]
    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnPickUpHat;
    [SerializeField] private Button _btnTakeOffHat;

    MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _btnPickUpHat.onClick.AddListener(PickUpHat);

        _hatPivot = GameObject.Find("HatPivot").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(false);
        }
    }

    void PickUpHat()
    {
        //if (_mainCharacterControllerScript.Active3D != true )
        //{
            if (_mainCharacterControllerScript._isFliped == true)
            {
                _hat.flipX = true;
            }
            else if ((_mainCharacterControllerScript._isFliped == false))
            {
                _hat.flipX = false;
            }
            Vector3 SvipePosition = gameObject.transform.localScale;
            SvipePosition.x = 1;
            gameObject.transform.localScale = SvipePosition; //svipe

            _btnPickUpHat.gameObject.SetActive(false);
            _btnTakeOffHat.gameObject.SetActive(true);
            _hatIsPicked = true;

            if (_hatPivot.transform.childCount > 0)
            {
                Destroy(_hatPivot.transform.GetChild(0).gameObject);
            }

            Debug.Log("Hat picket");

            _hat.transform.parent = _hatPivot;
            _hat.transform.position = _hatPivot.position;

            Destroy(gameObject);

            //gameObject.SetActive(false);
            //Destroy(_canvas);
        //}

    }
}