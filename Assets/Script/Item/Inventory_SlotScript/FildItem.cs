using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FildItem : MonoBehaviour
{

    public Item item;
    SpriteRenderer image;

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetItem(item);
    }

    public void SetItem(Item _item)
    {
        //item.efts = _item.efts;

        image.sprite = item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }
    public void DestoryItem()
    {
        // Destroy 호출 문제가 있다.
        // 아마 한싸이클 돌리고 맨 마지막에 하는 것 같은데
        // 없어지기 전에 
        Destroy(gameObject);
    }
}
