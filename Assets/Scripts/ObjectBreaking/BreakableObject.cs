using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    #region Serailized Fields

    [Tooltip("How much value does this add to the sound meter")]
    [SerializeField] float _soundValue = 0f;

    [SerializeField] GameObject _brokenPrefab;

    [SerializeField] AudioClip _breakSoundEffect;

    #endregion

    // Get Event that is thrown when this object is broken
    public ObjectBrokenEvent BreakEvent 
    {
        get
        {
            return new ObjectBrokenEvent{SoundAmount = _soundValue, SoundEffect = _breakSoundEffect};
        }
    }

    public void Break()
    {
        Destroy(this.gameObject);
        Instantiate(_brokenPrefab, transform.position, transform.rotation);
        rho.GlobalEventHandler.SendEvent(BreakEvent);
    }
}
