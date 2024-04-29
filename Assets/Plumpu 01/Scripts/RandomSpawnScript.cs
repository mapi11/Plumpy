using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject[] ParralaxBackground;
    private int _int;
    public int Raduis = 4;
    private void Start()
    {
        _int = Random.Range(0, Raduis);
        ParralaxBackground[_int].SetActive(true);
    }
}
