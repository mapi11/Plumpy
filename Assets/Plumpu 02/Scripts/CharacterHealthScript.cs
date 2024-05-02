using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthScript : MonoBehaviour
{
    [Space]
    [SerializeField] private int _health;
    [SerializeField] private int _maxHp = 3;

    [Space]
    [Header("Die")]
    [SerializeField] private GameObject _DieWindow;
    [SerializeField] private Transform _windowContent;

    [Space]
    [Header("Health")]
    [SerializeField] private Image[] lives;
    [SerializeField] private GameObject HPCanvas;

    [SerializeField] private Sprite FullHP;
    [SerializeField] private Sprite EmptyHP;

    private float delay = 5.0f;

    private void Awake()
    {
        _health = _maxHp;
    }

    private void Update()
    {
        if (_health > _maxHp)
        {
            _health = _maxHp;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < Mathf.RoundToInt(_health))
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
        _health--;
        Invoke("Healthcanvas", delay);

        if (_health <= 0)
        {
            HPCanvas.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    public void Heal()
    {
        _health++;
        HPCanvas.SetActive(true);
        Invoke("Healthcanvas", delay);
    }
    public void Healthcanvas()
    {
        if (_health == 1)
        {
            HPCanvas.SetActive(true);
        }
        else
        {
            HPCanvas.SetActive(false);
        }
    }
}
