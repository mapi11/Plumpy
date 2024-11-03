using UnityEngine;
using UnityEngine.UI;

public class CharacterCrouchScript : MonoBehaviour
{
    public Animator _anim; // Ссылка на компонент Animator
    public CapsuleCollider capsuleCollider; // Ссылка на Capsule Collider
    public Button btnCrouch; // Ссылка на кнопку в канвасе
    public GameObject btnJump;

    public float crouchHeight = 0.5f; // Высота коллайдера при приседании (в долях от оригинальной высоты)

    public bool isCrouching = false;
    private float originalHeight; // Исходная высота коллайдера
    private Vector3 originalCenter; // Исходный центр коллайдера

    CharacterCanUpScript characterCanUpScript;
    MainCharacterControllerScript mainCharacterControllerScript;

    private void Awake()
    {
        // Запоминаем исходные значения высоты и центра коллайдера
        originalHeight = capsuleCollider.height;
        originalCenter = capsuleCollider.center;

        // Привязываем метод к событию нажатия на кнопку
        btnCrouch.onClick.AddListener(ToggleCrouch);

        characterCanUpScript = FindAnyObjectByType<CharacterCanUpScript>();
        mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();
    }

    private void Update()
    {
        if (isCrouching)
        {
            btnJump.SetActive(false);
        }

        if (mainCharacterControllerScript.IsGrounded != true || characterCanUpScript.canUp != true)
        {
            btnCrouch.gameObject.SetActive(false);
        }
        else
        {
            btnCrouch.gameObject.SetActive(true);
        }
    }

    public void ToggleCrouch()
    {
        if (characterCanUpScript.canUp == true && mainCharacterControllerScript.IsGrounded == true)
        {
            isCrouching = !isCrouching; // Переключаем состояние пригибания

            if (isCrouching)
            {
                AdjustColliderForCrouch(true); // Сжимаем коллайдер
                btnJump.SetActive(false);

                mainCharacterControllerScript._speed = mainCharacterControllerScript._speed / 2;

                if (mainCharacterControllerScript._horSpeed > 0)
                {
                    mainCharacterControllerScript._horSpeed = mainCharacterControllerScript._speed;
                }
                else if (mainCharacterControllerScript._horSpeed < 0)
                {
                    mainCharacterControllerScript._horSpeed = -mainCharacterControllerScript._speed;
                }

            }
            else
            {
                AdjustColliderForCrouch(false); // Возвращаем коллайдер в исходное состояние
                btnJump.SetActive(true);
                mainCharacterControllerScript._speed = mainCharacterControllerScript._speed * 2;

                if (mainCharacterControllerScript._horSpeed > 0)
                {
                    mainCharacterControllerScript._horSpeed = mainCharacterControllerScript._speed;
                }
                else if (mainCharacterControllerScript._horSpeed < 0)
                {
                    mainCharacterControllerScript._horSpeed = -mainCharacterControllerScript._speed;
                }
            }
        }
    }

    private void AdjustColliderForCrouch(bool crouch)
    {
        if (crouch)
        {
            capsuleCollider.height = originalHeight * crouchHeight; // Уменьшаем высоту коллайдера для пригибания
            capsuleCollider.center = new Vector3(originalCenter.x, originalCenter.y - (originalHeight * (1 - crouchHeight) / 2), originalCenter.z); // Смещаем центр вниз
        }
        else
        {
            capsuleCollider.height = originalHeight; // Возвращаем высоту коллайдера в исходное состояние
            capsuleCollider.center = originalCenter; // Возвращаем центр в исходное положение
        }
    }
}
