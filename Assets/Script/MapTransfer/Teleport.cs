using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 현승이가 만든거네 ~ 설명 써줘
/// 
/// #object used(부착 오브젝트)#
///
/// #Method#
///
/// </summary>
public class Teleport : MonoBehaviour
{
    [HideInInspector]
    public int teleports;                 // 난수 발생할 포트 넘버
    [HideInInspector]
    public static int[] numberArray;
    private Transform teleportPos;			// 이동할 위치
    private Transform playerPos;            // 플레이어 위치 
    private CameraController controller;

    void Awake()
    {
        teleports = GetComponentInParent<TeleportParent>().numberOfPorts;
        numberArray = new int[teleports];
    }
    void Start()
    {
        int num = RandomNumber(numberArray, teleports);
        controller = GameObject.Find("CameraController").GetComponent<CameraController>();
        teleportPos = GameObject.Find("Spwan " + num).GetComponent<Transform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collapsing();
        }
    }
    protected virtual void Collapsing()
    {
        playerPos.position = teleportPos.position;
        controller.InitSetPosition();
        Player_Action.instance.PlayerCorouine(PlayerState.pauseMovement, 0.5f);
    }

    public static int RandomNumber(int[] portArray, int maxNum)
    {
        int number = Random.Range(0, maxNum);

        if (portArray[number] == 0)
        {
            portArray[number] = 1;
            return number;
        }
        else
        {
            int i;
            for(i = 0; i < maxNum; i++)
            {
                if (portArray[i] == 0)
                    break;
            }
            number = i;
            portArray[i] = 1;
            return number;
        }
    }
}
