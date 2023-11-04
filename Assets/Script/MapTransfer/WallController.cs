using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public WallOpenAndClose wall;
    [Header("동굴을 움직이게 할 스위치 초기화")]
    public OperationSwitch[] operationSwitch;

    private int switchCount;                    // 연결된 스위치 개수
    private int activeSwitchCount;              // 활성된 스위치 개수
    private bool powerStatus;                   // 스위치의 On/Off 여부

    private void Awake()
    {
        activeSwitchCount = 0;
        switchCount = operationSwitch.Length;
        powerStatus = false;
    }

    private void Start()
    {
        for (int i = 0; i < operationSwitch.Length; i++)
        {
            operationSwitch[i].operationSwitchOn += OpenAction;
            operationSwitch[i].operationSwitchOff += CloseAction;
        }
    }
    private void OpenAction()
    {
        ++activeSwitchCount;
        if (switchCount == activeSwitchCount)
        {
            wall.Open();
            powerStatus = true;
        }
    }

    private void CloseAction()
    {
        --activeSwitchCount;
        if (powerStatus == true)
        {
            wall.Close();
            powerStatus = false;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < operationSwitch.Length; i++)
        {
            operationSwitch[i].operationSwitchOn -= OpenAction;
            operationSwitch[i].operationSwitchOff -= CloseAction;
        }
    }

}
