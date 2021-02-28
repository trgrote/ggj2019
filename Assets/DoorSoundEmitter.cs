using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundEmitter : MonoBehaviour
{
    private AudioSource audioPlayer;
    
    [SerializeField] AudioClip doorSound;
    [SerializeField] AudioClip knockSound;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onMenuLeft()
    {
        StartKnocking();
    }

    private void StartKnocking()
    {
        audioPlayer.Stop();
        audioPlayer.clip = knockSound;
        audioPlayer.Play();
    }

    public void onTonyBellucaEnter()
    {
        PlayDoorBurst();
    }

    private void PlayDoorBurst()
    {
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(doorSound);
    }
}
