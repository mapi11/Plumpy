using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    CharacterControllerScript HorSpeed;
    private float PSHorSpeed;
    Animator _anim;

    private bool _rotate = true;

    void Start()
    {
        HorSpeed = FindObjectOfType<CharacterControllerScript>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        PSHorSpeed = HorSpeed._horSpeed;

        _anim.SetBool("Run", PSHorSpeed > 0 || PSHorSpeed < 0);

        //_anim.SetBool("Jump", );
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
