using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 플레이어의 피로도를 회복시키는는 수치 값을 설정하고,
/// 사용시 반영되는 기능이 구현되어 있습니다.
/// 
/// #부착 오브젝트#
/// 피로도를 회복하는 아이템 FileItem 스크립트
/// public Item에 인스펙터창에 초기화하여 사용합니다.
/// 
/// #Method#
/// -public override bool Use()
/// 지정된 값 만큼 플레이어의 피로도를 회복합니다.
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/FatigueItem", fileName = "Item Data")]
[System.Serializable]
public class FatigueItem : Item
{
    public int healValue;
    public override bool Use()
    {
        PlayerStatus.instance.OnHealFatigue(healValue);
        Debug.Log("FatigueHeal !!" + healValue);
        if(CommunalSound.instance != null)
        {
            CommunalSound.instance.SoundPlaying(SoundType.healSound);
        }
        
        retValue = true;

        return base.Use();
    }
}