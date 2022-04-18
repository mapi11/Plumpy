using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_fridge : MonoBehaviour
{
    public GameObject water;
    public GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canvas.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }

    public void Spawn_water()
    {
        Instantiate(water,transform.position,transform.rotation);
    }

}
