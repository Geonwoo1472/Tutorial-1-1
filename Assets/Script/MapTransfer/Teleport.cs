using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    public Transform teleportPos;			// 이동할 위치
    private Transform playerPos;            // 플레이어 위치 

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }
    /*
     Triger가 체크되어 있는 경우 발동.
    플레이어의 위치를 지정한 위치로 이동시키고
    다시 사용하지 못하도록 bool 값을 변경하고,
    동굴 이미지를 바꿉니다.
    이후 반대편 동굴도 같은 작업을 반복합니다.
     */
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
}
