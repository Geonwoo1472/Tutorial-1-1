using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/FruitItem", fileName = "Item Data")]
[System.Serializable]
public class FruitItem : Item
{
    public override bool Use()
    {
        int fruitRange = Random.Range(-2, 3);

        PlayerStatus.instance.OnHealFatigue(fruitRange);
        Debug.Log("FruitItem.cs 회복 수치: " + fruitRange);

        retValue = true;
        return base.Use();
    }
}
