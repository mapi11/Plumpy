using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogScript : MonoBehaviour
{
    

    public GameObject dialogwd;

    public bool active_light = false;
    public bool test_enem = false, test_vend = false;

    public string[] phrases;

    public GameObject enemy;
    private DamageScript _damageSc;

    public GameObject vendingmashine;
    private VendingMachineScript _vendingmashine_;

    [HideInInspector]
    public Button botonobj;
    [HideInInspector]
    public ButtonDialog buttonDialog;


    [HideInInspector]
    public  GameObject load, phone;
    [HideInInspector]
    public bool talked = false;
    [HideInInspector]
    public string nameobj;

    CharacterControllerScript characterControllerScript;

    private void Start()
    {
        if(test_enem == true)
        {
            _damageSc = enemy.GetComponent<DamageScript>();
        }
        else if(test_vend == true)
        {
            _vendingmashine_ = vendingmashine.GetComponent<VendingMachineScript>();
        }
        
        nameobj = gameObject.name;
        
        botonobj = dialogwd.GetComponentInChildren<Button>();
        buttonDialog = botonobj.GetComponent<ButtonDialog>();

        characterControllerScript = FindObjectOfType<CharacterControllerScript>();

        load = GameObject.Find("Load");
        phone = GameObject.Find("PhoneButtonsWindow");

    }
    private void OnTriggerEnter(Collider other)
    {
        if(talked == false)
        {
            if(other.tag == "Player" && test_enem == false && test_vend == false)
            {

                buttonDialog.text.text = phrases[0];
                characterControllerScript.ButtonStop();

                buttonDialog.used(name);
                load.SetActive(false);
                phone.SetActive(false);
                dialogwd.SetActive(true);
                talked = true;

            }
        }    
    }
    private void OnTriggerStay(Collider other)
    {
        if (talked == false)
        {
            if (test_enem == true && _damageSc.test == true && _damageSc.count != 0 || test_vend == true && _vendingmashine_.test == true && _vendingmashine_.count != 0)
            {
                buttonDialog.text.text = phrases[0];
                characterControllerScript.ButtonStop();

                buttonDialog.used(name);
                load.SetActive(false);
                phone.SetActive(false);
                dialogwd.SetActive(true);
                talked = true;
            }
        }
    }
}
