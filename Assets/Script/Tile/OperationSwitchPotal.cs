using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ������Ʈ�� ����� ����ġ�� ���� Ȱ��/��Ȱ���Ǵ� ����Դϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ����ġ�� Ȱ��/��Ȱ�� �� �Ǵ��ϴ� ���ӿ�����Ʈ
/// 
/// #Method#
/// -public���� ����ϴ� ��� ����.
/// ��� ������ ����ġ�� switchArray�� ����Ͽ�����.
/// 
/// 
/// </summary>
public class OperationSwitchPotal : MonoBehaviour
{
    public OperationSwitch[] switchArray;
    [Header("false��� ����ġ ���� �� ON, true��� ����ġ ���� �� OFF")]
    public bool isActive;

    private int switchCount;                    // ����� ����ġ ����
    private int activeSwitchCount;              // Ȱ���� ����ġ ����
    private bool powerStatus;                   // ����ġ�� On/Off ����

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

    private void OnDestroy()
    {
        for (int i = 0; i < switchArray.Length; i++)
        {
            switchArray[i].operationSwitchOn -= SwitchOn;
            switchArray[i].operationSwitchOff -= SwitchOff;
        }
    }
}
