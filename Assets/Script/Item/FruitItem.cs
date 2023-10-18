using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �÷��̾��� �Ƿε��� ȸ����Ű�ų� ���ҽ�Ű�� ����� �����Ǿ� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// ���� �����ۿ� ���Ǹ� FildItem ��
/// public Item�� �ν����� â�� �ʱ�ȭ�Ͽ� ����մϴ�.
/// 
/// #Method#
/// -public override bool Use()
/// �Ƿε��� -2~3 ȸ���մϴ�.
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

        Debug.Log("FruitItem.cs ȸ�� ��ġ: " + fruitRange);

        retValue = true;
        return base.Use();
    }
}
