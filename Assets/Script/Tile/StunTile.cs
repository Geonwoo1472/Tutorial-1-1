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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerAction.PlayerCorouine(PlayerState.MoveOff, stunTime);
        }
    }

}
