using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTroSoundmanager : MonoBehaviour
{
    public static OutTroSoundmanager instance;

    AudioSource audioSource;
    public AudioClip[] auidoClipfiles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance != null)
            instance = this;
    }

    public void EndingSound()
    {
        audioSource.clip = auidoClipfiles[0];
        audioSource.Play();
    }
}
