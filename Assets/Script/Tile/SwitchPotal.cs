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
     ����ġ �۵������� �� �޼ҵ尡 ȣ��˴ϴ�.
     ��ϵ� ����ġ�� ���Ȱ��ȭ �ȴٸ� ��Ż�� Ȱ��ȭ�˴ϴ�.
     */
    private void SwitchOn()
    {
        ++activeSwitchCount;
        if (switchCount == activeSwitchCount)
            OnActive();
    }
    /*
     ����ġ�� ������ ��� �� �޼ҵ尡 ȣ��˴ϴ�.
     ����ġ�� �ϳ��� �����ٸ� ������Ʈ�� ��Ȱ���մϴ�.
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
