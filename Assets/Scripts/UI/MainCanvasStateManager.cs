using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Basically just turns on/off ui elements depending on global events
public class MainCanvasStateManager : MonoBehaviour
{
    #region Serial

    [SerializeField] GameObject _mainMenuElements;
    [SerializeField] GameObject _startInstructions;
    [SerializeField] GameObject _soundMeter;
    [SerializeField] GameObject _failureElements;
    [SerializeField] GameObject _victoryElements;

    [SerializeField] ImageFade _fade;

    #endregion

    #region Monobehavior

    void Start()
    {
        // SImulate a reset
        OnLevelResetFinished(null);
    }

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(OnMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(OnMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(OnLevelResetStart);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(OnLevelResetFinished);
    }

    #endregion

    #region Event Handling

    public void OnMenuExit()
    {
        _mainMenuElements.SetActive(false);
        _startInstructions.SetActive(true);
        _soundMeter.SetActive(false);
        _failureElements.SetActive(false);
        _victoryElements.SetActive(false);
    }

    public void OnTonyBellucaEnter()
    {
        _mainMenuElements.SetActive(false);
        _startInstructions.SetActive(false);
        _soundMeter.SetActive(true);
        _failureElements.SetActive(false);
        _victoryElements.SetActive(false);
    }

    void OnMeterDepleted(MeterDepletedEvent evt)
    {
        _mainMenuElements.SetActive(false);
        _startInstructions.SetActive(false);
        _soundMeter.SetActive(true);
        _failureElements.SetActive(true);
        _victoryElements.SetActive(false);
    }

    void OnMeterFilled(MeterFilledEvent evt)
    {
        _mainMenuElements.SetActive(false);
        _startInstructions.SetActive(false);
        _soundMeter.SetActive(true);
        _failureElements.SetActive(false);
        _victoryElements.SetActive(true);
    }

    private void OnLevelResetStart(LevelResetStartEvent evt)
    {
        _mainMenuElements.SetActive(false);
        _startInstructions.SetActive(false);
        _soundMeter.SetActive(false);
        _failureElements.SetActive(false);
        _victoryElements.SetActive(false);

        // Fade to Black
        _fade.FadeOut();
    }

    void OnLevelResetFinished(LevelResetFinishedEvent evt)
    {
        // unfade from black
        _fade.FadeIn();

        _mainMenuElements.SetActive(true);
        _startInstructions.SetActive(false);
        _soundMeter.SetActive(false);
        _failureElements.SetActive(false);
        _victoryElements.SetActive(false);
    }

    #endregion
}
