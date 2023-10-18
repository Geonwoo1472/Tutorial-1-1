using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 플레이어의 배고픔을 회복하는 수치를 설정하고,
/// 회복되는 기능이 구현되어 있습니다.
/// 
/// #부착 오브젝트#
/// 배고픔 회복 아이템의 삭제로 현재는 사용되고 있지 않습니다.
/// 
/// #Method#
/// -public override bool Use()
/// 플레이어의 배고픔을 healValue만큼 회복합니다.
/// 
/// </summary>
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