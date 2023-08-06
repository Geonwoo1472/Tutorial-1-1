using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/FatigueItem", fileName = "Item Data")]
[System.Serializable]
public class FatigueItem : Item
{
    public int healValue;
    public override bool Use()
    {
        PlayerStatus.instance.OnHealFatigue(healValue);
        Debug.Log("FatigueHeal !!" + healValue);
        retValue = true;

        return base.Use();
    }
}