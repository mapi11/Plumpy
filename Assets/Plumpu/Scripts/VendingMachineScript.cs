using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineScript : MonoBehaviour
{
    //[SerializeField] private GameObject VendingMachine;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button _btnSpawnObj;
    [SerializeField] private Transform _parent;

    [Header("Random range")]
    [SerializeField] private int Min_int=1;
    [SerializeField] private int Max_int=3;
    private int _int;

    //public bool test;

    [HideInInspector]
    public int count = 0;

    private void Awake()
    {
        _btnSpawnObj.onClick.AddListener(Spawn_water);

        _int = Random.Range(Min_int, Max_int+1);
    }

    private void Update()
    {
        if (_int <= 0)
        {
            canvas.SetActive(false);
            //Destroy(canvas);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //if (Active.Active2D == true || Active.Active3D == true)
            //{
                canvas.SetActive(true);
            //}
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
        Instantiate(water, _parent.transform.position, _parent.transform.rotation, _parent.transform);
        count++;
    }
}
