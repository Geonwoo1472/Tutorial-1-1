using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public WallOpenAndClose wall;
    [Header("������ �����̰� �� ����ġ �ʱ�ȭ")]
    public OperationSwitch[] operationSwitch;

    private int switchCount;                    // ����� ����ġ ����
    private int activeSwitchCount;              // Ȱ���� ����ġ ����
    private bool powerStatus;                   // ����ġ�� On/Off ����

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
