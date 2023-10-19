using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 맵 이동 기능이 구현되어 있습니다.
/// 
/// #object used(부착 오브젝트)#
/// 맵 포탈
/// 
/// #Method#
/// 캐릭터가 다음 맵으로 넘어가는 경우의 기능 처리입니다.
/// 게임 매니저에 현재 맵을 등록하고,
/// 카메라 좌표를 이동시킵니다.
/// 페이드 효과를 연출하고, 플레이어를 잠시간 멈춥니다.
/// 플레이어의 피로도를 맵의 번호에 맞게 새롭게 셋팅합니다.
///     
/// 
/// </summary>
public class MapPotal : MonoBehaviour
{
    public string transferMapName;          // 이동할 Spwan 문자열 변수

    [HideInInspector]
    public GameObject map;                  // 이동할 맵의 게임 오브젝트 변수

    private GameManager gameManager;        // gameManger
    private GameObject player;              // player 객체
    private Player_Action playerAction;     // 플레이어의 스크립트
    private CameraMove CMove;               // 카메라의 스크립트
    private FadeEffect fadeEffect;          // fade의 스크립트

    private void Awake()
    {
        map = GameObject.Find(transferMapName);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        player = GameObject.Find("Player");
        playerAction = player.GetComponent<Player_Action>();
        CMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();

        NullChecking();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.playerStartingPt = transferMapName;
            player.transform.position = map.transform.position;

            if (MapDictionary.instance.dict.ContainsKey(transferMapName))
            {
                gameManager.currentMapName = MapDictionary.instance.dict[transferMapName];
                CMove.CameraPosMove();

                fadeEffect.OnFade(FadeState.FadeIn);
                playerAction.PlayerCorouine(PlayerState.pauseMovement,2.0f);

                StatusManager.instance.FatigueSet();
                PlayerStatus.instance.OnDamageHunger(HF_Constance.MAPCHANGE);

                CommunalSound.instance.SoundPlaying(SoundType.potalSound);
            }
            else
            {
                Debug.Log("사전에 등록된 맵이 아님, MapPotal.cs ");
            }
        }
    }

    private void NullChecking()
    {
        if (map == null)
            Debug.Log(transferMapName +" :is Null , MapPotal.cs , GameObject Name: " + gameObject.name);
        if (player == null)
            Debug.Log("Player is Null, MapPotal.cs ");
        if(playerAction == null)
            Debug.Log("playerAction is Null , MapPotal.cs ");
        if (CMove == null)
            Debug.Log("CMove is Null , MapPotal.cs ");
        if (fadeEffect == null)
            Debug.Log("fadeEffect is Null , MapPotal.cs ");
    }
}
