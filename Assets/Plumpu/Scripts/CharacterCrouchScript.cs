using UnityEngine;
using UnityEngine.UI;

public class CharacterCrouchScript : MonoBehaviour
{
    public Animator _anim; // Ссылка на компонент Animator
    public CapsuleCollider capsuleCollider; // Ссылка на Capsule Collider
    public Button crouchButton; // Ссылка на кнопку в канвасе

    public float crouchHeight = 0.5f; // Высота коллайдера при приседании (в долях от оригинальной высоты)

    private bool isCrouching = false;
    private float originalHeight; // Исходная высота коллайдера
    private Vector3 originalCenter; // Исходный центр коллайдера

    private void Start()
    {
        // Запоминаем исходные значения высоты и центра коллайдера
        originalHeight = capsuleCollider.height;
        originalCenter = capsuleCollider.center;

        // Привязываем метод к событию нажатия на кнопку
        crouchButton.onClick.AddListener(ToggleCrouch);
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching; // Переключаем состояние пригибания

        if (isCrouching)
        {
            _anim.SetBool("Crouch", true); // Включаем анимацию пригибания
            AdjustColliderForCrouch(true); // Сжимаем коллайдер
        }
        else
        {
            _anim.SetBool("Crouch", false); // Выключаем анимацию пригибания
            AdjustColliderForCrouch(false); // Возвращаем коллайдер в исходное состояние
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
