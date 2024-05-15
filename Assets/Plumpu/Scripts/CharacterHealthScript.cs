using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthScript : MonoBehaviour
{
    [Space]
    [SerializeField] public int _health;
    [SerializeField] public int _maxHp = 3;

    [Space]
    [Header("Die")]
    [SerializeField] private GameObject _DieWindow;
    [SerializeField] private Transform _windowContent;

    [Space]
    [Header("Health")]
    Animator _anim;
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
        for (int i = 0; i < lives.Length; i++)
        {
            Animator animator = lives[i].GetComponent<Animator>();

            if (i < _health)
            {
                lives[i].sprite = FullHP;
                animator.enabled = true;
            }
            else
            {
                lives[i].sprite = EmptyHP;
                animator.enabled = false;
            }
        }

        if (_health > _maxHp)
        {
            _health = _maxHp;
        }
    }

    public void Damage(int DamageCount = 0)
    {
        _health -= DamageCount;
        HPCanvas.SetActive(true);
        Invoke("HideHealthcanvas", delay);

        if (_health <= 0)
        {
            Deadth();
        }
    }

    public void Heal()
    {
        _health++;
        HPCanvas.SetActive(true);
        Invoke("HideHealthcanvas", delay);
    }

    public void HideHealthcanvas()
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

    public void Deadth()
    {
        Instantiate(_DieWindow, _windowContent);
        Time.timeScale = 0f;
    }
}