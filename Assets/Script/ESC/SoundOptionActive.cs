using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
