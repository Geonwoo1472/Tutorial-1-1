using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

public class HidenMapCollider : MonoBehaviour
{
    public float initTime;              // 현재 방 시간초 제한 설정

    private TimeText timeText;          // float값 TimeText UI에 연동
    private Light2D globalLight2D;      // 전역 라이트 
    private PlayerLight2DController playerLight2DController;    // 플레이어 라이트

    private void Start()
    {
        timeText = GameObject.Find("TimeTextParent").transform.Find("TimeText").GetComponent<TimeText>();
        globalLight2D = GameObject.Find("BackGroundLight2D").GetComponent<Light2D>();
        playerLight2DController = PlayerLight2DController.instance;
    }


    /*
     해당 Collider 안으로 캐릭터가 들어오면
    TimeTextUI를 활성화시키고
    GlobalLight를 black으로 변환시키고
    플레이어 라이트를 활성화 시킵니다.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeText.OnActive(initTime);
            globalLight2D.color = Color.black;
            playerLight2DController.SetActive(true);
        }
    }

    /*
     히든 맵 밖으로 나가는 경우
    TimeTextUI를 비활성시키며
    글로벌 조명을 하얀색으로
    플레이어의 조명은 비활성모드로 변경합니다.
     */

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeText.OffActive();
            globalLight2D.color = Color.white;
            playerLight2DController.SetActive(false);
        }
    }
}
