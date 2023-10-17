using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �ʵ忡 ������ �ִ� �����ۿ� �����ϸ�
/// �������� ������ �����մϴ�.
/// 
/// #���� ������Ʈ#
/// ChickLeg , FireItem, Food, Fruit, Key, MushRoom
/// 
/// #Method#
/// -public Item GetItem()
/// �������� ������ ��ȯ�մϴ�.
/// 
/// -public void DestoryItem()
/// ���� ������Ʈ�� �ı��մϴ�.
/// </summary>
public class FildItem : MonoBehaviour
{
    public Item item;                   // Scriptable ������ ���� �ޱ�

    [HideInInspector]
    public bool isAvailable;            // ������ ��� ����, 2ȸ ȹ�� ����

    private void Start()
    {
        isAvailable = false;
    }

    public Item GetItem()
    {
        return item;
    }
    public void DestoryItem()
    {
        Destroy(gameObject);
    }
}
