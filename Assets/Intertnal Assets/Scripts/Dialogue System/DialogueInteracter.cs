using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteracter : MonoBehaviour
{
    [SerializeField] private GameObject playerDialogueTitle;
    [SerializeField] private GameObject playerDialogueImage;

    [SerializeField] private GameObject dialogueTitle;
    [SerializeField] private GameObject dialogueImage;

    [SerializeField] private GameObject dialogueInteractText;

    private Dialogue dialogue;

    private void Start()
    {
        StateController.DialogueStateChanged += (state) => { };
        dialogueInteractText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogue != null)
        {
            dialogue.StartDialogue();
            dialogueInteractText.SetActive(false);

            StateController.SetPlayerState(PlayerState.Dialogue);
            StateController.SetDialogueState(DialogueState.Listening);
        }

        if ((dialogue != null) && (dialogue.State == DialogueState.Listening) && (Input.GetKeyDown(KeyCode.Space)))
        {
            SelectNextDialogue(0);
        }

        if ((dialogue != null) && (dialogue.State == DialogueState.Speaking))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectNextDialogue(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectNextDialogue(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectNextDialogue(2);
            }
        }
    }

    private void SelectNextDialogue(int index)
    {
        if (dialogue.CurrentDialogue.EventNames.Count < (index + 1))
            return;

        Invoke(dialogue.CurrentDialogue.EventNames[index], 0);

        if (dialogue.CurrentDialogue.NextSamples.Count >= (index + 1))
            dialogue.SetDialogueSample(dialogue.CurrentDialogue.NextSamples[index]);
    }

    private void Next()
    {
        playerDialogueImage.SetActive(false);
        playerDialogueTitle.SetActive(false);

        dialogueImage.SetActive(true);
        dialogueTitle.SetActive(true);
    }

    private void NextWithoutNPC()
    {
        playerDialogueImage.SetActive(true);
        playerDialogueTitle.SetActive(true);

        dialogueImage.SetActive(false);
        dialogueTitle.SetActive(false);
    }

    private void Close()
    {
        dialogue.StopDialogue();

        StateController.SetDialogueState(DialogueState.Listening);
        StateController.SetPlayerState(PlayerState.Active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Dialogue>() != null)
        {
            dialogue = collision.gameObject.GetComponent<Dialogue>();
            dialogueInteractText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Dialogue>() != null)
        {
            dialogue = null;
            dialogueInteractText.SetActive(false);
        }
    }
}
