using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcherSctipt : MonoBehaviour
{
    public Camera mainCamera;

    [Space]
    [SerializeField] private Transform[] targetPoints;
    private bool isOrthographic = false; private bool is2d = true;
    private float movementSpeed = 2.0f;
    private float rotationSpeed = 1f;

    public float smoothSpeed = 0.025f;
    private Vector3 offset;

    public int currentTargetIndex = 0;
    public bool isMoving = false;

    [Space]
    [Header("Player objects")]
    public GameObject _btnsChange;
    public GameObject _btnsMovement;

    MainCharacterControllerScript _characterControllerScript;

    private void Awake()
    {
        _characterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();
        //mainCamera = Instantiate(_cameraPrefab);

        mainCamera.transform.parent = null;
    }

    private void Start()
    {
        offset = mainCamera.transform.position - targetPoints[currentTargetIndex].position;
    }

    void FixedUpdate()
    {
        //Vector3 newPosition = new Vector3(mainCamera.transform.position.x, targetPoints[currentTargetIndex].position.y + offset.y, mainCamera.transform.position.z);
        Vector3 newPosition = new Vector3(targetPoints[currentTargetIndex].position.x, targetPoints[currentTargetIndex].position.y, targetPoints[currentTargetIndex].position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newPosition, smoothSpeed);
    }

    public IEnumerator MoveCameraToTarget(Vector3 targetPosition)
    {
        if (isMoving != true)
        {
            mainCamera.orthographic = isOrthographic;
            isMoving = true;

            Vector3 startPosition = mainCamera.transform.position;
            Quaternion startRotation = mainCamera.transform.rotation;

            float elapsedTime = 0f;
            float rotationTime = rotationSpeed; // Время, за которое камера повернется к точке

            while (elapsedTime < 1f)
            {
                mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
                mainCamera.transform.rotation = Quaternion.Slerp(startRotation, targetPoints[currentTargetIndex].rotation, elapsedTime / rotationTime);

                elapsedTime += Time.deltaTime * movementSpeed;
                yield return null;
            }

            // Установка камеры в точку назначения и с нужным поворотом
            mainCamera.transform.position = targetPosition;
            mainCamera.transform.rotation = targetPoints[currentTargetIndex].rotation;

            // Установка параметров проекции
            //mainCamera.orthographic = isOrthographic;

            isMoving = false;

            // Переход к следующей точке
            //currentTargetIndex = (currentTargetIndex + 1) % targetPoints.Length;

            isMoving = false;

            _btnsChange.SetActive(true);
            _btnsMovement.SetActive(true);
        }
    }

    public void CameraSwitch1D()
    {
        if (isMoving != true) 
        {
            mainCamera.orthographic = false;
            mainCamera.orthographic = isOrthographic;
            currentTargetIndex = 0;
            _btnsChange.SetActive(false);
            _btnsMovement.SetActive(false);
            rotationSpeed = 1.0f; movementSpeed = 2.0f;

            StartCoroutine(MoveCameraToTarget(targetPoints[currentTargetIndex].position));

            isOrthographic = false;
            mainCamera.orthographic = isOrthographic;
        }
    }
    public void CameraSwitch2D()
    {
        if (isMoving != true)
        {
            isOrthographic = true;

            currentTargetIndex = 1;
            _btnsChange.SetActive(false);
            _btnsMovement.SetActive(false);
            rotationSpeed = 0.5f; movementSpeed = 2.5f;

            

            StartCoroutine(MoveCameraToTarget(targetPoints[currentTargetIndex].position));


            //mainCamera.orthographic = isOrthographic;
        }
    }
    public void CameraSwitch3D()
    {
        if (isMoving != true)
        {
            isOrthographic = false;

            mainCamera.orthographic = false;
            mainCamera.orthographic = isOrthographic;
            currentTargetIndex = 2;
            _btnsChange.SetActive(false);
            _btnsMovement.SetActive(false);
            rotationSpeed = 1.0f; movementSpeed = 2.0f;

            StartCoroutine(MoveCameraToTarget(targetPoints[currentTargetIndex].position));
        }
    }
}
