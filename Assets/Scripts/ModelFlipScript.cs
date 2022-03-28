using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFlipScript : MonoBehaviour
{
    CharacterControllerScript HorSpeed;
    private float PSHorSpeed;

    public Animator anim2D;

    public SpriteRenderer SR2D;

    void Start()
    {
        HorSpeed = FindObjectOfType<CharacterControllerScript>();
    }
    
    private void Update()
    {
        PSHorSpeed = HorSpeed._horSpeed;

        if (PSHorSpeed < 0)
        {
            SR2D.flipX = true;
        }
        else if (PSHorSpeed > 0)
        {
            SR2D.flipX = false;
        }
    }
}
