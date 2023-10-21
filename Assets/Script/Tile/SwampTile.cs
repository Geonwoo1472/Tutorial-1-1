using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 플레이어의 속도를 늦추고 피로도를 소모시킵니다.
/// 
/// #object used(부착 오브젝트)#
/// 늪 타일
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 늪 소리를 재생하고 플레이어의 속도를 잠시 늦춥니다.
/// 
/// 
/// </summary>
public class SwampTile : MonoBehaviour
{
    private Player_Action playerAction;
    private AudioSource swampSound;

    private void Awake()
    {
        swampSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerAction = Player_Action.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!swampSound.isPlaying)
                swampSound.Play();
            playerAction.PlayerCorouine(PlayerState.slowMovement, 1);
            PlayerStatus.instance.OnDamageFatigue(HF_Constance.SWAMPTILE);
        }
    }


}
