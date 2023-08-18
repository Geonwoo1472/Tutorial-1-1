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
    만약 플레이어가 트리거 작동을 했다면
    다시 활성화 되지 않도록 내부 bool 변수를 변경하고
    Action (대화 시작 메소드) 를 시작합니다.
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
