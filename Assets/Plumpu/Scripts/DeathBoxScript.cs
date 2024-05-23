using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxScript : MonoBehaviour
{
    CharacterHealthScript _characterHealthScript;

    private void Awake()
    {
        _characterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _characterHealthScript.Deadth();
        }
    }
}
