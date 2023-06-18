using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [Header("기능 사용")]
    [SerializeField]
    private bool debugUse;

    [Header("스테미너 무한")]
    [SerializeField]
    private bool statusBlock;

    public Transform camera;

    void Start()
    {
        if (!debugUse)
            return;

        //스테미너 감소수치 체크되어있다면 StatusManager의 testMode 변수를 true로 할 것
        if (statusBlock)
            PlayerStatus.instance.testMode = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!debugUse)
            return;

        // 만약 부딪힌게 Tag 카메라라면 위치 받아와서 현재 카메라의 위치를 강제로 이동
        if (other.CompareTag("MapBoxCollider"))
        {
            camera.position = other.transform.position;
        }
    }
    
}
