using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;
    [SerializeField] private Transform _parent;
    private int _int;
    //[SerializeField] private int Raduis;
    private void Awake()
    {
        _int = Random.Range(0, _prefab.Length);
        Instantiate(_prefab[_int],transform.position,transform.rotation, _parent);
    }
}