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

        if(instance != null)
            return;
        instance = this;
    }

    public void beach()
    {
        audioSource.clip = auidoClipfiles[0];
        audioSource.Play();
    }

    public void flare()
    {
        audioSource.clip = auidoClipfiles[1];
        audioSource.Play();
    }
}
