using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_sc : MonoBehaviour
{
    public GameObject depature;
    public GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            canvas.SetActive(false);
        }
    }

    //public void teleport_dp()
    //{
    //    other.transform.position = depature.transform.position;
    //}

}
