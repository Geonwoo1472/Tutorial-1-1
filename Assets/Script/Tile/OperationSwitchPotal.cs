using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void OnActive()
    {
        gameObject.SetActive(true);
    }

    private void OffActive()
    {
        gameObject.SetActive(false);
    }
}
