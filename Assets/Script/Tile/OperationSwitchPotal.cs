using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 오브젝트가 등록한 스위치로 인해 활성/비활성되는 기능입니다.
/// 
/// #object used(부착 오브젝트)#
/// 스위치로 활성/비활성 을 판단하는 게임오브젝트
/// 
/// #Method#
/// -public으로 사용하는 기능 없음.
/// 대신 연결할 스위치를 switchArray에 등록하여야함.
/// 
/// 
/// </summary>
public class OperationSwitchPotal : MonoBehaviour
{
    public OperationSwitch[] switchArray;
    [Header("false라면 스위치 켜질 때 ON, true라면 스위치 켜질 때 OFF")]
    public bool isActive;

    private int activeSwitchCount;
    private int switchCount;
    private bool powerStatus;

    private void Awake()
    {
        activeSwitchCount = 0;
        switchCount = switchArray.Length;
        powerStatus = false;
    }

    void Start()
    {
        for (int i = 0; i < switchArray.Length; i++)
        {
            switchArray[i].operationSwitchOn += SwitchOn;
            switchArray[i].operationSwitchOff += SwitchOff;
        }
        gameObject.SetActive(isActive);
    }

    private void SwitchOn()
    {
        ++activeSwitchCount;
        if (switchCount == activeSwitchCount)
        {
            ActiveChange();
            powerStatus = true;
        }


    }

    private void SwitchOff()
    {
        --activeSwitchCount;
        if (powerStatus == true)
        {
            ActiveChange();
            powerStatus = false;
        }
    }

    private void ActiveChange()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }

    /*
    private void OnActive()
    {
        gameObject.SetActive(true);
    }

    private void OffActive()
    {
        gameObject.SetActive(false);
    }
    */
}
