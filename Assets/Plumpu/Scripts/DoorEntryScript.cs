using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DoorEntryScript : MonoBehaviour, IdisableScript
{
    [SerializeField] private GameObject _disbledPart;

    [Space]
    [Header("Change scene")]
    MainCharacterControllerScript _mainCharacterControllerScript;
    public bool ChangeScene = false;
    public string scene;
    private GameObject character;

    [Space]
    [Header("Canvas")]
    [SerializeField] private Button _btnDoor;
    [SerializeField] private GameObject _roomEntry;
    [SerializeField] private GameObject _canvas;

    private GameObject PhoneButtons;

    [SerializeField] private float _delayOpen = 0.5f;

    [Space]
    [Header("Lock")]
    [SerializeField] private GameObject _txtClosed;
    [SerializeField] private bool _locked;
    public int doorID;

    private void Awake()
    {
        character = GameObject.Find("CharacterContent");
        PhoneButtons = GameObject.Find("ControllerButtons");
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _btnDoor.onClick.AddListener(RoomEntry);
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

    public void RoomEntry()
    {
        if (_locked == true)
        {
            _txtClosed.SetActive(true);
            _btnDoor.interactable = false;
            Invoke("HideCanvas", 3.0f);
        }
        else
        {
            if (_mainCharacterControllerScript._isInDoor != true)
            {
                _mainCharacterControllerScript._isInDoor = true;

                if (ChangeScene == false)
                {
                    PhoneButtons.SetActive(false);
                    _mainCharacterControllerScript.ButtonStop();
                    Invoke("Teleport", _delayOpen);
                    _btnDoor.interactable = false;
                }
                else
                {
                    SceneManager.LoadScene(scene);
                }
            }
        }
    }

    public void Teleport()
    {

        character.transform.position = _roomEntry.transform.position;
        PhoneButtons.SetActive(true);
        _mainCharacterControllerScript.ButtonStop();

        _btnDoor.interactable = true;
        _mainCharacterControllerScript._isInDoor = false;

    }

    public void OpenDoor()
    {
        _locked = false;
    }

    public void HideCanvas()
    {
        _txtClosed.SetActive(false);
        _btnDoor.interactable = true;
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
        _disbledPart.SetActive(false);


    }
    public void Enable()
    {
        _disbledPart.SetActive(true);

        _canvas.SetActive(PlayerInTrigger());
    }
}