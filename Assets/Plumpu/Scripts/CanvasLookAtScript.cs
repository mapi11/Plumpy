using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CanvasLookAtScript : MonoBehaviour
{
    public Camera _camera;

    private void Start()
    {
        _camera = FindAnyObjectByType<Camera>();
    }
    //public Transform character;

    //private void Awake()
    //{
    //    character = GameObject.Find("Character-2D").transform;
    //}

    private void Update()
    {
        //_camera = FindAnyObjectByType<Camera>();

        transform.LookAt(_camera.transform);

        //Camera activeCamera = Camera.main; // Получаем активную камеру

        //foreach (Camera camera in _camera)
        //{
        //    if (camera != activeCamera)
        //    {
        //        camera.gameObject.SetActive(false); // Выключаем камеру, которая не активна
        //    }
        //    else
        //    {
        //        camera.gameObject.SetActive(true); // Включаем активную камеру

        //        //Vector3 targetPosition = new Vector3(activeCamera.transform.position.x, transform.position.y, transform.position.z);
        //        transform.LookAt(_camera.transform);
        //    }
        //}

        //Vector3 targetPosition = new Vector3(character.transform.position.x, transform.rotation.y);
        //transform.LookAt(targetPosition);
    }
}
