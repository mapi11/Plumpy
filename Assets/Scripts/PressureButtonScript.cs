using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PressureButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject _parentObj;
    [SerializeField] private GameObject _canvas;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enter");
            _canvas.SetActive(true);

            //_anim.SetBool("ButtonDown", true);
            //_anim.SetBool("ButtonUp", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Exit");
            _canvas.SetActive(false);

            //_anim.SetBool("ButtonUp", true);
            //_anim.SetBool("ButtonDown", false);
        }
    }

    public void PressureButton()
    {
        Instantiate(_obj, _parentObj.transform.parent);
        //_anim.SetBool("ButtonDown", true);
    }
}
