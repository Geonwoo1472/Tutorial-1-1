using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �ε�ȭ���� ���ų� ŵ�ϴ�. 
/// Ȱ��ȭ �Ǵ� ��� ESCManager�� Stack�� ���� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// (P)LoadPopup
/// 
/// #Method#
/// -void ActiveChange()
/// ���ӿ�����Ʈ�� Ȱ��/��Ȱ�� �մϴ�.
/// Ȱ���ȴٸ� Stack�� �ֽ��ϴ�.
/// </summary>
public class LoadPopupActive : UIActive
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
        if(IsActive == true)
        {
            ESCManager.instance.UIStack.Push(this);
        }
    }

}