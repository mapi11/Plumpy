using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogScript : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI dial;
    public int count =0;
    public int finish;

    public string[] prases;

    public bool talked = false;


    private void Start()
    {
        finish = prases.Length;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(talked == false)
        {
            if(other.tag == "Player")
            {
                canvas.SetActive(true);
                dial.text = prases[count];
                count++;
            }
        }    
    }

    public void skip()
    {
        if(count < finish)
        {
            dial.text = prases[count];
            count++;
        }
        else
        {
            talked = true;
            canvas.SetActive(false);
        }
    }
}
