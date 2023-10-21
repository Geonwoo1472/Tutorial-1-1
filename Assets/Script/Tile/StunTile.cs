using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 해당 오브젝트와 충돌한 경우 플레이어를 내부 변수의 값의 시간만큼 정지시킵니다.
/// 
/// #object used(부착 오브젝트)#
/// StunTile
/// 
/// #Method#
/// -void OnTriggerEnter2D(Collider2D)
/// 플레이어를 잠시동안 움직이지 못하도록합니다.
/// 
/// </summary>
public class StunTile : MonoBehaviour
{
    [Header("기절시간")]
    public float stunTime;

    private Player_Action playerAction;

    void Start()
    {
        playerAction = Player_Action.instance;    
    }

    /*
     플레이어가 트리거를 활성화 시키면
     stunTime 시간만큼 멈춥니다.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerAction.PlayerCorouine(PlayerState.pauseMovement, stunTime);
        }
    }

}
