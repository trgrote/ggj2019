// This File just holds all our game events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

// Event Thrown by the Object when it's broken
// Consumed by the Sound Manager and Audio Spawner
public class ObjectBrokenEvent : IGameEvent
{
    public float SoundAmount;
    public AudioClip SoundEffect;
}

public class StateChangedEvent : IGameEvent
{
    public GameStateManager.State State;
}
