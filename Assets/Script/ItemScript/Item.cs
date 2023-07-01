using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    HungerHeal,
    FatigueHeal,
    Persistence,
    Count
}

[CreateAssetMenu(menuName = "Scriptable/Item Data", fileName = "Item Data")]
[System.Serializable]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public int itemHeal;

    public bool Use()
    {
        bool isUsed = false;

        switch (itemType)
        {
            case ItemType.HungerHeal:
                {
                    PlayerStatus.instance.OnHealHunger(itemHeal);
                    Debug.Log("HungerHeal !!" + itemHeal);

                    isUsed = true;
                }
                break;
            case ItemType.FatigueHeal:
                {
                    PlayerStatus.instance.OnHealFatigue(itemHeal);
                    Debug.Log("FatigueHeal !!" + itemHeal);

                    isUsed = true;
                }
                break;
            case ItemType.Persistence:
                {
                    Debug.Log("Persistence !!" + itemHeal);

                    isUsed = true;
                }
                break;
            default:
                break;

        }

        return isUsed;
    }
}
