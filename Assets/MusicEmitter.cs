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
        
    public void onTonyBellucaEnter()
    {
        PlayTonyBellucaMusic();
    }

    public void onMeterDepleted() 
    {
        PlayLossMusic();
    }
    
    public void onMeterFilled() 
    {
        PlayWinMusic();
    }
    
    public void onLevelResetStart() 
    {
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
