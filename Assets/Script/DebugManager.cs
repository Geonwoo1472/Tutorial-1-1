using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [Header("스테미너 무한")]
    [SerializeField]
    private bool statusBlock;           // 스테미너 감소 유무 변수입니다.

    private Transform myCamera;         // 카메라 좌표값을 설정합니다.
    private bool debugUse;              // 제작 모드 판단 유무입니다.

    void Start()
    {
        myCamera = GameObject.Find("Main Camera").transform;
        debugUse = true;
        InvincibilityMode();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!debugUse)
            return;
        if (other.CompareTag("MapBoxCollider"))
        {
            myCamera.position = other.transform.position;
        }
    }
    
    private void InvincibilityMode()
    {
        if (statusBlock)
            PlayerStatus.instance.testMode = true;
    }

}
