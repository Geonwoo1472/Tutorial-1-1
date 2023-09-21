using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    [HideInInspector]
    public int teleports;                 // 난수 발생할 포트 넘버
    [HideInInspector]
    public static int[] numberArray;
    private Transform teleportPos;			// 이동할 위치
    private Transform playerPos;            // 플레이어 위치 

    void Awake()
    {
        numberArray = new int[teleports];
    }
    void Start()
    {
        int num = RandomNumber(numberArray, teleports);
        Debug.Log(teleports);
        //Debug.Log(num);
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
