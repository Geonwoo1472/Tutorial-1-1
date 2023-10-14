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

    /* GameManager I 버튼 호출용, I로 On/Off가 전부 가능하기 때문에 따로 예외처리 필요
        ESC에서 호출하기에는 Pop을 또 하기 때문에 OnActive로 호출이 불가능해 따로 제작*/
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
