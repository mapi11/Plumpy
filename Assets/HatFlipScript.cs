using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatFlipScript : MonoBehaviour
{
    public PickUpHatScript _pickUpHatScript;
    [SerializeField] private SpriteRenderer _hatSpriteRenderer;
    [SerializeField] private Button _takeOffHat;
    [SerializeField] private GameObject _hatPrefab;

    MainCharacterControllerScript _mainCharacterControllerScript;

    void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _takeOffHat.onClick.AddListener(TakeOffHat);
    }
    
    private void Update()
    {
        if (_pickUpHatScript._hatIsPicked == true)
        {
            if (_mainCharacterControllerScript._lookRight == true)
            {
                _hatSpriteRenderer.flipX = true;
            }
            else
            {
                _hatSpriteRenderer.flipX = false;
            }
        }
    }

    private void TakeOffHat()
    {
        if (_pickUpHatScript._hatIsPicked == true)
        {
            Destroy(gameObject);
        }
    }
}