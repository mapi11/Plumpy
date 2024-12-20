using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineScript : MonoBehaviour, IdisableScript
{
    [SerializeField] private GameObject _disbledPart;
    [SerializeField] private bool _is2D = true;

    [Space]
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnSpawnObj;
    [SerializeField] private Transform _parent;

    [Space]
    [Header("Random range")]
    [SerializeField] private int Min_int=1;
    [SerializeField] private int Max_int=3;
    [SerializeField] private int _int; // ������ ��� ����

    MainCharacterControllerScript _mainCharacterControllerScript;


    [HideInInspector]
    public int count = 0;

    private void Start()
    {

        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _btnSpawnObj.onClick.AddListener(Spawn_water);

        _int = Random.Range(Min_int, Max_int+1);

        //TEST_.AddObject(gameObject, ObjectTags.Obj2D);
    }

    private void Update()
    {
        if (_int <= 0)
        {
            _canvas.SetActive(false);
            //Destroy(canvas);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && _int != 0)
        {
            //if (Active.Active2D == true || Active.Active3D == true)
            //{
                _canvas.SetActive(true);
            //}
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _canvas.SetActive(false);
        }
    }

    public void Spawn_water()
    {
        _int--;

        if (_int >= 0)
        {
            Instantiate(water, _parent.transform.position, _parent.transform.rotation, _parent.transform);
            count++;
        }
    }

    //------------------------------------------------------------------Check player
    private bool PlayerInTrigger()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    public void Disble()
    {
        //if (_is2D == true)
        //{
        //    _disbledPart.SetActive(false);
        //}
        //else
        //{
        //    _disbledPart.SetActive(true);
        //}
    }

    public void Enable()
    {

            //if (_is2D == true)
            //{
            //    _disbledPart.SetActive(true);
            //}
            //else
            //{
            //    _disbledPart.SetActive(false);
            //}


        _canvas.SetActive(PlayerInTrigger());
    }
}