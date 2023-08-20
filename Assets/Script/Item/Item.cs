using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 �������� Type Enum�Դϴ�. 
����� ����ϰ� ������ �ʽ��ϴ� 
 */
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

    protected bool retValue = false;    // �������̵��� �� �Ǿ����� Ȯ���ϴ� ����

    public virtual bool Use()
    {
        return retValue;
    }
}
