using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityGroundScript : MonoBehaviour
{
    private float _lenght;
    private float _startPos;
    private GameObject _cam;

    private void Start()
    {
        _cam = GameObject.Find("Character-2D");

        _startPos = transform.position.x;
        _lenght = GetComponent<MeshRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float _temp = (_cam.transform.position.x * (1 - 0));
        float _dist = (_cam.transform.position.x * 0);

        transform.position = new Vector3(_startPos + _dist, transform.position.y, transform.position.z);

        if (_temp > _startPos + _lenght/2)
        {
            _startPos += _lenght;
        }
        else if (_temp < _startPos - _lenght/2)
        {
            _startPos -= _lenght;
        }
    }
}
