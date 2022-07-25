using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogScript : MonoBehaviour
{
    private GameObject objdial;

    private MainDialog mainDialog;

    public GameObject dialogwd;
    public TextMeshProUGUI textButton;

    public  GameObject load, phone;

    public bool talked = false;
    public bool spawn = false;
    private void Start()
    {
        objdial = GameObject.Find("EmptForDial");
        mainDialog = objdial.GetComponent<MainDialog>();
        load = GameObject.Find("Load");
        phone = GameObject.Find("PhoneButtonsWindow");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(talked == false)
        {
            if(other.tag == "Player")
            {
                textButton.text = mainDialog.phrases[0];
                load.SetActive(false);
                phone.SetActive(false);
                dialogwd.SetActive(true);
                spawn = true;
                talked = true;
            }
        }    
    }
}
