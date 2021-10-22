using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Custom/Root Dialogue Data")]

public class RootDialogueSample : DialogueSample
{
    [SerializeField] private Sprite dialogueImage;
    public Sprite DialogueImage
    {
        get
        {
            return dialogueImage;
        }
    }

    [SerializeField] private string dialogueTitle;

    public string DialogueTitle 
    { 
        get 
        { 
            return dialogueTitle; 
        } 
    }
}
