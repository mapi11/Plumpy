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
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _jump = 4f;
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

    //[Header("Objects active")]
    //[SerializeField] private GameObject Objects1D;
    //[SerializeField] private GameObject Objects2D;

    Animator _anim;
    private Rigidbody _rb;
    private bool _facingRight = true;
    public bool _rotate = true;

    [HideInInspector]
    public bool _isInDoor;

    [Space]
    [Header("Fall damage")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float fallHeight; // Высота, с которой начинается урон от падения
    public bool isFalling = false;
    public Vector3 lastPosition;

    float _fadeFloat = 0.6f; // fade sprites

    // ---------------------------------------------------Scripts
    CharacterHealthScript _characterHealthScript;
    //ManagerObjectsScript _managerObjectsScript;
    ElevatorScript _elevatorScript;
    TEST_ _test;

    public static MainCharacterControllerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

    //_managerObjectsScript = FindAnyObjectByType<ManagerObjectsScript>();
         _test = FindAnyObjectByType<TEST_>();
        _characterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
        _elevatorScript = FindAnyObjectByType<ElevatorScript>();

        _btn1D.onClick.AddListener(PlayerActive1D);
        _btn2D.onClick.AddListener(PlayerActive2D);
        _btn3D.onClick.AddListener(PlayerActive3D);

        //Objects1D = GameObject.Find("Objects-1D");
        //Objects2D = GameObject.Find("Objects-2D");

        Application.targetFrameRate = 165;

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

        if (rb.velocity.y >= 0) // Персонаж закончил падать
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

        //if (rb.velocity.y < 0 && !isFalling) // Персонаж начинает падать
        //{
        //    isFalling = true;
        //}

    }

    void FallDamage(float damage)
    {
        if (_elevatorScript.isMoving != true)
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
    }

    //public void Flip()
    //{
    //    _facingRight = !_facingRight;

    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;
    //}

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
        ButtonStop();

        camera1D.SetActive(true);
        camera2D.SetActive(false);
        camera3D.SetActive(false);

        if (_rotate == true)
        {
            player2D.transform.Rotate(0, 90, 0);
        }
        btnForwardBackward.SetActive(true);
        btnLeftRight.SetActive(false);

        _rotate = false;

        //foreach (GameObject obj1d in _test.taggedObjects1) //
        //{
        //    obj1d.SetActive(true);
        //}
        //foreach (GameObject obj2d in _test.taggedObjects2) //
        //{
        //    obj2d.SetActive(false);
        //}

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

        Active1D = true;
        Active2D = false;
        Active3D = false;

        _btn1D.interactable = false;
        _btn2D.interactable = true;
        _btn3D.interactable = true;

        _test.FadeObjects1D(_fadeFloat);
        _test.FadeObjects3D(1);
    }
    public void PlayerActive2D()
    {
        ButtonStop();

        camera2D.SetActive(true);
        camera3D.SetActive(false);
        camera1D.SetActive(false);
        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }

        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        _rotate = true;

        //foreach (GameObject obj1d in _test.taggedObjects1) //
        //{
        //    obj1d.SetActive(false);
        //}
        //foreach (GameObject obj2d in _test.taggedObjects2) //
        //{
        //    obj2d.SetActive(true);
        //}

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
            if (obj2d !=  null)
            {
                obj2d.SetActive(true);

                if (obj2d.TryGetComponent<IdisableScript>(out var disableScript))
                {
                    disableScript.Enable();
                }
            }
        }

        Active1D = false;
        Active2D = true;
        Active3D = false;

        _btn1D.interactable = true;
        _btn2D.interactable = false;
        _btn3D.interactable = true;
    }
    public void PlayerActive3D()
    {
        ButtonStop();

        camera3D.SetActive(true);
        camera2D.SetActive(false);
        camera1D.SetActive(false);

        if (_rotate == false)
        {
            player2D.transform.Rotate(0, -90, 0);
        }
        btnForwardBackward.SetActive(false);
        btnLeftRight.SetActive(true);

        _rotate = true;

        //foreach (GameObject obj2d in _managerObjectsScript._objects2D) //Activate 2D
        //{
        //    obj2d.SetActive(true);
        //}
        //foreach (GameObject obj1d in _managerObjectsScript._objects1D) //Activate 1D
        //{
        //    obj1d.SetActive(true);
        //}
        //foreach (GameObject obj1d in _managerObjectsScript._objects1D) //Activate 1D
        //{
        //    obj1d.SetActive(true);
        //}
        //foreach (GameObject obj2d in _test.taggedObjects2) //
        //{
        //    obj2d.SetActive(true);
        //}
        //foreach (GameObject obj2d in _managerObjectsScript._objects2D) //Activate 2D
        //{
        //    obj2d.SetActive(true);
        //}
        //foreach (GameObject obj1d in _managerObjectsScript._objects1D) //Activate 1D
        //{
        //    obj1d.SetActive(true);
        //}

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

        //foreach (GameObject obj1d in _test.taggedObjects1) //
        //{
        //    obj1d.SetActive(true);
        //}
        //foreach (GameObject obj2d in _test.taggedObjects2) //
        //{
        //    obj2d.SetActive(true);
        //}

        Active1D = false;
        Active2D = false;
        Active3D = true;

        _btn1D.interactable = true;
        _btn2D.interactable = true;
        _btn3D.interactable = false;

        _test.FadeObjects1D(1);
        _test.FadeObjects3D(_fadeFloat);
    }
}