using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPotal : MonoBehaviour
{
    public SwitchTile[] switchArray;

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
