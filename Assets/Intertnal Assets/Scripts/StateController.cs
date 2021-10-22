using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Active,
    Inactive,
    Dialogue
}

public class StateController : MonoBehaviour
{
    public delegate void PlayerEvents(PlayerState state);
    public delegate void DialogueEvents(DialogueState state);

    public static event PlayerEvents PlayerStateChanged;
    public static event DialogueEvents DialogueStateChanged;

    public static void SetPlayerState(PlayerState state)
    {
        PlayerStateChanged(state);
    }

    public static void SetDialogueState(DialogueState state)
    {
        DialogueStateChanged(state);
    }
}
