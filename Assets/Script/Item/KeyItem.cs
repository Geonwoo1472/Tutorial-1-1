using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/KeyItem", fileName = "Item Data")]
[System.Serializable]
public class KeyItem : Item
{
    public short keyValue;
    public override bool Use()
    {
        PlayerStatus.instance.OnKeyValue(keyValue);
        Debug.Log("keyNum !!" + keyValue);
        retValue = true;

        return base.Use();
    }
}