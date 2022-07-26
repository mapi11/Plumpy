using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonDialog : MonoBehaviour
{
    [HideInInspector]
    public string nameobj;

    private GameObject objspwn;

    private DialogScript dialogscript;

    public TextMeshProUGUI text;
    [HideInInspector]
    public int count = 1;

    public void Skip()
    {
        objspwn = GameObject.Find(nameobj);
        dialogscript = objspwn.GetComponent<DialogScript>();

        if(count < dialogscript.phrases.Length)
        {
            text.text = dialogscript.phrases[count];
            count++;
        }

        else
        {
            count = 1;
            dialogscript.dialogwd.SetActive(false);
            dialogscript.load.SetActive(true);
            dialogscript.phone.SetActive(true);
        }
    }
    public string used(string a)
    {
        nameobj = a;
        return nameobj;
    }
}
