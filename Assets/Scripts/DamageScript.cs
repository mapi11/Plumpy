using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    HealthsScript _healthsScript;
    public bool test = false;
    [HideInInspector]
    public int count = 0;

    private void Start()
    {
        _healthsScript = FindObjectOfType<HealthsScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(test == false)
            {
                _healthsScript.Damage();
            }
            else
            {
                if(count == 0)
                {
                    _healthsScript.Damage();
                    count++;
                }
            } 


        }
    }
}
