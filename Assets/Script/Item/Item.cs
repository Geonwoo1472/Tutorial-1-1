using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 아이템이 가져야할 기본 정보들이 정의되어 있습니다.
/// Scriptable오브젝트로 구현되어 있고
/// 같은 Heal아이템이더라도 그 수치를 다르게 설정할 수 있습니다.
/// 
/// #부착 오브젝트#
/// 아이템들은 기본적으로 전부 부착되어 있습니다.
///  
/// #Method#
/// -public virtual bool Use()
/// 아이템은 이 기능을 오버라이딩하여
/// 아이템마다의 다른 기능을 Use()로 일괄 사용합니다.
/// 
/// </summary>
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
    public int itemNumber;               // 아이템 고유번호

    protected bool retValue = false;    // 오버라이딩이 잘 되었는지 확인하는 변수

    public virtual bool Use()
    {
        return retValue;
    }
}
