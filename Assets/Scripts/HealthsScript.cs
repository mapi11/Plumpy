using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthsScript : MonoBehaviour
{
    //public GameObject RestartButton;
    //public GameObject Player;
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private GameObject HPCanvas;
    [SerializeField] private int Health = 3;
    private int MaxHP = 3;
    [SerializeField] private Text textHP;

    [SerializeField] private Image[] lives;

    [SerializeField] private Sprite FullHP;
    [SerializeField] private Sprite EmptyHP;

    private float delay = 5.0f;

    private void Update()
    {
        textHP.text = "HP: " + Health.ToString();
    }
    private void FixedUpdate()
    {
        if (Health > MaxHP)
        {
            Health = MaxHP;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < Mathf.RoundToInt(Health))
            {
                lives[i].sprite = FullHP;
            }
            else
            {
                lives[i].sprite = EmptyHP;
                
            }
        }
    }
    public void Damage()
    {
        Health--;
        HPCanvas.SetActive(true);
        Invoke("Healthcanvas", delay);

        if (Health <= 0)                         //Death
        {
            Time.timeScale = 0f;
            DeathCanvas.SetActive(true);
            //Debug.Log("You Dead");nn
        }
    }
    public void Heal()
    {
        Health++;
        HPCanvas.SetActive(true);
        Invoke("Healthcanvas", delay);
    }  
    public void Healthcanvas()
    {
        if (Health == 1)
        {
            HPCanvas.SetActive(true);
        }
        else
        {
            HPCanvas.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Damage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recovery health")
        {
            if (Health < MaxHP)
            {
                Heal();
                Destroy(other.gameObject);
            }

        }
    }
}