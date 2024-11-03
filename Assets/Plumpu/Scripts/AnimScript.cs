using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    MainCharacterControllerScript HorSpeed;
    CharacterCrouchScript characterCrouchScript;

    private float PSHorSpeed;
    private bool PSBoolJump;
    private bool PSIsGrounded;
    Animator _anim;

    private bool _rotate = true;

    void Start()
    {
        HorSpeed = FindAnyObjectByType<MainCharacterControllerScript>();
        characterCrouchScript = FindAnyObjectByType<CharacterCrouchScript>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        PSHorSpeed = HorSpeed._horSpeed; // из скрипта MainCharacterControllerScript
        PSBoolJump = HorSpeed._boolJump;
        PSIsGrounded = HorSpeed.IsGrounded;

        _anim.SetBool("Run", PSHorSpeed > 0 || PSHorSpeed < 0);

        if (PSBoolJump == true)
        {
            _anim.SetBool("Jump", true);
        }

        if (characterCrouchScript.isCrouching == true)
        {

            _anim.SetBool("CrouchIdle", true);

            if (PSHorSpeed > 0 || PSHorSpeed < 0 && characterCrouchScript.isCrouching == true)
            {
                _anim.SetBool("CrouchMove", true);

                _anim.SetBool("Run", false);
            }
            else
            {
                _anim.SetBool("CrouchMove", false);
            }
        }
        else
        {
            _anim.SetBool("CrouchIdle", false);
            _anim.SetBool("CrouchMove", false);
        }

        _anim.SetBool("Jump", !PSIsGrounded);
    }

    public void CharacterRotation()
    {
        if (_rotate == true)
        {
            transform.Rotate(0,90, 0);
            _rotate = false;
        }
        
        else if (_rotate == false)
        {
            transform.Rotate(0, -90, 0);
            _rotate = true;
        }
    }
}
