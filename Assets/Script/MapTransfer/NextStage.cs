using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 플레이어의 스텟을 셋팅합니다.
/// 
/// #object used(부착 오브젝트)#
/// NextChange.cs 가 부착되어 있는 오브젝트 중
/// 캐릭터 스텟이 셋팅되어야 하는 경우
/// 
/// #Method#
/// private void OnTriggerEnter2D(Collider2D)
/// 게임매니저가 가지고 있는 맵 정보 문자열을 바꿔줍니다.
/// 이후 플레이어의 스텟을 셋팅합니다.
/// 
/// </summary>
public class NextStage : MonoBehaviour
{
    public string transferMapName;              //이동할 맵 이름
    public int chapterIndex;                    //씬과 맵핑된 이동할 씬 인덱스

    private GameManager gameManager;            //맵 정보 문자열에 접근하기 위함.
    private GameObject player;                  // player 객체
    private Player_Action playerAction;         // 플레이어의 스크립트
    private FadeEffect fadeEffect;              // fade의 스크립트

    private StatusManager statusManager;
    private void Start()
    {
        gameManager = GameManager.instance;
        player = GameObject.Find("Player");
        playerAction = player.GetComponent<Player_Action>();
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
        statusManager = StatusManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MapDictionary.instance.dict.ContainsKey(transferMapName))
            {
                gameManager.currentMapName = MapDictionary.instance.dict[transferMapName];

                StatusManager.instance.FatigueSet();
                StatusManager.instance.HungerSet();

                /*내부 인덱스 셋팅이 메소드 안에 있다 Init부터하면 안됨..*/
                PlayerStatus.instance.InitStatus(
                   statusManager.HungerMaxData[statusManager.HungerIndex], statusManager.FatigueMaxData[statusManager.FatigueIndex],
                   statusManager.HungerData[statusManager.HungerIndex], statusManager.FatigueData[statusManager.FatigueIndex]);

                fadeEffect.OnFade(FadeState.FadeIn);
                playerAction.PlayerCorouine(PlayerState.pauseMovement,2.0f);
            }

            gameManager.currentMapName = transferMapName;
            SceneManager.LoadScene(chapterIndex);

        }
    }
}
