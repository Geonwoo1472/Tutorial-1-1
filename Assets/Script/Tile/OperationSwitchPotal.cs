using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSwitchPotal : MonoBehaviour
{
    public OperationSwitch[] switchArray;
    public bool isActive;

    private int activeSwitchCount;
    private int switchCount;

    private void Awake()
    {
        activeSwitchCount = 0;
        switchCount = switchArray.Length;
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
            ActiveChange();
        
    }

    private void SwitchOff()
    {
        --activeSwitchCount;
        ActiveChange();
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
