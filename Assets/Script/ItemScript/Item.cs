using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    HungerHeal,
    FatigueHeal,
    Eyesight,
    Key,
    Count
}

public class Item : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    protected bool retValue = false;

    public virtual bool Use()
    {
        return retValue;
    }
}
