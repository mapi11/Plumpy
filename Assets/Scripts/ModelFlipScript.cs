using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFlipScript : MonoBehaviour
{
    //private bool FacingFlip = true;
    CharacterControllerScript HorSpeed;
    private float PSHorSpeed;

    //public Animator anim1D;
    public Animator anim2D;
    public Animator anim3D;

    public SpriteRenderer SR1D;
    public SpriteRenderer SR2D;
    public SpriteRenderer SR3D;


    void Start()
    {
        HorSpeed = FindObjectOfType<CharacterControllerScript>();
    }

    
    private void Update()
    {
        PSHorSpeed = HorSpeed._horSpeed;

        if (PSHorSpeed < 0)
        {
            SR1D.flipX = true;
            SR2D.flipX = true;
            SR3D.flipX = true;
        }
        else if (PSHorSpeed > 0)
        {

            SR1D.flipX = false;
            SR2D.flipX = false;
            SR3D.flipX = false;
        }

        //if (PSHorSpeed != 0)
        //{
        //    anim2D.SetBool("Stop", false);
        //    anim3D.SetBool("Stop", false);
        //}
        //else
        //{
        //    anim2D.SetBool("Stop", true);
        //    anim3D.SetBool("Stop", true);
        //}
    }
}
