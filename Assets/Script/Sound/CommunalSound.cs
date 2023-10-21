using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 게임 모든챕터에서 사용하는 사운드를 관리하고 출력합니다.
/// 
/// #object used(부착 오브젝트)#
/// CommunalSoundManager
/// 
/// #Method#
/// -public void SoundPlaying(int)
/// 인자 값에 맞는 사운드 Clip으로 교체 후
/// Play() 합니다.
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
            Debug.Log("SoundManager.cs , 오디오 파일 없음");
            return;
        }
        audioSource.clip = clipFiles[type];

        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
