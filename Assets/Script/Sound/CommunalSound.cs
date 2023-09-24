using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunalSound : MonoBehaviour
{
    public static CommunalSound instance;
    public AudioClip[] clipFiles;

    private AudioSource audioSource;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void SoundPlaying(int type)
    {
        if (type >= clipFiles.Length)
        {
            Debug.Log("SoundManager.cs , 오디오 파일 없음");
            return;
        }
        audioSource.clip = clipFiles[type];

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
