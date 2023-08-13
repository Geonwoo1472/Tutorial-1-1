using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FildItem : MonoBehaviour
{
    public Item item;                   // Scriptable 아이템 정보 받기

    private SpriteRenderer image;       // 스크립테이블에 등록된 이미지로 변경하기 위함
    [HideInInspector]
    public bool isAvailable;            // 아이템 사용 유무, 2회 획득 방지

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
