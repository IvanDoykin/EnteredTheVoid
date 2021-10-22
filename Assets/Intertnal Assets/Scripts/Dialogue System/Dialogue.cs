using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueTitle;
    [SerializeField] private Image dialogueImage;

    public DialogueSample CurrentDialogue { get; private set; }
    [SerializeField] private RootDialogueSample startDialogueSample;

    public DialogueState State { get; private set; }

    private void Start()
    {
        CurrentDialogue = startDialogueSample;
        StateController.DialogueStateChanged += (state) => { State = state; };
    }

    public void StartDialogue()
    {
        SetDialogueSample(startDialogueSample);

        dialogueTitle.text = startDialogueSample.DialogueTitle;
        dialogueImage.sprite = startDialogueSample.DialogueImage;

        dialoguePanel.SetActive(true);
    }

    public void SetDialogueSample(DialogueSample sample)
    {
        CurrentDialogue = sample;
        dialogueText.text = sample.Text;
        StateController.SetDialogueState(sample.State);
    }

    public void StopDialogue()
    {
        dialoguePanel.SetActive(false);
        //event that we stopped dialogue
    }
}
