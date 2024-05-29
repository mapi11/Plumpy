using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class MainCharacterControllerScript : MonoBehaviour
{
    [Space]
    [Header("Player`s settings")]
    [SerializeField] public float _speed = 0.1f;
    [SerializeField] public float _jump = 4f;
    public float _horSpeed;
    public bool _boolJump = false;

    [Space]
    [Header("Hat pivot")]
    [SerializeField] private Transform _flipObject;
    public bool _lookLeft;
    public bool _lookRight = true;
    public bool _isFliped;
    public int _hatID;

    [Space]
    [Header("Jump")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadiusGround = 0.3f;
    public bool IsGrounded;

    [Space]
    [Header("Player`s active")]

    public GameObject player2D;
    public bool Active1D;
    public bool Active2D;
    public bool Active3D;
    [Space]
    public bool _change_D;

    [Space]
    [SerializeField] public Button _btn1D;
    [SerializeField] public Button _btn2D;
    [SerializeField] public Button _btn3D;

    [Space]
    [Header("Music Buttons")]
    [SerializeField] private GameObject btnForwardBackward;
    [SerializeField] private GameObject btnLeftRight;

    Animator _anim;
    private Rigidbody _rb;
    private bool _facingRight = true;
    public bool _rotate = true;

    [HideInInspector]
    public bool _isInDoor;
    //[HideInInspector]
    public bool _movementRight = true;

    [Space]
    [Header("Fall damage")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float fallHeight; // Высота, с которой начинается урон от падения
    //public bool isFalling = false;
    public Vector3 lastPosition;

    float _fadeFloat = 0.6f; // fade sprites

    // ---------------------------------------------------Scripts
    CharacterHealthScript _characterHealthScript;
    //ManagerObjectsScript _managerObjectsScript;
    ElevatorScript _elevatorScript;
    TEST_ _test;
    CameraSwitcherSctipt _cameraSwitcherSctipt;

    void Awake()
    {
         _test = FindAnyObjectByType<TEST_>();
        _characterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
        _elevatorScript = FindAnyObjectByType<ElevatorScript>();
        _cameraSwitcherSctipt = FindAnyObjectByType<CameraSwitcherSctipt>();

        _btn1D.onClick.AddListener(PlayerActive1D);
        _btn2D.onClick.AddListener(PlayerActive2D);
        _btn3D.onClick.AddListener(PlayerActive3D);

        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

        _btn2D.interactable = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = _groundCheck.position;

        PlayerActive2D();
    }

    private void FixedUpdate()
    {
        transform.Translate(_horSpeed, 0, 0);

        IsGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadiusGround, _whatIsGround);


        if (rb.velocity.y >= -0.01) // Персонаж закончил падать
        {
            float fallDistance = lastPosition.y - transform.position.y;
            lastPosition = transform.position;

            if (fallDistance >= fallHeight) // Проверяем, с какой высоты падает персонаж
            {
                float damage = (fallDistance / fallHeight); // Вычисляем урон от падения
                FallDamage(damage);
            }
        }
    }

    public void Update()
    {
        //lastPosition = transform.position;
        // --------------------------------------------- For PC
        if (Active1D != true)
        {
            if (Input.GetKeyDown(KeyCode.A)) //Left
            {
                ButtonLeft();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ButtonStop();
            }
            if (Input.GetKeyDown(KeyCode.D)) //Right
            {
                ButtonRight();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ButtonStop();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S)) //Left
            {
                ButtonLeft();
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                ButtonStop();
            }
            if (Input.GetKeyDown(KeyCode.W)) //Right
            {
                ButtonRight();
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                ButtonStop();
            }
        }


        if (Input.GetKeyDown(KeyCode.Space)) //Jump
        {
            ButtonJump();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerActive1D();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayerActive2D();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            PlayerActive3D();
        }
    }

    void FallDamage(float damage)
    {
        //if (_elevatorScript != null && _elevatorScript.isMoving != true)
        //{
        if (_isInDoor == false)
        {
            if (damage >= 3.0f)
            {
                // Реализация нанесения урона персонажу
                Debug.Log("-3 health " + damage);
                _characterHealthScript.Damage(3);
            }
            else if (damage >= 2.0f)
            {
                // Реализация нанесения урона персонажу
                Debug.Log("-2 health " + damage);
                _characterHealthScript.Damage(2);
            }
            else if (damage >= 1.0f)
            {
                // Реализация нанесения урона персонажу
                Debug.Log("-1 health " + damage);
                _characterHealthScript.Damage(1);
            }
        }

        //}
    }

    public void ButtonRight()
    {
        _horSpeed = _speed;

        if (_lookLeft == true)
        {
            _lookRight = true;
            _lookLeft = false;
            FlipModel();
            
        }
    }

    public void ButtonLeft()
    {
        _horSpeed = -_speed;

        if (_lookRight == true)
        {
            _lookRight = false;
            _lookLeft = true;
            FlipModel();
        }
    }

    public void ButtonJump()
    {
        _boolJump = true;
        if (IsGrounded == true)
        {
            _rb.velocity = Vector3.up * _jump * 1.2f;
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

    void FlipModel()
    {
        _isFliped = !_isFliped;

        Vector3 SvipePosition = _flipObject.lossyScale;
        SvipePosition.x *= -1;
        _flipObject.localScale = SvipePosition; // hat pivot svipe
    }

    public void PlayerActive1D()
    {
        _cameraSwitcherSctipt.CameraSwitch1D();

        ButtonStop();

        if (_rotate == true)
        {
            player2D.transform.Rotate(0, 90, 0);
        }
        btnForwardBackward.SetActive(true);
        btnLeftRight.SetActive(false);

        _rotate = false;

        foreach (GameObject obj1d in _test.tags1) //
        {
            if (obj1d != null)
            {
                obj1d.SetActive(true);
                if (obj1d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Enable();
                }
            }
        }
        foreach (GameObject obj2d in _test.tags2) //
        {
            if (obj2d != null)
            {
                obj2d.SetActive(false);

                if (obj2d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Disble();
                }
            }
        }
        _test.FadeOn1D();
        _test.FadeOff3D();

        Active1D = true;
        Active2D = false;
        Active3D = false;

        _change_D = true;
        Invoke("Change_D", 2f);

        _btn1D.interactable = false;
        _btn2D.interactable = true;
        _btn3D.interactable = true;

        _test.FadeObjects1D(_fadeFloat);
        _test.FadeObjects3D(1);
    }
    public void PlayerActive2D()
    {
        _cameraSwitcherSctipt.CameraSwitch2D();

        ButtonStop();

        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }

        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        _rotate = true;

        foreach (GameObject obj1d in _test.tags1) //
        {
            if (obj1d != null)
            {
                obj1d.SetActive(false);

                if (obj1d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Disble();
                }
            }
        }
        foreach (GameObject obj2d in _test.tags2) //
        {
            if (obj2d != null)
            {
                obj2d.SetActive(true);

                if (obj2d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Enable();
                }
            }
        }
        _test.FadeOn1D();
        _test.FadeOn3D();

        Active1D = false;
        Active2D = true;
        Active3D = false;

        _change_D = true;
        Invoke("Change_D", 2f);

        _btn1D.interactable = true;
        _btn2D.interactable = false;
        _btn3D.interactable = true;
    }
    public void PlayerActive3D()
    {
        _cameraSwitcherSctipt.CameraSwitch3D();

        ButtonStop();

        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        _rotate = true;

        foreach (GameObject obj1d in _test.tags1) //
        {
            if (obj1d != null)
            {
                obj1d.SetActive(true);

                if (obj1d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Enable();
                }
            }
        }
        foreach (GameObject obj2d in _test.tags2) //
        {
            if (obj2d != null)
            {
                obj2d.SetActive(true);

                if (obj2d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Enable();
                }
            }
        }
        _test.FadeOff1D();
        _test.FadeOn3D();

        Active1D = false;
        Active2D = false;
        Active3D = true;

        _change_D = true;
        Invoke("Change_D", 2f);

        _btn1D.interactable = true;
        _btn2D.interactable = true;
        _btn3D.interactable = false;

        _test.FadeObjects1D(1);
        _test.FadeObjects3D(_fadeFloat);
    }

    public void Change_D()
    {
        _change_D = false;
    }
}