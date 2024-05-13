using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    CharacterHealthScript _haracterHealthScript;
    [SerializeField] private int _damage = 1;
    //[SerializeField] private Collider _collider;
    string playerTag = "Player";

    private void Start()
    {
        _haracterHealthScript = FindAnyObjectByType<CharacterHealthScript>();

        //_collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(_collider);
        if (other.CompareTag(playerTag))
        {
            _haracterHealthScript.Damage(_damage);
        }
    }
}