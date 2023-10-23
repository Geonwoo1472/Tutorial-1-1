using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

/// <summary>
/// #Usage(용도)#
/// 히든맵에 들어가는 경우 Light를 활성화 시키고
/// TimeText의 UI가 활성화 되도록합니다.
/// 
/// #object used(부착 오브젝트)#
/// MapBoxCollider
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 플레이어 라이트를 활성화시키고, 제한시간이 적용되는 오브젝트를 활성화합니다.
/// 
/// -private void OnTriggerExit2D(Collider2D)
/// 플레이어 라이트를 비활성시키고 , 제한시간이 적용되는 오브젝트를 비활성합니다.
/// 
/// </summary>
public class HidenMapCollider : MonoBehaviour
{
    public float initTime;              // 현재 방 시간초 제한 설정
    public bool lightActive;            // Light 사용 여부

    private TimeText timeText;          // float값 TimeText UI에 연동
    private PlayerLight2DController playerLight2DController;    // 플레이어 라이트
    private GameObject playerLightObject;

    private void Start()
    {
        timeText = GameObject.Find("TimeTextParent").transform.Find("TimeText").GetComponent<TimeText>();
        playerLight2DController = PlayerLight2DController.instance;
        playerLightObject = playerLight2DController.transform.GetChild(0).gameObject;
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

            if(lightActive)
                playerLightObject.SetActive(true);
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

            if(lightActive)
                playerLightObject.SetActive(false);
        }
    }
}
