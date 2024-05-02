using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainCharacterControllerScript : MonoBehaviour
{
    [Space]
    [Header("Player`s settings")]
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jump = 4f;
    public float _horSpeed;
    public bool _boolJump = false;

    [Space]
    [Header("Jump")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadiusGround = 0.3f;
    public bool IsGrounded;

    [Space]
    [Header("Player`s active")]
    public GameObject camera1D;
    [Header(" ")]
    public GameObject player2D;
    public GameObject camera2D;
    [Header(" ")]
    public GameObject camera3D;
    public bool Active1D;
    public bool Active2D;
    public bool Active3D;
    [SerializeField] private Button _btn1D;
    [SerializeField] private Button _btn2D;
    [SerializeField] private Button _btn3D;

    [Space]
    [Header("Music Buttons")]
    [SerializeField] private GameObject btnForwardBackward;
    [SerializeField] private GameObject btnLeftRight;

    [Header("Objects active")]
    [SerializeField] private GameObject Objects1D;
    [SerializeField] private GameObject Objects2D;

    Animator _anim;
    private Rigidbody rb;
    private bool _facingRight = true;
    private bool _rotate = true;

    void Awake()
    {
        _btn1D.onClick.AddListener(PlayerActive1D);
        _btn2D.onClick.AddListener(PlayerActive2D);
        _btn3D.onClick.AddListener(PlayerActive3D);

        Objects1D = GameObject.Find("Objects-1D");
        Objects2D = GameObject.Find("Objects-2D");
        Objects1D.SetActive(false);

        Application.targetFrameRate = 80;

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
        // --------------------------------------------- For PC
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
        if (Input.GetKeyDown(KeyCode.Space)) //Jump
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

    public void PlayerActive1D()
    {
        camera1D.SetActive(true);
        camera2D.SetActive(false);
        camera3D.SetActive(false);
        if (_rotate == true)
        {
            player2D.transform.Rotate(0, 90, 0);
        }
        btnForwardBackward.SetActive(true);
        btnLeftRight.SetActive(false);

        //Background2D.SetActive(false);
        //Background1_3D.SetActive(true);

        Objects1D.SetActive(true);
        Objects2D.SetActive(false);

        _rotate = false;

        Active1D = true;
        Active2D = false;
        Active3D = false;
    }
    public void PlayerActive2D()
    {
        camera2D.SetActive(true);
        camera3D.SetActive(false);
        camera1D.SetActive(false);
        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        //Background2D.SetActive(true);
        //Background1_3D.SetActive(false);

        Objects1D.SetActive(false);
        Objects2D.SetActive(true);

        _rotate = true;

        Active1D = false;
        Active2D = true;
        Active3D = false;
    }
    public void PlayerActive3D()
    {
        camera3D.SetActive(true);
        camera2D.SetActive(false);
        camera1D.SetActive(false);
        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        //Background2D.SetActive(false);
        //Background1_3D.SetActive(true);

        Objects1D.SetActive(true);
        Objects2D.SetActive(true);

        _rotate = true;

        Active1D = false;
        Active2D = false;
        Active3D = true;
    }
}