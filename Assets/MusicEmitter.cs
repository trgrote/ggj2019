using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEmitter : MonoBehaviour
{
    
    private AudioSource musicPlayer;
    
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip winMusic;
    [SerializeField] AudioClip lossMusic;
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        PlayMenuMusic();
    }

    void OnEnable()
    {
        rho.GlobalEventHandler.Register<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Register<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Register<LevelResetStartEvent>(onLevelResetStart);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<MeterDepletedEvent>(onMeterDepleted);
        rho.GlobalEventHandler.Unregister<MeterFilledEvent>(onMeterFilled);
        rho.GlobalEventHandler.Unregister<LevelResetStartEvent>(onLevelResetStart);
    }
        
    public void onTonyBellucaEnter()
    {
        PlayTonyBellucaMusic();
    }

    void onMeterDepleted(MeterDepletedEvent evt) {
        PlayLossMusic();
    }
    
    void onMeterFilled(MeterFilledEvent evt) {
        PlayWinMusic();
    }
    
    void onLevelResetStart(LevelResetStartEvent evt) {
        PlayMenuMusic();
    }

    private void PlayTonyBellucaMusic()
    {
        musicPlayer.Stop();
        musicPlayer.clip = gameMusic;
        musicPlayer.Play();
    }

    void PlayMenuMusic() {
        musicPlayer.Stop();
        musicPlayer.clip = menuMusic;
        musicPlayer.Play();
    }

    void PlayLossMusic() {
        musicPlayer.Stop();
        musicPlayer.clip = lossMusic;
        musicPlayer.Play();
    }

    void PlayWinMusic() {
        musicPlayer.Stop();
        musicPlayer.clip = winMusic;
        musicPlayer.Play();
    }
    
}
