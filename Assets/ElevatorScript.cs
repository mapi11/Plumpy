using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ElevatorScript : MonoBehaviour
{
    //public Transform[] floors; // Массив трансформов для каждого этажа
    //public GameObject canvas; // Панель с кнопками этажей

    //private int currentFloor = 0;
    //private bool isMoving = false;

    //void Start()
    //{
    //    // Инициализируем начальный этаж
    //    transform.position = floors[currentFloor].position;
    //}

    //void Update()
    //{
    //    if (isMoving)
    //    {
    //        // Если лифт двигается, перемещаем его к выбранному этажу
    //        transform.position = Vector3.MoveTowards(transform.position, floors[currentFloor].position, Time.deltaTime * 5f);

    //        if (transform.position == floors[currentFloor].position)
    //        {
    //            isMoving = false; // Лифт остановился на нужном этаже
    //        }
    //    }
    //}

    //public void GoToFloor(int floor)
    //{
    //    if (!isMoving && floor >= 0 && floor < floors.Length)
    //    {
    //        currentFloor = floor; // Устанавливаем выбранный этаж
    //        isMoving = true; // Активируем движение лифта

    //    }
    //}

    // ---------------------------------------------------------

    private Transform _character;
    [SerializeField] private Transform _elevator;
    [SerializeField] private GameObject _elevatorDoor;

    [SerializeField] private Transform[] _floors;

    private GameObject _btnCharJump;

    [SerializeField] private GameObject _canvasBtnFloors;
    [SerializeField] private TextMeshProUGUI _currentFloorText;

    public bool isMoving = false;
    [SerializeField] private int currentFloor = 0;

    private void Awake()
    {
        _btnCharJump = GameObject.Find("BtnJump");
        _character = GameObject.Find("MainCharacter").transform;

        _currentFloorText.text = "Floor: <color=red>" + currentFloor;

        _canvasBtnFloors.SetActive(false);
    }

    void Update()
    {
        //if (isMoving)
        //{
        //    _character.parent = _elevator;
        //}
        //else
        //{
        //    _character.parent = null;
        //}
    }

    public void MoveToFloor(int floorNumber)
    {
        if (!isMoving)
        {
            if (floorNumber >= 0 && floorNumber < _floors.Length)
            {

                StartCoroutine(MoveElevator(_floors[floorNumber].position));
                currentFloor = floorNumber;

                _currentFloorText.text = "Floor: <color=red>" + currentFloor;
            }
        }

        //if (isMoving)
        //{
        //    _character.parent = _elevator;
        //}
        //else
        //{
        //    _character.parent = null;
        //}
    }

    IEnumerator MoveElevator(Vector3 targetPosition)
    {
        _character.parent = _elevator;

        _elevatorDoor.SetActive(true);
        isMoving = true;
        while (Vector3.Distance(_elevator.position, targetPosition) > 0.01f)
        {
            _elevator.position = Vector3.MoveTowards(_elevator.position, targetPosition, Time.deltaTime * 3.5f);
            yield return null;
        }
        isMoving = false;
        _elevatorDoor.SetActive(false);

        _character.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvasBtnFloors.SetActive(true);
            _btnCharJump.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvasBtnFloors.SetActive(false);
            _btnCharJump.SetActive(true);
        }
    }
}
