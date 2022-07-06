using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    HealthsScript _healthsScript;

    private void Start()
    {
        _healthsScript = FindObjectOfType<HealthsScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _healthsScript.Damage();
        }
    }
}
