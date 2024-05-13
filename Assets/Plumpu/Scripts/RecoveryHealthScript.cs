using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoveryHealthScript : MonoBehaviour
{
    CharacterHealthScript _healthsScript;
    [SerializeField] private GameObject _parent;

    [Space]
    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Button _btnCanvas;

    private void Start()
    {
        _healthsScript = FindAnyObjectByType<CharacterHealthScript>();

        _btnCanvas.onClick.AddListener(TakeRecoveryHealth);
    }

    private void Update()
    {
        if (_healthsScript._health < _healthsScript._maxHp)
        {

            _btnCanvas.interactable = true;
        }
        else
        {
            _btnCanvas.interactable = false;
        }
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

    void TakeRecoveryHealth()
    {
        _healthsScript.Heal();
        //_Child.SetActive(false);
        Destroy(gameObject);
    }
}
