using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveScript : MonoBehaviour
{
    CharacterControllerScript Active;

    [SerializeField] private GameObject ActiveObject;
    [SerializeField] private bool Active2D = true;

    private void Start()
    {
        Active = FindObjectOfType<CharacterControllerScript>();
    }
    private void Update()
    {
        if (Active2D == true) // 2D
        {
            if (Active.Active2D || Active.Active3D)
            {
                ActiveObject.SetActive(true);
            }
            if (Active.Active1D)
            {
                ActiveObject.SetActive(false);
            }
        }

        if (Active2D == false) //1-3D
        {
            if (Active.Active2D)
            {
                ActiveObject.SetActive(false);
            }
            if (Active.Active1D || Active.Active3D)
            {
                ActiveObject.SetActive(true);
            }
        }

        //if (Heal.IsHealing == true)
        //{
        //    Destroy(MainObject);
        //}
    }
}
