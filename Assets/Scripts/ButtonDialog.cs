using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonDialog : MonoBehaviour
{
    [HideInInspector]
    public string nameobj;

    private GameObject light_obj;
    private LightOpened light;
    private bool cheked = false;

    private GameObject objspwn;

    private DialogScript dialogscript;

    public TextMeshProUGUI text;
    [HideInInspector]
    public int count = 1;

    private void Start()
    {
        
    }

    public void Skip()
    {
        objspwn = GameObject.Find(nameobj);
        dialogscript = objspwn.GetComponent<DialogScript>();

        if(dialogscript.active_light == true && cheked == false)
        {
            light_obj = GameObject.Find("Lights_obj");
            light = light_obj.GetComponent<LightOpened>();
            cheked = true;
        }    

        else if(count < dialogscript.phrases.Length)
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
            if(dialogscript.active_light == true)
            {
                for(int i = 0; i < light.liist_light.Length; i++)
                {
                    light.liist_light[i].SetActive(true);
                }
            }
        }
    }
    public string used(string a)
    {
        nameobj = a;
        return nameobj;
    }
}
