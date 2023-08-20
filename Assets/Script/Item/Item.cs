using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 아이템의 Type Enum입니다. 
현재는 사용하고 있지는 않습니다 
 */
public enum ItemType
{
    consumable,
    material,
    key,
    count
}

public class Item : ScriptableObject
{
    public ItemType itemType;           // 아이템 Type
    public string itemName;             // 아이템 Name
    public Sprite itemImage;            // 아이템 Image

    protected bool retValue = false;    // 오버라이딩이 잘 되었는지 확인하는 변수

    public virtual bool Use()
    {
        return retValue;
    }
}
