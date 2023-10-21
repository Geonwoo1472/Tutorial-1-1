using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ���� �ʿ��� ���Ǵ� ���带 �����ϰ� ����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// SoundManager
/// 
/// #Method#
/// -public void SoundPlaying(int type)
/// ���� ���� Clip���� ��ȯ�� ���带 Play�մϴ�.
/// 
/// </summary>
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

    public void SoundPlaying(int type)
    {
        if (type >= clipFiles.Length)
        {
            Debug.Log("SoundManager.cs , ����� ���� ����");
            return;
        }

        audioSource.clip = clipFiles[type];

        if(!audioSource.isPlaying)
            audioSource.Play();
    }
}
