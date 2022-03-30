using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    public GameObject cam;
    public float Parallax;
    float startPosX;
    float startPosY;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        float distX = (cam.transform.position.x * (1 - Parallax));
        float distY = (cam.transform.position.y * (1 - Parallax));
        transform.position = new Vector3(distX, startPosY + distY, transform.position.z);
    }
}
