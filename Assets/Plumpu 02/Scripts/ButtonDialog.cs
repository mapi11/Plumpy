using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonDialog : MonoBehaviour
{
    [HideInInspector]
    public string nameobj;

    //private GameObject light_obj;
    //private LightOpened light;

    [SerializeField] private GameObject _dialogCanvas;

    [SerializeField] private Button _btnDialog;

    private bool cheked = false;

    private GameObject objspwn;

    private DialogScript dialogscript;

    public TextMeshProUGUI text;

    //[HideInInspector]
    public int count;

    private void Awake()
    {
        _btnDialog.onClick.AddListener(Skip);
        count = 1;
    }

    private void Start()
    {
        _dialogCanvas.SetActive(false);
    }

    public void Skip()
    {
        objspwn = GameObject.Find(nameobj);
        dialogscript = objspwn.GetComponent<DialogScript>();

        if(/*dialogscript.active_light == true && */cheked == false)
        {

            //light = light_obj.GetComponent<LightOpened>();
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
            //dialogscript.load.SetActive(true);
            dialogscript._phoneButtons.SetActive(true);
            //if(dialogscript.active_light == true)
            //{
            //    for(int i = 0; i < light.liist_light.Length; i++)
            //    {
            //        light.liist_light[i].SetActive(true);
            //    }
            //}
        }
    }
    public string used(string a)
    {
        nameobj = a;
        return nameobj;
    }
}
