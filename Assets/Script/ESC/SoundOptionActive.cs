using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 사운드옵션 판넬을 활성/비활성합니다.
/// 
/// #부착 오브젝트#
/// (S)OptionPopup
/// 
/// #Method#
/// -void ActiveChange()
/// 게임 오브젝트를 활성/비활성합니다.
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
