using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class ModernDialogScript : MonoBehaviour
{
    public GameObject dialogPrefab;
    public GameObject _childObject;
    public Sprite playerIcon;
    public Sprite characterIcon;
    public string[] dialogueLines;

    private bool _isTalked;
    private int currentLine = 0;
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
        if (other.CompareTag("Player"))
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
            _phoneButtons.SetActive(false);
            _character.SetActive(false);
            _childObject.SetActive(false);

            dialogBox = Instantiate(dialogPrefab, _canvasPlayer);

            dialogBox.GetComponentInChildren<Button>().onClick.AddListener(NextLine);
            dialogBox.transform.GetChild(0).GetComponent<Image>().sprite = playerIcon;
            dialogBox.transform.GetChild(1).GetComponent<Image>().sprite = characterIcon;
            dialogText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();

            //dialogBox.SetActive(true);
            currentLine = 0;
            dialogText.text = dialogueLines[currentLine];
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
            _phoneButtons.SetActive(true);
            _character.SetActive(true);
            _childObject.SetActive(true);
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        Destroy(dialogBox);
    }
}