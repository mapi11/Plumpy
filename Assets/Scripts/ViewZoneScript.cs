using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewZoneScript : MonoBehaviour
{
    CharacterControllerScript Active;
    [SerializeField] private GameObject CanvasCheckMark;

    private void Start()
    {
        Active = FindObjectOfType<CharacterControllerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Active.PlayerActive3D();
            CanvasCheckMark.SetActive(false);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        Active.PlayerActive3D();
        CanvasCheckMark.SetActive(true);
    }
}
