using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 2DURP import

[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public int sightValue;
    public override bool Use()
    {
        Debug.Log("override ExtendTest, Item Data");

        return true;
    }
}