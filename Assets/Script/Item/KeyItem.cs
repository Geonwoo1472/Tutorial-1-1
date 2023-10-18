using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// Key�� Value���� �����մϴ�.
/// 
/// #���� ������Ʈ#
/// Key �������� FildItem��ũ��Ʈ��
/// public Item�� �ν����� â ������ �ʱ�ȭ�մϴ�.
/// 
/// #Method#
/// -public override bool Use()
/// Ű�� ����ϴ� �뵵�� �ƴ϶� ����� �����ϴ�.
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