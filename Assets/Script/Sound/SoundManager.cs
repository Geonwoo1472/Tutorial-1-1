using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 현재 맵에서 사용되는 사운드를 관리하고 출력합니다.
/// 
/// #object used(부착 오브젝트)#
/// SoundManager
/// 
/// #Method#
/// -public void SoundPlaying(int type)
/// 인자 값의 Clip으로 변환후 사운드를 Play합니다.
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
            Debug.Log("SoundManager.cs , 오디오 파일 없음");
            return;
        }

        audioSource.clip = clipFiles[type];

        if(!audioSource.isPlaying)
            audioSource.Play();
    }
}
