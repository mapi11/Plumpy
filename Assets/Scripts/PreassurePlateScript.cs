using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreassurePlateScript : MonoBehaviour
{
    [SerializeField] private Vector3 _originalPos;
    [SerializeField] private GameObject _obj;
    Animator _anim;


    private void Start()
    {
        _originalPos = transform.position;

        _anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "PlateBlock")
        {
            Debug.Log("stay");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "PlateBlock")
        {
            Debug.Log("Enter");
            _obj.SetActive(true);

            _anim.SetBool("PlateDown", true);
            _anim.SetBool("PlateUp", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "PlateBlock")
        {
            Debug.Log("Exit");
            _obj.SetActive(false);

            _anim.SetBool("PlateUp", true);
            _anim.SetBool("PlateDown", false);
        }
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.name == "PlateBlock")
    //    {
    //        Debug.Log("stay");

    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.name == "PlateBlock")
    //    {
    //        Debug.Log("Enter");
    //        _obj.SetActive(true);
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform.name == "PlateBlock")
    //    {
    //        Debug.Log("Exit");
    //        _obj.SetActive(false);
    //    }
    //}

    private void Update()
    {

    }
}
