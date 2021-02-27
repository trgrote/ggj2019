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

    [SerializeField] rho.Event _objectBrokenEvent;

    #endregion

    public void Break()
    {
        Destroy(this.gameObject);
        Instantiate(
            _brokenPrefab, 
            transform.position, 
            transform.rotation,
            transform.parent
        );

        _objectBrokenEvent.Raise(_soundValue, _breakSoundEffect);
    }
}
