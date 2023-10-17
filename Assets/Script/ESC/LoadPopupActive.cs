using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 로딩화면을 끄거나 킵니다. 
/// 활성화 되는 경우 ESCManager의 Stack에 값을 넣습니다.
/// 
/// #부착 오브젝트#
/// (P)LoadPopup
/// 
/// #Method#
/// -void ActiveChange()
/// 게임오브젝트를 활성/비활성 합니다.
/// 활성된다면 Stack에 넣습니다.
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