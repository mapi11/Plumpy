using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryHealthScript : MonoBehaviour
{
    CharacterHealthScript _healthsScript;
    private bool IsHeal;

    private void Start()
    {
        _healthsScript = FindAnyObjectByType<CharacterHealthScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_healthsScript._health < _healthsScript._maxHp)
        {
            if (other.gameObject.tag == "Player")
            {
                _healthsScript.Heal();
                Destroy(gameObject);
            }
        }

    }
}
