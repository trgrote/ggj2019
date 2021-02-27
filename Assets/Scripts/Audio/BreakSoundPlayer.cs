using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BreakSoundPlayer : MonoBehaviour
{
    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Player a one shot audio clip
    public void OnObjectBroken(object[] args)
    {
        var soundEffect = (AudioClip) args[1];
        _audioSource.PlayOneShot(soundEffect);
    }
}
