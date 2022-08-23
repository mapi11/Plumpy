using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreassurePlateScript : MonoBehaviour
{
    [SerializeField] private Vector3 _originalPos;
    [SerializeField] private GameObject _obj;


    private void Start()
    {
        _originalPos = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "PlateBlock")
        {
            Debug.Log("stay");

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "PlateBlock")
        {
            Debug.Log("Enter");
            _obj.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "PlateBlock")
        {
            Debug.Log("Exit");
            _obj.SetActive(false);
        }
    }

    private void Update()
    {

    }
}
