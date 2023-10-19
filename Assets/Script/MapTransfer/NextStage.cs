using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾��� ������ �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// NextChange.cs �� �����Ǿ� �ִ� ������Ʈ ��
/// ĳ���� ������ ���õǾ�� �ϴ� ���
/// 
/// #Method#
/// private void OnTriggerEnter2D(Collider2D)
/// ���ӸŴ����� ������ �ִ� �� ���� ���ڿ��� �ٲ��ݴϴ�.
/// ���� �÷��̾��� ������ �����մϴ�.
/// 
/// </summary>
public class NextStage : MonoBehaviour
{
    public string transferMapName;              //�̵��� �� �̸�
    public int chapterIndex;                    //���� ���ε� �̵��� �� �ε���

    private GameManager gameManager;            //�� ���� ���ڿ��� �����ϱ� ����.
    private GameObject player;                  // player ��ü
    private Player_Action playerAction;         // �÷��̾��� ��ũ��Ʈ
    private FadeEffect fadeEffect;              // fade�� ��ũ��Ʈ

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

                /*���� �ε��� ������ �޼ҵ� �ȿ� �ִ� Init�����ϸ� �ȵ�..*/
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
