using UnityEngine;
using UnityEngine.UI;

public class CharacterCrouchScript : MonoBehaviour
{
    public Animator _anim; // ������ �� ��������� Animator
    public CapsuleCollider capsuleCollider; // ������ �� Capsule Collider
    public Button btnCrouch; // ������ �� ������ � �������
    public GameObject btnJump;

    public float crouchHeight = 0.5f; // ������ ���������� ��� ���������� (� ����� �� ������������ ������)

    public bool isCrouching = false;
    private float originalHeight; // �������� ������ ����������
    private Vector3 originalCenter; // �������� ����� ����������

    CharacterCanUpScript characterCanUpScript;
    MainCharacterControllerScript mainCharacterControllerScript;

    private void Awake()
    {
        // ���������� �������� �������� ������ � ������ ����������
        originalHeight = capsuleCollider.height;
        originalCenter = capsuleCollider.center;

        // ����������� ����� � ������� ������� �� ������
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
            isCrouching = !isCrouching; // ����������� ��������� ����������

            if (isCrouching)
            {
                AdjustColliderForCrouch(true); // ������� ���������
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
                AdjustColliderForCrouch(false); // ���������� ��������� � �������� ���������
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
