using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogScript : MonoBehaviour
{
    public GameObject dialogwd;

    public string[] phrases;
    

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
            if(other.tag == "Player")
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
