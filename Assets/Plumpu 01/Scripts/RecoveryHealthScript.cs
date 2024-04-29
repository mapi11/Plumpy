using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryHealthScript : MonoBehaviour
{
    HealthsScript _healthsScript;
    private bool IsHeal;

    private void Start()
    {
        _healthsScript = FindObjectOfType<HealthsScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_healthsScript.Health < _healthsScript.MaxHP)
        {
            if (other.gameObject.tag == "Player")
            {
                _healthsScript.Heal();
                Destroy(gameObject);
            }
        }

    }
}
