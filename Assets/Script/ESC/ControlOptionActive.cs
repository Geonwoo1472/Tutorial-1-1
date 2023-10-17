using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 옵션 팝업을 키거나 끕니다.
/// 
/// #부착 오브젝트#
/// (C)Option Popup
/// 
/// #Method#
/// -public override void OnActive()
/// 게임 오브젝트를 활성화 하거나 비활성화 합니다.
/// 활성화 되는 순간에는 ESCManager의 Stack에 데이터를 추가합니다.
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
