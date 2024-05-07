using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;
public class DialogScript : MonoBehaviour
{
    //public GameObject _parentDialogwd;

    //public bool active_light = false;
    //public bool test_enem = false, test_vend = false;

    public string[] phrases;

    //public GameObject enemy;
    //private DamageScript _damageSc;

    //public GameObject vendingmashine;
    //private VendingMachineScript _vendingmashine_;

    [HideInInspector]
    public Button botonobj;
    [HideInInspector]
    public ButtonDialog buttonDialog;

    public GameObject _phoneButtons;
    public GameObject dialogwd;

    [HideInInspector]
    public bool talked = false;
    [HideInInspector]
    public string nameobj;



    MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        dialogwd = GameObject.Find("DialogWD");
        _phoneButtons = GameObject.Find("ControllerButtons");

        botonobj = dialogwd.GetComponentInChildren<Button>();
        buttonDialog = botonobj.GetComponent<ButtonDialog>();

        nameobj = gameObject.name;
    }

    private void Start()
    {
        //_parentDialogwd = GameObject.Find("WindowsContent");

        //if (test_enem == true)
        //{
        //    _damageSc = enemy.GetComponent<DamageScript>();
        //}
        //else if(test_vend == true)
        //{
        //    _vendingmashine_ = vendingmashine.GetComponent<VendingMachineScript>();
        //}

        dialogwd.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(talked == false)
        {
            if(other.tag == "Player" /*&& test_enem == false && test_vend == false*/)
            {
                Talk();
            }
        }    
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (talked == false)
    //    {
    //        Talk();
    //    }
    //}

    void Talk()
    {
        buttonDialog.text.text = phrases[0];
        _mainCharacterControllerScript.ButtonStop();

        buttonDialog.used(name);
        _phoneButtons.SetActive(false);
        dialogwd.SetActive(true);
        talked = true;
    }
}
