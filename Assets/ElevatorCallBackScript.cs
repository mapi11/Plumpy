using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorCallBackScript : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnCallBack;
    [SerializeField] private GameObject _imgInteract;
    [SerializeField] private int _callBackFloor;

    ElevatorScript _elevatorScript;

    private void Awake()
    {
        _elevatorScript = FindAnyObjectByType<ElevatorScript>();

        _imgInteract.gameObject.SetActive(false);
        _btnCallBack.interactable = false;

        _btnCallBack.onClick.AddListener(CallBack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_elevatorScript.currentFloor != _callBackFloor)
            {
                _imgInteract.gameObject.SetActive(true);
                _btnCallBack.interactable = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _imgInteract.gameObject.SetActive(false);
            _btnCallBack.interactable = false;
        }
    }

    void CallBack()
    {
        _elevatorScript.MoveToFloor(_callBackFloor);

        _imgInteract.gameObject.SetActive(false);
        _btnCallBack.interactable = false;
    }
}
