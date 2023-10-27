using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSetting : MonoBehaviour
{
    private Transform playerPos;
    
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        Vector2 pos = new Vector2(-11.3f, 3.9f);
        playerPos.position = pos;
    }
}
