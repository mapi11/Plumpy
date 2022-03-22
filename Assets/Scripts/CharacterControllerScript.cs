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
    public GameObject camera1D;
    [Header(" ")]
    public GameObject player2D;
    public GameObject camera2D;
    [Header(" ")]
    public GameObject camera3D;


    Animator _anim;
    private Rigidbody rb;
    private bool _facingRight = true;
    private bool _rotate = true;

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

        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            _horSpeed = -_speed;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _horSpeed = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            _horSpeed = _speed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _horSpeed = 0.0f;
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

    public void CharacterRotation()
    {

        if (_rotate == true)
        {
            transform.Rotate(0, 90, 0);
            _rotate = false;
        }

        else if (_rotate == false)
        {
            transform.Rotate(0, 0, 0);
            _rotate = true;
        }
    }

    public void PlayerActive1D()
    {
        //player1D.SetActive(true);
        camera1D.SetActive(true);
        //player2D.SetActive(false);
        camera2D.SetActive(false);
        //player3D.SetActive(false);
        camera3D.SetActive(false);
        if (_rotate == true)
        {
            player2D.transform.Rotate(0, 90, 0);
        }
        _rotate = false;
    }
    public void PlayerActive2D()
    {
        //player2D.SetActive(true);
        camera2D.SetActive(true);
        //player3D.SetActive(false);
        camera3D.SetActive(false);
        //player1D.SetActive(false);
        camera1D.SetActive(false);
        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        _rotate = true;
    }
    public void PlayerActive3D()
    {
        //player3D.SetActive(true);
        camera3D.SetActive(true);
        //player2D.SetActive(false);
        camera2D.SetActive(false);
        //player1D.SetActive(false);
        camera1D.SetActive(false);
        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        _rotate = true;
    }
}
