using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorEntryScript : MonoBehaviour
{
    CharacterControllerScript Char;
    public bool teleport = false;
    public string scene;
    private GameObject character;
    [SerializeField] private GameObject _roomEntry;
    //[SerializeField] private GameObject _roomExit;

    [SerializeField] private GameObject canvas;
    private GameObject PhoneButtons;

    private float delay = 1.0f;

    private bool IsOpen = false;

    private void Start()
    {
        character = GameObject.Find("Character");
        PhoneButtons = GameObject.Find("PhoneButtonsWindow");
        Char = FindObjectOfType<CharacterControllerScript>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
    public void RoomEntry()
    {
        if(teleport == false)
        {
            PhoneButtons.SetActive(false);
            Char.ButtonStop();
            Invoke("Teleport", delay);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }

        IsOpen = true;
    }

    public void Teleport()
    {
        if (IsOpen == true)
        {
            character.transform.position = _roomEntry.transform.position;
            PhoneButtons.SetActive(true);
            Char.ButtonStop();

            IsOpen = false;
        }
    }
}