using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip wrongSelectionSound;

    [SerializeField]
    AudioClip rightSelectionSound;

    [SerializeField]
    AudioSource audioSource;
    public void PlayWrongSelectionSound()
    {
        audioSource.PlayOneShot(wrongSelectionSound);
    }

    public void PlayRightSelectionSound()
    {
        audioSource.PlayOneShot(rightSelectionSound);
    }
}
