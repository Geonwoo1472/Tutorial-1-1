using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string transferMapName;              //�̵��� �� �̸�
    public int chapterIndex;                    //���� ���ε� �̵��� �� �ε���

    private GameManager gameManager;            //�� ���� ���ڿ��� �����ϱ� ����.
    private GameObject player;                  // player ��ü
    private Player_Action playerAction;         // �÷��̾��� ��ũ��Ʈ
    private FadeEffect fadeEffect;              // fade�� ��ũ��Ʈ
    private void Start()
    {
        gameManager = GameManager.instance;
        player = GameObject.Find("Player");
        playerAction = player.GetComponent<Player_Action>();
        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MapDictionary.instance.dict.ContainsKey(transferMapName))
            {
                gameManager.currentMapName = MapDictionary.instance.dict[transferMapName];
                StatusManager.instance.FatigueSetting();
                fadeEffect.OnFade(FadeState.FadeIn);
                playerAction.PlayerCorouine(PlayerState.MoveOff,2.0f);
            }

            gameManager.currentMapName = transferMapName;
            SceneManager.LoadScene(chapterIndex);

        }
    }
}
