using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ���� ���é�Ϳ��� ����ϴ� ���带 �����ϰ� ����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// CommunalSoundManager
/// 
/// #Method#
/// -public void SoundPlaying(int)
/// ���� ���� �´� ���� Clip���� ��ü ��
/// Play() �մϴ�.
/// 
/// </summary>
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
            Debug.Log("SoundManager.cs , ����� ���� ����");
            return;
        }
        audioSource.clip = clipFiles[type];

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
