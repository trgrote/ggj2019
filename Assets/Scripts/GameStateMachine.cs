using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] Animator _animator;

    #region Event Handling

    public void OnMenuExit()
    {
        _animator.SetTrigger("Ready");
        GlobalValues.State = State.WaitingForTony;
    }

    public void OnTonyBellucaEnter()
    {
        _animator.SetTrigger("EnterGameMode");
        GlobalValues.State = State.GameMode;
    }

    public void OnMeterDepleted()
    {
        _animator.SetTrigger("Failure");
        GlobalValues.State = State.Failure;
    }

    public void OnMeterFilled()
    {
        _animator.SetTrigger("Victory");
        GlobalValues.State = State.Victory;
    }

    public void OnLevelResetStart()
    {
        _animator.SetTrigger("Reset");
        GlobalValues.State = State.Resetting;
        GlobalValues.SoundValue = GlobalValues.InitialSoundValue;
    }

    public void OnLevelResetFinished()
    {        
        GlobalValues.State = State.Menu;
    }

    #endregion
}
