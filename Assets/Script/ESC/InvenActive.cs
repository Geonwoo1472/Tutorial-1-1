using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �κ��丮�� Ű�ų� ���ϴ�.
/// 
/// #���� ������Ʈ#
/// InventoryPanel
/// 
/// #Method#
/// -public void InvenOnActive()
/// GameManager I ��ư ȣ���, I�� On/Off�� ���� �����ϱ� ������ ���� ����ó�� �ʿ� 
/// ESC���� ȣ���ϱ⿡�� Pop�� �� �ϱ� ������ OnActive�� ȣ���� �Ұ����� ���� ����
/// 
/// -void OnActive()
/// �κ��丮�� ���ų� ŵ�ϴ�.
/// 
/// </summary>
public class InvenActive : UIActive
{
    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
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
