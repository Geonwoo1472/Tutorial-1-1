using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTalk : MonoBehaviour
{
    private DalogManager manager;                   // DalogManger.cs
    private ObjectTalkData objectTalkData;          // ObjectTalkData.cs
    private RayCastTalk rayCastTalk;
    private bool disposable;

    private void Start()
    {
        manager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        objectTalkData = GetComponent<ObjectTalkData>();
        rayCastTalk = GameObject.Find("Player").GetComponent<RayCastTalk>();
        disposable = false;
    }


    /* 
    ���� �÷��̾ Ʈ���� �۵��� �ߴٸ�
    �ٽ� Ȱ��ȭ ���� �ʵ��� ���� bool ������ �����ϰ�
    Action (��ȭ ���� �޼ҵ�) �� �����մϴ�.
     */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && rayCastTalk.getScanObject() != null && !disposable)
        {
            disposable = true;
            objectTalkData.isCollider = true;
            manager.Action(gameObject);
        }
    }
}
