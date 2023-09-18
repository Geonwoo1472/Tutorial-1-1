using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] clipFiles;

    private AudioSource audioSource;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void TreeBrokenSound()
    {
        audioSource.clip = clipFiles[0];
        if(!audioSource.isPlaying)
            audioSource.Play();
    }
}
