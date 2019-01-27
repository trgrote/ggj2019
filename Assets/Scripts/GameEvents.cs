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

// User navigated away from Main Menu
public class MenuLeftEvent : IGameEvent{}

/// <summary>
/// Thrown when Tony Belluca enters the room
/// </summay>
public class TonyBellucaEnterEvent : IGameEvent {}

public class MeterDepletedEvent : IGameEvent {}

public class MeterFilledEvent : IGameEvent {}

public class LevelResetStartEvent : IGameEvent {}

public class LevelResetFinishedEvent : IGameEvent {}