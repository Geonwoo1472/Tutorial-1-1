using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                playerAction.PlayerCorouine(PlayerState.MoveOff,2.0f);
            }

            gameManager.currentMapName = transferMapName;
            SceneManager.LoadScene(chapterIndex);

        }
    }
}
