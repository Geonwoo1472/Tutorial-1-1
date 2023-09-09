using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTalk : MonoBehaviour
{
    public TalkProperty talkProperty;               // ��ȸ���뵵�� ������� ���� �����մϴ�.
    public bool compulsionUse;                      // ��ǳ���� ���� �� �÷��̾� �����̵� ������ �����մϴ�

    private DalogManager manager;                   // DalogManger.cs
    private ObjectTalkData objectTalkData;          // ObjectTalkData.cs
    private RayCastTalk rayCastTalk;
    private bool semaphore;                         //Stay���� ������ ȣ��Ǵ� ���� �����ϴ�.

    public bool Semaphore
    {
        get => semaphore;
        set => semaphore = value;
    }

    private void Awake()
    {
        objectTalkData = GetComponent<ObjectTalkData>();
        semaphore = false;
    }

    private void Start()
    {
        manager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        rayCastTalk = GameObject.Find("Player").GetComponent<RayCastTalk>();
    }

    /* 
    ���� �÷��̾ Ʈ���� �۵��� �ߴٸ�
    �ٽ� Ȱ��ȭ ���� �ʵ��� ���� bool ������ �����ϰ�
    Action (��ȭ ���� �޼ҵ�) �� �����մϴ�.
     */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && rayCastTalk.getScanObject() != null && !semaphore)
        {
            semaphore = true;
            objectTalkData.autoTalkUse = true;
            manager.Action(gameObject);
        }
    }
}
