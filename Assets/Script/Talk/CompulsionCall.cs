using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompulsionCall : MonoBehaviour
{
    private PlayerCompulsionMove playerCompulsion;
    private void Start()
    {
        playerCompulsion = GetComponent<PlayerCompulsionMove>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerCompulsion.CoroutineCompulsionMove();
        }
    }
}
