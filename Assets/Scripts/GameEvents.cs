// This File just holds all our game events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rho;

public class MeterDepletedEvent : IGameEvent {}

public class MeterFilledEvent : IGameEvent {}

public class LevelResetFinishedEvent : IGameEvent {}