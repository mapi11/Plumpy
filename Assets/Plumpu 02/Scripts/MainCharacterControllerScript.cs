using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainCharacterControllerScript : MonoBehaviour
{
    [Header("Player`s settings")]
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jump = 4f;
    public float _horSpeed;
    public bool _boolJump = false;

    [Header("Jump")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadiusGround = 0.3f;
    public bool IsGrounded;

    Animator _anim;
    private Rigidbody rb;
    private bool _facingRight = true;
    private bool _rotate = true;

    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _btnJump;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        _btnJump.onClick.AddListener(ButtonJump);
    }

    private void FixedUpdate()
    {
        transform.Translate(_horSpeed, 0, 0);

        IsGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadiusGround, _whatIsGround);
    }

    public void Update()
    {
        // --------------------------------------------- For PC
        //if (Input.GetKeyDown(KeyCode.A)) //Left
        //{
        //    _horSpeed = -_speed;
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    _horSpeed = 0.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.D)) //Right
        //{
        //    _horSpeed = _speed;
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    _horSpeed = 0.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.Space)) //Jump
        //{
        //    ButtonJump();
        //}
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
        _boolJump = true;
        if (IsGrounded == true)
        {
            rb.velocity = Vector3.up * _jump * 1.2f;
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
}