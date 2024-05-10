using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CanvasLookAtScript : MonoBehaviour
{
    public Camera[] cameras;
    //public Transform character;

    //private void Awake()
    //{
    //    character = GameObject.Find("Character-2D").transform;
    //}

    private void Update()
    {
        cameras = FindObjectsOfType<Camera>();

        Camera activeCamera = Camera.main; // �������� �������� ������

        foreach (Camera camera in cameras)
        {
            if (camera != activeCamera)
            {
                camera.gameObject.SetActive(false); // ��������� ������, ������� �� �������
            }
            else
            {
                camera.gameObject.SetActive(true); // �������� �������� ������

                //Vector3 targetPosition = new Vector3(activeCamera.transform.position.x, transform.position.y, transform.position.z);
                transform.LookAt(activeCamera.transform);
            }
        }

        //Vector3 targetPosition = new Vector3(character.transform.position.x, transform.rotation.y);
        //transform.LookAt(targetPosition);
    }
}