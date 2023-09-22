using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPotal : MonoBehaviour
{
    public string transferMapName;          // �̵��� Spwan ���ڿ� ����

    [HideInInspector]
    public GameObject map;                  // �̵��� ���� ���� ������Ʈ ����

    private GameManager gameManager;        // gameManger
    private GameObject player;              // player ��ü
    private Player_Action playerAction;     // �÷��̾��� ��ũ��Ʈ
    private CameraMove CMove;               // ī�޶��� ��ũ��Ʈ
    private FadeEffect fadeEffect;          // fade�� ��ũ��Ʈ

    private void Start()
    {
        gameManager = GameManager.instance;
        map = GameObject.Find(transferMapName);
        player = GameObject.Find("Player");
        playerAction = player.GetComponent<Player_Action>();
        CMove = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();

        NullChecking();
    }

    /*
     ĳ���Ͱ� ���� ������ �Ѿ�� ����� ��� ó���Դϴ�.
    ���� �Ŵ����� ���� ���� ����ϰ�,
    �÷��̾� ��ġ�� ���� ������ �̵���ŵ�ϴ�.
    ī�޶� ��ǥ�� �̵���ŵ�ϴ�.
    ���̵� ȿ���� �����ϰ�, �÷��̾ ��ð� ����ϴ�.
    �÷��̾��� �Ƿε��� ���� ��ȣ�� �°� ���Ӱ� �����մϴ�.
     */
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
                playerAction.PlayerCorouine(PlayerState.MoveOff,2.0f);

                StatusManager.instance.FatigueSet();
                PlayerStatus.instance.OnDamageHunger(HF_Constance.MAPCHANGE);
            }
            else
            {
                Debug.Log("������ ��ϵ� ���� �ƴ�, MapPotal.cs ");
            }
        }
    }

    private void NullChecking()
    {
        if (map == null)
            Debug.Log(transferMapName +"is Null , MapPotal.cs ");
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
