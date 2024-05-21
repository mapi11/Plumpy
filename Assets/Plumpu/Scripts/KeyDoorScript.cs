using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDoorScript : MonoBehaviour, IdisableScript
{
    [SerializeField] private GameObject _disbledPart;
    [SerializeField] private bool _is2D = true;

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

    //------------------------------------------------------------------Check player
    private bool PlayerInTrigger()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    public void Disble()
    {
        if (_is2D == true)
        {
            _disbledPart.SetActive(false);
        }
        else
        {
            _disbledPart.SetActive(true);
        }
    }

    public void Enable()
    {
        if (_is2D == true)
        {
            _disbledPart.SetActive(true);
        }
        else
        {
            _disbledPart.SetActive(false);
        }

        _canvas.SetActive(PlayerInTrigger());
    }
}
