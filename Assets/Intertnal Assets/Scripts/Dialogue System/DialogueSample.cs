using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueState
{
    Listening,
    Speaking
}

[CreateAssetMenu(menuName = "Custom/Dialogue Data")]

public class DialogueSample : ScriptableObject
{
    [Multiline] [SerializeField] protected string text;
    public string Text
    {
        get
        {
            return text;
        }
    }

    [SerializeField] protected DialogueState state;
    public DialogueState State
    {
        get
        {
            return state;
        }
    }

    [SerializeField] protected List<string> eventNames;
    public List<string> EventNames
    {
        get
        {
            return eventNames;
        }
    }

    [SerializeField] protected List<DialogueSample> nextSamples;
    public List<DialogueSample> NextSamples
    {
        get
        {
            return nextSamples;
        }
    }
}
