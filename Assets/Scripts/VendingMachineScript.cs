using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
    //[SerializeField] private GameObject VendingMachine;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject canvas;

    private int _int;

    CharacterControllerScript Active;

    private void Start()
    {
        _int = Random.Range(0, 4);
        //Active = FindObjectOfType<CharacterControllerScript>();
    }

    private void Update()
    {
        //if (Active.Active2D)
        //{
        //    VendingMachine.SetActive(true);
        //}
        //if (Active.Active1D)
        //{
        //    VendingMachine.SetActive(false);
        //}


        if (_int == 0)
        {
            gameObject.SetActive(false);
            Destroy(canvas);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }

    public void Spawn_water()
    {
        _int--;
        Instantiate(water, transform.position, transform.rotation);
    }
}