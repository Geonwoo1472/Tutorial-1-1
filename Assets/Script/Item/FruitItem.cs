using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 플레이어의 피로도를 회복시키거나 감소시키는 기능이 구현되어 있습니다.
/// 
/// #부착 오브젝트#
/// 열매 아이템에 사용되며 FildItem 의
/// public Item에 인스펙터 창에 초기화하여 사용합니다.
/// 
/// #Method#
/// -public override bool Use()
/// 피로도를 -2~3 회복합니다.
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/FruitItem", fileName = "Item Data")]
[System.Serializable]
public class FruitItem : Item
{
    public override bool Use()
    {
        int fruitRange = Random.Range(-2, 3);

        PlayerStatus.instance.OnHealFatigue(fruitRange);
        if (fruitRange > 0)
            CommunalSound.instance.SoundPlaying(SoundType.healSound);
        else if (fruitRange < 0)
            CommunalSound.instance.SoundPlaying(SoundType.damageSound);

        Debug.Log("FruitItem.cs 회복 수치: " + fruitRange);

        retValue = true;
        return base.Use();
    }
}
