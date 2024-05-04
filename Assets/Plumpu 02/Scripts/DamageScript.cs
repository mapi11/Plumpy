using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    CharacterHealthScript _healthsScript;
    public bool test = false;
    [HideInInspector]
    public int count = 0;

    private void Start()
    {
        _healthsScript = FindAnyObjectByType<CharacterHealthScript>();
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
