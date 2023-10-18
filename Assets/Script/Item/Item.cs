using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �������� �������� �⺻ �������� ���ǵǾ� �ֽ��ϴ�.
/// Scriptable������Ʈ�� �����Ǿ� �ְ�
/// ���� Heal�������̴��� �� ��ġ�� �ٸ��� ������ �� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// �����۵��� �⺻������ ���� �����Ǿ� �ֽ��ϴ�.
///  
/// #Method#
/// -public virtual bool Use()
/// �������� �� ����� �������̵��Ͽ�
/// �����۸����� �ٸ� ����� Use()�� �ϰ� ����մϴ�.
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
    public ItemType itemType;           // ������ Type
    public string itemName;             // ������ Name
    public Sprite itemImage;            // ������ Image
    public int itemNumber;               // ������ ������ȣ

    protected bool retValue = false;    // �������̵��� �� �Ǿ����� Ȯ���ϴ� ����

    public virtual bool Use()
    {
        return retValue;
    }
}
