using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthsScript : MonoBehaviour
{
    [SerializeField] private GameObject PhoneButtons;
    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private GameObject HPCanvas;
    [SerializeField] private int Health = 3;
    private int MaxHP = 3;

    [SerializeField] private Image[] lives;

    [SerializeField] private Sprite FullHP;
    [SerializeField] private Sprite EmptyHP;

    private float delay = 5.0f;

    private void Update()
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

        if (Health <= 0)
        {
            DeathCanvas.SetActive(true);
            PhoneButtons.SetActive(false);
            HPCanvas.SetActive(false);
            Time.timeScale = 0f;
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

        if (other.gameObject.tag.Equals("Enemy"))
        {
            Damage();
        }
    }
}