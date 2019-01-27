using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEmitter : MonoBehaviour
{
    
    private AudioSource audioPlayer;
    
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip menuGameTransitionClip;
    [SerializeField] AudioClip winMusic;
    [SerializeField] AudioClip loseMusic;
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();        
    }

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MenuLeftEvent>(onMenuLeft);
        rho.GlobalEventHandler.Register<TonyBellucaEnterEvent>(onTonyBellucaEnter);
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(onLevelResetStart);
        rho.GlobalEventHandler.Register<LevelResetFinishedEvent>(onLevelResetFinished);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MenuLeftEvent>(onMenuLeft);
        rho.GlobalEventHandler.Unregister<TonyBellucaEnterEvent>(onTonyBellucaEnter);
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(onLevelResetStart);
        rho.GlobalEventHandler.Unregister<LevelResetFinishedEvent>(onLevelResetFinished);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void onMenuLeft(MenuLeftEvent evt) {

    }
    
    void onTonyBellucaEnter(TonyBellucaEnterEvent evt) {

    }
    
    void onMeterDepleted(MeterDepletedEvent evt) {

    }
    
    void onMeterFilled(MeterFilledEvent evt) {

    }
    
    void onLevelResetStart(LevelResetStartEvent evt) {

    }
    
    void onLevelResetFinished(LevelResetFinishedEvent evt) {

    }
    
}
