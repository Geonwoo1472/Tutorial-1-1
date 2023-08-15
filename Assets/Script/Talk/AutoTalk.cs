using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTalk : MonoBehaviour
{
    private DalogManager manager;
    private ObjectTalkData objectTalkData;
    private void Start()
    {
        manager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        objectTalkData = GetComponent<ObjectTalkData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectTalkData.isCollider = true;
            manager.Action(gameObject);
        }
    }



}
