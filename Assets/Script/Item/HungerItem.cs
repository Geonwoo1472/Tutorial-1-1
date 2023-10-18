using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �÷��̾��� ������� ȸ���ϴ� ��ġ�� �����ϰ�,
/// ȸ���Ǵ� ����� �����Ǿ� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// ����� ȸ�� �������� ������ ����� ���ǰ� ���� �ʽ��ϴ�.
/// 
/// #Method#
/// -public override bool Use()
/// �÷��̾��� ������� healValue��ŭ ȸ���մϴ�.
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