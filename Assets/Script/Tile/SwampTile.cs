using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("SwapTile , OnTriggerEnter2D " + collision.name);
            if(!swampSound.isPlaying)
                swampSound.Play();
            playerAction.PlayerCorouine(PlayerState.slowMovement, 1);
            PlayerStatus.instance.OnDamageFatigue(HF_Constance.SWAMPTILE);
        }
    }


}
