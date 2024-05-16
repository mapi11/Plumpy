using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFlipScript : MonoBehaviour
{
    MainCharacterControllerScript _mainCharacterControllerScript;
    [SerializeField] private SpriteRenderer SR2D;

    void Start()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();
    }
    
    private void Update()
    {
        if (_mainCharacterControllerScript._horSpeed < 0)
        {
            SR2D.flipX = true;
        }
        else if (_mainCharacterControllerScript._horSpeed > 0)
        {
            SR2D.flipX = false;
        }
    }
}
