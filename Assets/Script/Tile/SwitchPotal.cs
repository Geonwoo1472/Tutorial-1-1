using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 누르는 스위치의 작동여부에 따라 오브젝트를 활성/비활성 합니다.
/// 
/// #object used(부착 오브젝트)#
/// 빈 오브젝트
/// 
/// #Method#
/// 델리게이트로 돌아가기 때문에
/// 적용할 switchArray 변수에 스위치를 잘 초기화해서 사용할 것
/// 
/// </summary>
public class SwitchPotal : MonoBehaviour
{
    public PushSwitchTile[] switchArray;

    private int activeSwitchCount;
    private int switchCount;

    private void Awake()
    {
        activeSwitchCount = 0;
        switchCount = switchArray.Length;
    }

    private void Start()
    {
        for(int i=0; i<switchArray.Length; i++)
        {
            switchArray[i].onSwitchActive += SwitchOn;
            switchArray[i].offSwitchActive += SwitchOff;
        }
        gameObject.SetActive(false);
    }

    /*
     스위치 작동들어오면 이 메소드가 호출됩니다.
     등록된 스위치가 모두활성화 된다면 포탈이 활성화됩니다.
     */
    private void SwitchOn()
    {
        ++activeSwitchCount;
        if (switchCount == activeSwitchCount)
            OnActive();
    }
    /*
     스위치가 꺼지는 경우 이 메소드가 호출됩니다.
     스위치가 하나라도 꺼진다면 오브젝트를 비활성합니다.
     */
    private void SwitchOff()
    {
        --activeSwitchCount;
        OffActive();
    }

    private void OffActive()
    {
        gameObject.SetActive(false);
    }

    private void OnActive()
    {
        gameObject.SetActive(true);
    }
}
