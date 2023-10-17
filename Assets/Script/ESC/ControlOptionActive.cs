using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �ɼ� �˾��� Ű�ų� ���ϴ�.
/// 
/// #���� ������Ʈ#
/// (C)Option Popup
/// 
/// #Method#
/// -public override void OnActive()
/// ���� ������Ʈ�� Ȱ��ȭ �ϰų� ��Ȱ��ȭ �մϴ�.
/// Ȱ��ȭ �Ǵ� �������� ESCManager�� Stack�� �����͸� �߰��մϴ�.
/// 
/// </summary>
public class ControlOptionActive : UIActive
{
    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public override void OnActive()
    {
        ActiveChange();
    }

    private void ActiveChange()
    {
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
        if (IsActive == true)
        {
            ESCManager.instance.UIStack.Push(this);
        }
    }

}
