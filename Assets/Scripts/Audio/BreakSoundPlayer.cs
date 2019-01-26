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

    // Start is called before the first frame update
    void OnEnable()
    {
        rho.GlobalEventHandler.Register<ObjectBrokenEvent>(OnObjectBroken);
    }

    void OnDisable()
    {
        rho.GlobalEventHandler.Unregister<ObjectBrokenEvent>(OnObjectBroken);
    }

    // Player a one shot audio clip
    void OnObjectBroken(ObjectBrokenEvent evt)
    {
        _audioSource.PlayOneShot(evt.SoundEffect);
    }
}
