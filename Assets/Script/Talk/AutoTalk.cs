using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTalk : MonoBehaviour
{
    private DalogManager manager;                   // DalogManger.cs
    private ObjectTalkData objectTalkData;          // ObjectTalkData.cs
    private void Start()
    {
        manager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        objectTalkData = GetComponent<ObjectTalkData>();
    }


    /* 
    ���� �÷��̾ Ʈ���� �۵��� �ߴٸ�
    �ٽ� Ȱ��ȭ ���� �ʵ��� ���� bool ������ �����ϰ�
    Action (��ȭ ���� �޼ҵ�) �� �����մϴ�.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectTalkData.isCollider = true;
            manager.Action(gameObject);
        }
    }



}
