using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �÷��̾��� �Ƿε��� ȸ����Ű�´� ��ġ ���� �����ϰ�,
/// ���� �ݿ��Ǵ� ����� �����Ǿ� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// �Ƿε��� ȸ���ϴ� ������ FileItem ��ũ��Ʈ
/// public Item�� �ν�����â�� �ʱ�ȭ�Ͽ� ����մϴ�.
/// 
/// #Method#
/// -public override bool Use()
/// ������ �� ��ŭ �÷��̾��� �Ƿε��� ȸ���մϴ�.
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