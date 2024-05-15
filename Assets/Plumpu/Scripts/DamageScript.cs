using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    CharacterHealthScript _haracterHealthScript;
    [SerializeField] private int _damage = 1;

    string playerTag = "Player";

    private void Start()
    {
        _haracterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
    }

    private void OnTriggerEnter(Collider objCollider)
    {
        if (objCollider.CompareTag(playerTag))
        {
            _haracterHealthScript.Damage(_damage);
        }
    }
}