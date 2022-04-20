using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tep_btn : MonoBehaviour
{
    public GameObject depature;
    private GameObject character;
    public void clc()
    {
        character = GameObject.Find("Character");
        character.transform.position = depature.transform.position;
    }
}
