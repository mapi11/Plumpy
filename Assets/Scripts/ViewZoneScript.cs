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
            Active.PlayerActive2D();
            CanvasCheckMark.SetActive(false);
        }
        Active.ButtonStop();

        Active.PlayerActive2D();
    }

    private void OnTriggerExit(Collider other)
    {
        Active.PlayerActive2D();
        CanvasCheckMark.SetActive(true);
    }
}
