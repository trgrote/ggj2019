using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogEmitter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip[] dialogOptions;
    [SerializeField] float extraDelaySeconds = 1f;
    private int lastChosenIndex;
    private AudioSource audioPlayer;

    void Start()
    {
        lastChosenIndex = -1;
        audioPlayer = GetComponent<AudioSource>();
    }

    public void StartDialog() {
        StartCoroutine(PlayAudioClips());
    }
    
    public void StopDialog() {
        StopAllCoroutines();
    }

    public void onTonyBellucaEnter()
    {
        StartDialog();
    }

    public void onMeterDepleted() 
    {
        StopDialog();
    }
    
    public void onMeterFilled() 
    {
        StopDialog();
    }

    // Update is called once per frame
    IEnumerator PlayAudioClips()
    {
        while (true) {
            AudioClip dialog = GetRandomDialog();
            audioPlayer.PlayOneShot(dialog);
            yield return new WaitForSeconds(dialog.length + extraDelaySeconds);
        }
        
    }

    private AudioClip GetRandomDialog()
    {
        int index = Random.Range(0, dialogOptions.Length);
        if (index == lastChosenIndex) {
            index = (index + 1) % dialogOptions.Length;
        }
        lastChosenIndex = index;
        return dialogOptions[index];
    }
}
