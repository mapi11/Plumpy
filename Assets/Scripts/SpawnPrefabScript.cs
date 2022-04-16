using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;
    private int _int;
    [SerializeField] private int Raduis;
    private void Start()
    {
        _int = Random.Range(0, Raduis);
        Instantiate(_prefab[_int],transform.position,transform.rotation);
    }
}