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
        Destroy(gameObject);
    }
}
