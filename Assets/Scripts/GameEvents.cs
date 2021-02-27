// This File just holds all our game events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

/// <summary>
/// Thrown when Tony Belluca enters the room
/// </summay>
public class TonyBellucaEnterEvent : IGameEvent {}

public class MeterDepletedEvent : IGameEvent {}

public class MeterFilledEvent : IGameEvent {}

public class LevelResetStartEvent : IGameEvent {}

public class LevelResetFinishedEvent : IGameEvent {}