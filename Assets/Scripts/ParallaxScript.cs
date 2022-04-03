using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float _lenght;
    private float _startPos;
    [SerializeField] private GameObject _cam;
    [SerializeField] float _speed;

    private void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float _temp = (_cam.transform.position.x * (1 - _speed));
        float _dist = (_cam.transform.position.x * _speed);

        transform.position = new Vector3(_startPos + _dist, transform.position.y, transform.position.z);

        if (_temp > _startPos + _lenght)
        {
            _startPos += _lenght;
        }
        else if (_temp < _startPos - _lenght)
        {
            _startPos -= _lenght;
        }
    }
}
