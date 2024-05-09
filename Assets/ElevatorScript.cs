using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorScript : MonoBehaviour
{
    //public Transform[] floors; // ������ ����������� ��� ������� �����
    //public GameObject canvas; // ������ � �������� ������

    //private int currentFloor = 0;
    //private bool isMoving = false;

    //void Start()
    //{
    //    // �������������� ��������� ����
    //    transform.position = floors[currentFloor].position;
    //}

    //void Update()
    //{
    //    if (isMoving)
    //    {
    //        // ���� ���� ���������, ���������� ��� � ���������� �����
    //        transform.position = Vector3.MoveTowards(transform.position, floors[currentFloor].position, Time.deltaTime * 5f);

    //        if (transform.position == floors[currentFloor].position)
    //        {
    //            isMoving = false; // ���� ����������� �� ������ �����
    //        }
    //    }
    //}

    //public void GoToFloor(int floor)
    //{
    //    if (!isMoving && floor >= 0 && floor < floors.Length)
    //    {
    //        currentFloor = floor; // ������������� ��������� ����
    //        isMoving = true; // ���������� �������� �����

    //    }
    //}

    // ---------------------------------------------------------

    private Transform _character;
    [SerializeField] private Transform _elevator;
    [SerializeField] private List<Transform> _floors;
    [SerializeField] private TextMeshProUGUI _currentFloorText;

    private bool isMoving = false;
    private int currentFloor = 0;

    private void Awake()
    {
        _character = GameObject.Find("MainCharacter").transform;
        _currentFloorText.text = "Current Floor: " + currentFloor;

    }

    void Update()
    {
        if (isMoving)
        {
            _character.parent = _elevator;
        }
        else
        {
            _character.parent = null;
        }
    }

    public void MoveToFloor(int floorNumber)
    {
        if (!isMoving)
        {
            if (floorNumber >= 0 && floorNumber < _floors.Count)
            {
                StartCoroutine(MoveElevator(_floors[floorNumber].position));
                currentFloor = floorNumber;

                _currentFloorText.text = "Current Floor: " + currentFloor;
            }
        }
    }

    IEnumerator MoveElevator(Vector3 targetPosition)
    {
        isMoving = true;
        while (Vector3.Distance(_elevator.position, targetPosition) > 0.1f)
        {
            _elevator.position = Vector3.MoveTowards(_elevator.position, targetPosition, Time.deltaTime * 3.5f);
            yield return null;
        }
        isMoving = false;

        
    }

}
