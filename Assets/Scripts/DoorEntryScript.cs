using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntryScript : MonoBehaviour
{
    private GameObject character;
    [SerializeField] private GameObject _roomEntry;
    //[SerializeField] private GameObject _roomExit;
    [SerializeField] private GameObject canvas;


    private void Start()
    {
        character = GameObject.Find("Character");
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
        character.transform.position = _roomEntry.transform.position;
    }


}
