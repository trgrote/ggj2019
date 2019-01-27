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
    public static float SoundValue = 0.5f;

    public static State State = State.Menu;
}
