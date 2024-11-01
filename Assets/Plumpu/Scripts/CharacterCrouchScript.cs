using UnityEngine;
using UnityEngine.UI;

public class CharacterCrouchScript : MonoBehaviour
{
    public Animator _anim; // ������ �� ��������� Animator
    public CapsuleCollider capsuleCollider; // ������ �� Capsule Collider
    public Button crouchButton; // ������ �� ������ � �������

    public float crouchHeight = 0.5f; // ������ ���������� ��� ���������� (� ����� �� ������������ ������)

    private bool isCrouching = false;
    private float originalHeight; // �������� ������ ����������
    private Vector3 originalCenter; // �������� ����� ����������

    private void Start()
    {
        // ���������� �������� �������� ������ � ������ ����������
        originalHeight = capsuleCollider.height;
        originalCenter = capsuleCollider.center;

        // ����������� ����� � ������� ������� �� ������
        crouchButton.onClick.AddListener(ToggleCrouch);
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching; // ����������� ��������� ����������

        if (isCrouching)
        {
            _anim.SetBool("Crouch", true); // �������� �������� ����������
            AdjustColliderForCrouch(true); // ������� ���������
        }
        else
        {
            _anim.SetBool("Crouch", false); // ��������� �������� ����������
            AdjustColliderForCrouch(false); // ���������� ��������� � �������� ���������
        }
    }

    private void AdjustColliderForCrouch(bool crouch)
    {
        if (crouch)
        {
            capsuleCollider.height = originalHeight * crouchHeight; // ��������� ������ ���������� ��� ����������
            capsuleCollider.center = new Vector3(originalCenter.x, originalCenter.y - (originalHeight * (1 - crouchHeight) / 2), originalCenter.z); // ������� ����� ����
        }
        else
        {
            capsuleCollider.height = originalHeight; // ���������� ������ ���������� � �������� ���������
            capsuleCollider.center = originalCenter; // ���������� ����� � �������� ���������
        }
    }
}
