using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthsScript : MonoBehaviour
{
    //public GameObject RestartButton;
    //public GameObject Player;
    public GameObject DeathCanvas;
    public GameObject HPCanvas;
    public int Health = 3;
    private int MaxHP = 3;
    public Text textHP;

    public Image[] lives;

    public Sprite FullHP;
    public Sprite EmptyHP;

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

            //if (i < MaxHP)
            //{
            //    lives[i].enabled = true;
            //}
            //else
            //{
            //    lives[i].enabled = false;
            //}
        }
    }
    public void Damage()
    {
        Health--;
        HPCanvas.SetActive(true);
        Invoke("Healthcanvas", delay);

        if (Health <= 0)
        {
            Time.timeScale = 0f;
            DeathCanvas.SetActive(true);
            //Debug.Log("You Dead");
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
        HPCanvas.SetActive(false);
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