using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PressureButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject _parentObj;
    [SerializeField] private GameObject _boxSpawner;
    [SerializeField] private GameObject _canvas;
    Animator _anim;

    //[SerializeField] private bool _IsSpawnedBlock;

    private void Start()
    {
        _anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Enter");
            _canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Exit");
            _canvas.SetActive(false);
        }
    }

    public void PressureButton()
    {
        //if (_IsSpawnedBlock == false)
        //{
            Instantiate(_obj, _boxSpawner.transform.position, _boxSpawner.transform.rotation, _parentObj.transform);
            //_IsSpawnedBlock = true;
        //}
        //else
        //{
        //    //Destroy(_obj);
        //    _IsSpawnedBlock = false;
        //}

    }
}
