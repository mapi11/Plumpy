using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonDialog : MonoBehaviour
{
    private GameObject objdial;
    private GameObject objspwn;
    private MainDialog mainDialog;
    private DialogScript dialogscript;


    public TextMeshProUGUI text;

    public int count = 1;
    
    public int refinish = 4;

    private void Start()
    {
        objspwn = GameObject.Find("DialogZone");
        objdial = GameObject.Find("EmptForDial");
        dialogscript = objspwn.GetComponent<DialogScript>();
        mainDialog = objdial.GetComponent<MainDialog>();
    }

    public void Skip()
    {
        

        text.text = mainDialog.phrases[count];

        if(count < refinish)
        {
            count ++;
        }
        else
        {
            refinish += 4;
            dialogscript.dialogwd.SetActive(false);
            dialogscript.load.SetActive(true);
            dialogscript.phone.SetActive(true);
        }
    }
}
