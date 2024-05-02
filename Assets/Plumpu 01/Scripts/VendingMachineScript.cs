using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineScript : MonoBehaviour
{
    //[SerializeField] private GameObject VendingMachine;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject canvas;

    [Header("Vending")]
    [SerializeField] private GameObject _vendingCanvas;
    [SerializeField] private Button _btnSpawnObj;
    private GameObject _parent;

    [Header("Random range")]
    [SerializeField] private int Min_int=1;
    [SerializeField] private int Max_int=3;
    private int _int;

    MainCharacterControllerScript Active;

    public bool test;

    [HideInInspector]
    public int count = 0;

    private void Awake()
    {
        _parent = GameObject.Find("Objects-2D");

        _btnSpawnObj.onClick.AddListener(Spawn_water);

        _int = Random.Range(Min_int, Max_int);
        Active = FindAnyObjectByType<MainCharacterControllerScript>();
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


        if (_int <= 0)
        {
            gameObject.SetActive(false);
            Destroy(canvas);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player");
        {
            if (Active.Active2D == true || Active.Active3D == true)
            {
                canvas.SetActive(true);
            }
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
        Instantiate(water, transform.position, transform.rotation, _parent.transform);
        count++;
    }
}
