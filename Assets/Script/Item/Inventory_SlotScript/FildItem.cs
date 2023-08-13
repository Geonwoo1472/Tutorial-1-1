using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FildItem : MonoBehaviour
{
    public Item item;                   // Scriptable ������ ���� �ޱ�

    private SpriteRenderer image;       // ��ũ�����̺� ��ϵ� �̹����� �����ϱ� ����
    [HideInInspector]
    public bool isAvailable;            // ������ ��� ����, 2ȸ ȹ�� ����

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        SetItem(item);
        isAvailable = false;
    }

    public void SetItem(Item _item)
    {
        image.sprite = item.itemImage;
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
