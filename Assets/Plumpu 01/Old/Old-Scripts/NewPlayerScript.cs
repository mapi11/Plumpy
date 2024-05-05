using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    [Header("Player`s settings")]
    public float speed;
    public float Jump;
    public float HorSpeed;
    public GameObject StairsActive;

    MBWscript MBWS;
   
 
    [Header("Player`s active")]
    public GameObject player3D;
    public GameObject camera3D;
    [Header(" ")]
    public GameObject player2D;
    public GameObject camera2D;
    [Header(" ")]
    public GameObject player1D;
    public GameObject camera1D;
    [Header(" ")]
    public bool MBWactive1D = false;
    public bool MBWactive2D = true;
    public bool MBWactive3D = false;

    [Header("Jump")]
    public Transform GroundCheck;
    public Transform StairsCheck;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsStairs;
    private bool IsGrounded;
    private bool IsStairsed;
    public float CheckRadiusGround = 0.3f;
    public float CheckRadiusStairs = 1f;

    private Rigidbody rb;

    private void Start()
    {
        MBWactive2D = true;
        rb = GetComponent<Rigidbody>();
        MBWS = FindAnyObjectByType<MBWscript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonJump();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ButtonLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ButtonRight();
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(HorSpeed, 0, 0);


        IsGrounded = Physics.CheckSphere(GroundCheck.position, CheckRadiusGround, WhatIsGround);

        IsStairsed = Physics.CheckSphere(GroundCheck.position, CheckRadiusStairs, WhatIsStairs);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            StairsActive.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            StairsActive.SetActive(false);
        }
    }

    public void ButtonRight()
    {
        HorSpeed = speed;
    }
    public void ButtonLeft()
    {
        HorSpeed = -speed;
    }
    public void ButtonJump()
    {
        if (IsGrounded == true)
        {
            rb.velocity = Vector3.up * Jump * 1.2f;
        }
    }
    public void ButtonStairs()
    {
        if (IsStairsed == true)
        {
            rb.velocity = Vector3.up * Jump * 1.2f;
        }
    }
    public void ButtonStop()
    {
        HorSpeed = 0.0f;
    }

    public void PlayerActive3D()
    {
        player3D.SetActive(true);
        camera3D.SetActive(true);
        player2D.SetActive(false);
        camera2D.SetActive(false);
        player1D.SetActive(false);
        camera1D.SetActive(false);

        MBWactive3D = true;
        MBWactive2D = false;
        MBWactive1D = false;
    }
    public void PlayerActive2D()
    {
        player2D.SetActive(true);
        camera2D.SetActive(true);
        player3D.SetActive(false);
        camera3D.SetActive(false);
        player1D.SetActive(false);
        camera1D.SetActive(false);

        MBWactive3D = false;
        MBWactive2D = true;
        MBWactive1D = false;
    }
    public void PlayerActive1D()
    {
        player1D.SetActive(true);
        camera1D.SetActive(true);
        player2D.SetActive(false);
        camera2D.SetActive(false);
        player3D.SetActive(false);
        camera3D.SetActive(false);

        MBWactive3D = false;
        MBWactive2D = false;
        MBWactive1D = true;
    }
}
