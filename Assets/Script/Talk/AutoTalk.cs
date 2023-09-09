using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTalk : MonoBehaviour
{
    public TalkProperty talkProperty;               // 일회성용도로 사용할지 말지 결정합니다.
    public bool compulsionUse;                      // 말풍선이 끝난 후 플레이어 강제이동 유무를 결정합니다

    private DalogManager manager;                   // DalogManger.cs
    private ObjectTalkData objectTalkData;          // ObjectTalkData.cs
    private RayCastTalk rayCastTalk;
    private bool semaphore;                         //Stay에서 여러번 호출되는 것을 막습니다.

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
    만약 플레이어가 트리거 작동을 했다면
    다시 활성화 되지 않도록 내부 bool 변수를 변경하고
    Action (대화 시작 메소드) 를 시작합니다.
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
