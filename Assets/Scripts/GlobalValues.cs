using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Menu,
    WaitingForTony,
    GameMode,
    Victory,
    Failure,
    Resetting
}

public static class GlobalValues
{
    public static float InitialSoundValue = 0.57f;
    public static float SoundValue = InitialSoundValue;

    public static State State = State.Menu;
}
