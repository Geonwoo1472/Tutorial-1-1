using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// ����ɼ� �ǳ��� Ȱ��/��Ȱ���մϴ�.
/// 
/// #���� ������Ʈ#
/// (S)OptionPopup
/// 
/// #Method#
/// -void ActiveChange()
/// ���� ������Ʈ�� Ȱ��/��Ȱ���մϴ�.
/// 
/// </summary>
public class SoundOptionActive : UIActive
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
