using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            playerAction.PlayerCorouine(PlayerState.MoveOff, stunTime);
        }
    }

}
