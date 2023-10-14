using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenActive : UIActive
{
    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    /* GameManager I ��ư ȣ���, I�� On/Off�� ���� �����ϱ� ������ ���� ����ó�� �ʿ�
        ESC���� ȣ���ϱ⿡�� Pop�� �� �ϱ� ������ OnActive�� ȣ���� �Ұ����� ���� ����*/
    public void InvenOnActive()
    {
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
        if (IsActive == true)
        {;
            ESCManager.instance.UIStack.Push(this);
        }
        if (IsActive == false)
        {
            ESCManager.instance.UIStack.Pop();
        }
    }
    public override void OnActive()
    {
        ActiveChange();
    }
    private void ActiveChange()
    {
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
    }

    
}
