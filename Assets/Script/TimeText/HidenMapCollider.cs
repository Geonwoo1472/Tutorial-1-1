using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

/// <summary>
/// #Usage(�뵵)#
/// ����ʿ� ���� ��� Light�� Ȱ��ȭ ��Ű��
/// TimeText�� UI�� Ȱ��ȭ �ǵ����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// MapBoxCollider
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// �÷��̾� ����Ʈ�� Ȱ��ȭ��Ű��, ���ѽð��� ����Ǵ� ������Ʈ�� Ȱ��ȭ�մϴ�.
/// 
/// -private void OnTriggerExit2D(Collider2D)
/// �÷��̾� ����Ʈ�� ��Ȱ����Ű�� , ���ѽð��� ����Ǵ� ������Ʈ�� ��Ȱ���մϴ�.
/// 
/// </summary>
public class HidenMapCollider : MonoBehaviour
{
    public float initTime;              // ���� �� �ð��� ���� ����
    public bool lightActive;            // Light ��� ����

    private TimeText timeText;          // float�� TimeText UI�� ����
    private PlayerLight2DController playerLight2DController;    // �÷��̾� ����Ʈ
    private GameObject playerLightObject;

    private void Start()
    {
        timeText = GameObject.Find("TimeTextParent").transform.Find("TimeText").GetComponent<TimeText>();
        playerLight2DController = PlayerLight2DController.instance;
        playerLightObject = playerLight2DController.transform.GetChild(0).gameObject;
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

            if(lightActive)
                playerLightObject.SetActive(true);
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

            if(lightActive)
                playerLightObject.SetActive(false);
        }
    }
}
