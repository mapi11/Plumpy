using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpHatScript : MonoBehaviour
{
    [Space]
    [Header("Hat")]
    [SerializeField] private GameObject _hat;
    [SerializeField] private Transform _hatPivot;
    public bool _hatIsPicked;

    [Space]
    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnCanvas;


    private void Awake()
    {
        _btnCanvas.onClick.AddListener(PickUpHat);

        _hatPivot = GameObject.Find("HatPivot").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canvas.SetActive(false);
        }
    }

    void PickUpHat()
    {
        if (_hatPivot.transform.childCount > 0)
        {
            Destroy(_hatPivot.transform.GetChild(0).gameObject);
        }

        _hatIsPicked = true;

        Debug.Log("Hat picket");

        _hat.transform.parent = _hatPivot;
        _hat.transform.position = _hatPivot.position;

        gameObject.SetActive(false);

        Destroy(gameObject);

        //Destroy(_canvas);
        _hatIsPicked = true;
    }
}