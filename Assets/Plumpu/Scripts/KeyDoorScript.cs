using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDoorScript : MonoBehaviour
{
    [Space]
    [Header("Door")]
    [SerializeField] private DoorEntryScript door;

    //[Space]
    //[SerializeField] private GameObject _keyChild;

    [Space]
    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnCanvas;


    private void Awake()
    {
        _btnCanvas.onClick.AddListener(PickUpKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(false);
        }
    }

    void PickUpKey()
    {
        door.OpenDoor();
        Debug.Log("You can open door #" + door.doorID);
        //_keyChild.SetActive(false);
        Destroy(gameObject);
    }
}
