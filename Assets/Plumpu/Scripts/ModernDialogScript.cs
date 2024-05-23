using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModernDialogScript : MonoBehaviour
{
    [Space]
    [Header("Prefab")]
    public GameObject dialogPrefab;
    [Space]
    [Header("Character")]
    public GameObject _childObject;
    public Sprite playerIcon;
    [Space]
    [Header("Animation")]
    public RuntimeAnimatorController playerIconAnimation;
    public RuntimeAnimatorController characterAnimation;
    public string[] dialogueLines;

    private bool _isTalked;
    private int currentLine = 0;
    private Sprite characterIcon;
    private string _mainCharName;
    private string _charName;
    private Transform _canvasPlayer;
    private GameObject dialogBox;
    private TextMeshProUGUI dialogText;
    private GameObject _phoneButtons;
    private GameObject _character;

    MainCharacterControllerScript _mainCharacterControllerScript;

    private void Awake()
    {
        _mainCharacterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

        _canvasPlayer = GameObject.Find("WindowsContent").transform;
        _phoneButtons = GameObject.Find("ControllerButtons");
        _character = GameObject.Find("Character-2D");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialogueLines.Length != 0)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {

        if (_isTalked == false)
        {
            _isTalked = true;

            _mainCharacterControllerScript.ButtonStop();

            dialogBox = Instantiate(dialogPrefab, _canvasPlayer);

            characterIcon = _childObject.transform.GetComponent<SpriteRenderer>().sprite;

            _mainCharName = "Plumpy";
            _charName = _childObject.name;

            dialogBox.transform.GetChild(0).GetComponent<Image>().sprite = playerIcon;
            dialogBox.transform.GetChild(1).GetComponent<Image>().sprite = characterIcon;
            dialogBox.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(NextLine);
            dialogBox.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(EndDialogue);

            dialogBox.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = _mainCharName;
            dialogBox.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = _charName;

            if (playerIconAnimation != null)
            {
                dialogBox.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = playerIconAnimation;
            }
            if (characterAnimation != null)
            {
                dialogBox.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = characterAnimation;
            }

            dialogText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();

            currentLine = 0;
            dialogText.text = dialogueLines[currentLine];

            _phoneButtons.SetActive(false);
            _character.SetActive(false);
            _childObject.SetActive(false);
        }
    }

    private void NextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        _phoneButtons.SetActive(true);
        _character.SetActive(true);
        _childObject.SetActive(true);
        Destroy(dialogBox);
    }
}