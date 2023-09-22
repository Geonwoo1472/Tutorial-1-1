using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/HungerItem", fileName = "Item Data")]
[System.Serializable]
public class HungerItem : Item
{
    public int healValue;
    public override bool Use()
    {
        PlayerStatus.instance.OnHealHunger(healValue);
        StatusManager.instance.HungerDataReflection(healValue, OPERATIONTYPE.PLUS);
        Debug.Log("HungerHeal !!" + healValue);
        retValue = true;

        return base.Use();
    }
}