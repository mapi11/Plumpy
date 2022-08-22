using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreassurePlateScript : MonoBehaviour
{
    [SerializeField] private Vector3 _originalPos;
    bool _moveBack = false;

    private void Start()
    {
        _originalPos = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            transform.Translate(0, -0.1f, 0);
            _moveBack = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.parent = transform;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            _moveBack = true;
            collision.transform.parent = null;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void Update()
    {
        if (_moveBack)
        {
            if (transform.position.y < _originalPos.y)
            {
                transform.Translate(0, 0.1f, 0);
            }
            else
            {
                _moveBack = false;
            }
        }
    }
}
