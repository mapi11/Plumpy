using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    CharacterControllerScript HorSpeed;
    private float PSHorSpeed;
    Animator _anim;

    void Start()
    {
        HorSpeed = FindObjectOfType<CharacterControllerScript>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        PSHorSpeed = HorSpeed._horSpeed;

        _anim.SetBool("Run", PSHorSpeed > 0 || PSHorSpeed < 0);

    }
}
