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
        //for (int i = 0; i < Raduis; i++)
        //{
        //    Debug.Log(Random.Range(1, Raduis));
        //}

        _int = Random.Range(0, Raduis);

        if (_int == 0)
        {
            ParralaxBackground[0].SetActive(true);
        }
        if (_int == 1)
        {
            ParralaxBackground[1].SetActive(true);
        }
        if (_int == 2)
        {
            ParralaxBackground[2].SetActive(true);
        }
        if (_int == 3)
        {
            ParralaxBackground[3].SetActive(true);
        }

    }
}
