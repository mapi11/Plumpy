using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [Header("Player`s settings")]
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jump = 4f;
    public float _horSpeed;

    [Header("Jump")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadiusGround = 0.3f;
    private bool IsGrounded;

    [Header("Player`s active")]
    public GameObject player3D;
    public GameObject camera3D;
    [Header(" ")]
    public GameObject player2D;
    public GameObject camera2D;
    [Header(" ")]
    public GameObject player1D;
    public GameObject camera1D;

    Animator _anim;
    private Rigidbody rb;
    private bool _facingRight = true;

    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        transform.Translate(_horSpeed, 0, 0);

        IsGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadiusGround, _whatIsGround);
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            ButtonLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ButtonRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonJump();
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void ButtonRight()
    {
        _horSpeed = _speed;
    }

    public void ButtonLeft()
    {
        _horSpeed = -_speed;
    }
    public void ButtonJump()
    {
        if (IsGrounded == true)
        {
            rb.velocity = Vector3.up * _jump * 1.2f;
            //_anim.SetBool("Jump",true);
        }
    }
    public void ButtonStop()
    {
        _horSpeed = 0.0f;
    }

    public void PlayerActive3D()
    {
        player3D.SetActive(true);
        camera3D.SetActive(true);
        player2D.SetActive(false);
        camera2D.SetActive(false);
        player1D.SetActive(false);
        camera1D.SetActive(false);
    }
    public void PlayerActive2D()
    {
        player2D.SetActive(true);
        camera2D.SetActive(true);
        player3D.SetActive(false);
        camera3D.SetActive(false);
        player1D.SetActive(false);
        camera1D.SetActive(false);
    }
    public void PlayerActive1D()
    {
        player1D.SetActive(true);
        camera1D.SetActive(true);
        player2D.SetActive(false);
        camera2D.SetActive(false);
        player3D.SetActive(false);
        camera3D.SetActive(false);
    }
}
