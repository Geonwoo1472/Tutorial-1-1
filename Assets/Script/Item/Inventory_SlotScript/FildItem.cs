using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 필드에 떨어져 있는 아이템에 부착하며
/// 아이템의 정보를 저장합니다.
/// 
/// #부착 오브젝트#
/// ChickLeg , FireItem, Food, Fruit, Key, MushRoom
/// 
/// #Method#
/// -public Item GetItem()
/// 아이템의 정보를 반환합니다.
/// 
/// -public void DestoryItem()
/// 게임 오브젝트를 파괴합니다.
/// </summary>
public class FildItem : MonoBehaviour
{
    public Item item;                   // Scriptable 아이템 정보 받기

    [HideInInspector]
    public bool isAvailable;            // 아이템 사용 유무, 2회 획득 방지

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
