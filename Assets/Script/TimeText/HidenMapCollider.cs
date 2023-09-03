using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

public class HidenMapCollider : MonoBehaviour
{
    public float initTime;              // ���� �� �ð��� ���� ����

    private TimeText timeText;          // float�� TimeText UI�� ����
    private Light2D globalLight2D;      // ���� ����Ʈ 
    private PlayerLight2DController playerLight2DController;    // �÷��̾� ����Ʈ

    private void Start()
    {
        timeText = GameObject.Find("TimeTextParent").transform.Find("TimeText").GetComponent<TimeText>();
        globalLight2D = GameObject.Find("BackGroundLight2D").GetComponent<Light2D>();
        playerLight2DController = PlayerLight2DController.instance;
    }


    /*
     �ش� Collider ������ ĳ���Ͱ� ������
    TimeTextUI�� Ȱ��ȭ��Ű��
    GlobalLight�� black���� ��ȯ��Ű��
    �÷��̾� ����Ʈ�� Ȱ��ȭ ��ŵ�ϴ�.
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
     ���� �� ������ ������ ���
    TimeTextUI�� ��Ȱ����Ű��
    �۷ι� ������ �Ͼ������
    �÷��̾��� ������ ��Ȱ������ �����մϴ�.
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
