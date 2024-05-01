using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
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
    [SerializeField] private GameObject btn1D;
    [SerializeField] private GameObject btn2_3D;

    [Header("Parallax active")]
    //[SerializeField] private GameObject Background1_3D;
    //[SerializeField] private GameObject Background2D;

    [Header("Blocks active")]
    [SerializeField] private GameObject Objects1D;
    [SerializeField] private GameObject Objects2D;


    Animator _anim;
    private Rigidbody rb;
    private bool _facingRight = true;
    private bool _rotate = true;

    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        //Background1_3D = GameObject.Find("BG 1_3D");
        //Background2D = GameObject.Find("BG 2");

        Objects1D = GameObject.Find("Objects-1D");
        Objects2D = GameObject.Find("Objects-2D");
    }

    private void FixedUpdate()
    {
        transform.Translate(_horSpeed, 0, 0);

        IsGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadiusGround, _whatIsGround);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) //1D
        {
            PlayerActive1D();
        }
        if (Input.GetKeyDown(KeyCode.F2)) //2D
        {
            PlayerActive2D();
        }
        if (Input.GetKeyDown(KeyCode.F3)) //3D
        {
            PlayerActive3D();
        }
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

        if (Active1D == true)
        {
            Active2D = false;
            Active3D = false;
            PlayerActive1D();
        }
        else if (Active2D == true)
        {
            Active1D = false;
            Active3D = false;
            PlayerActive2D();
        }
        else if (Active3D == true)
        {
            Active1D = false;
            Active2D = false;
            PlayerActive3D();
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "ViewZone")
    //    {
    //        PlayerActive2D();
    //    }
    //}

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
        camera1D.SetActive(true);
        camera2D.SetActive(false);
        camera3D.SetActive(false);
        if (_rotate == true)
        {
            player2D.transform.Rotate(0, 90, 0);
        }
        btn1D.SetActive(true);
        btn2_3D.SetActive(false);

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
        btn1D.SetActive(false);
        btn2_3D.SetActive(true);

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
        btn1D.SetActive(false);
        btn2_3D.SetActive(true);

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