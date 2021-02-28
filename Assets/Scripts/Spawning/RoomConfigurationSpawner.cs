using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delete Previous Room Configuration and then spawn new configuration on Start
public class RoomConfigurationSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _roomConfigurations;

    GameObject _currentRoom;

    void Start()
    {
        // SImulate a reset
        OnLevelResetFinished();
    }

    int _prevIndex = -1;

    GameObject RandomRoom()
    {
        _prevIndex = (_prevIndex + Random.Range(
            1, 
            _roomConfigurations.Length - 1
        )) % _roomConfigurations.Length;

        return _roomConfigurations[_prevIndex];
    }

    public void OnLevelResetFinished()
    {
        if (_currentRoom != null)
        {
            Destroy(_currentRoom);
        }

        _currentRoom = Instantiate(
            RandomRoom(), 
            transform.position, 
            transform.rotation
        );
    }
}
