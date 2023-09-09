using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogData : MonoBehaviour
{
    public static ItemLogData instance;

    private int breadCount;
    private int fruitHealCount;
    private int fruitDamageCount;
    private int fruitZeroCount;
    private int fireCount;

    public int BreadCount
    {
        get => breadCount;
        set => breadCount = value;
    }
    public int FruitHealCount
    {
        get => fruitHealCount;
        set => fruitHealCount = value;
    }
    public int FruitDamageCount
    {
        get => fruitDamageCount;
        set => fruitDamageCount = value;
    }
    public int FruitZeroCount
    {
        get => fruitZeroCount;
        set => fruitZeroCount = value;
    }
    public int FireCount
    {
        get => fireCount;
        set => fireCount = value;
    }
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        breadCount = 0;
        fruitHealCount = 0;
        fruitDamageCount = 0;
        fruitZeroCount = 0;
        fireCount =0;
    }
}
