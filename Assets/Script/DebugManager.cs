using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    // 퍼블릭 기능사용 bool 변수
    // 퍼블릭 카메라 변수
    // 퍼블릭 스테미너 감소수치를 막기 위한 bool 변수

    
    void Start()
    {
        //기능사용 bool 변수가 체크되어있다면 현재 오브젝트 destory 하거나 스크립트 미작동 코드
        //스테미너 감소수치 체크되어있다면 StatusManager의 testMode 변수를 true로 할 것
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 만약 부딪힌게 Tag 카메라라면
            //그 위치 받아와서 현재 카메라의 위치를 강제로 이동
    }
    
}
