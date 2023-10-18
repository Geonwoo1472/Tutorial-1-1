using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// Key의 Value값을 정의합니다.
/// 
/// #부착 오브젝트#
/// Key 아이템의 FildItem스크립트의
/// public Item에 인스펙터 창 변수로 초기화합니다.
/// 
/// #Method#
/// -public override bool Use()
/// 키는 사용하는 용도가 아니라 기능은 없습니다.
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/KeyItem", fileName = "Item Data")]
[System.Serializable]
public class KeyItem : Item
{
    public short keyValue;
    public override bool Use()
    {
        retValue = true;
        return base.Use();
    }
}