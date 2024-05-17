using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatFlipScript : MonoBehaviour
{
    public PickUpHatScript _pickUpHatScript;
    [SerializeField] private SpriteRenderer _hatSpriteRenderer;
    [SerializeField] private Button _btnTakeOffHat;
    [SerializeField] private GameObject _hatPrefab;



    private Transform _DropPivot;

    //MainCharacterControllerScript _mainCharacterControllerScript;

    void Awake()
    {
        //_mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _DropPivot = GameObject.Find("DropObjectPivot").transform;

        _btnTakeOffHat.onClick.AddListener(TakeOffHat);
    }

    private void TakeOffHat()
    {
        Debug.Log("Take Off Hat");
        Instantiate(_hatPrefab, _DropPivot);
        _DropPivot.DetachChildren();
        Destroy(gameObject);
    }
}