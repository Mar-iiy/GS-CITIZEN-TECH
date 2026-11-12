using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class TutorialDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private int dialogueInt;
    [SerializeField] private string[] currentDialogue;

    [Header("Dialogue Strings")]
    [SerializeField] private string[] tutorialdialogueString;
    [SerializeField] private string[] dialogue01String;
    [SerializeField] private string[] dialogue02String;
    [SerializeField] private string[] dialogue03String;
    [SerializeField] private string[] dialogue04String;

    [Header("Current Group")]
    public int currentDialogueGroup = 0;

    public bool isSpeaking;

    void Start()
    {
        SetDialogueGroup(0);
    }

    public void ChangeDialogue()
    {
        if (!isSpeaking)
            return;

            dialogueInt++;
            UpdateDialogue();
    }

    void UpdateDialogue()
    {
        if (currentDialogue == null || dialogueInt >= currentDialogue.Length)
        {
            dialoguePanel.SetActive(false);
            isSpeaking = false;
            return;
        }

        dialogueText.text = currentDialogue[dialogueInt];
    }


    public void SetDialogueGroup(int group)
    {
        currentDialogueGroup = group;

        switch (currentDialogueGroup)
        {
            case 0:
                currentDialogue = tutorialdialogueString;
                break;

            case 1:
                currentDialogue = dialogue01String;
                break;

            case 2:
                currentDialogue = dialogue02String;
                break;

            case 3:
                currentDialogue = dialogue03String;
                break;

            case 4:
                currentDialogue = dialogue04String;
                break;

            default:
                return;
        }

        dialogueInt = 0;
        dialoguePanel.SetActive(true);
        isSpeaking = true;

        UpdateDialogue();
    }
}
