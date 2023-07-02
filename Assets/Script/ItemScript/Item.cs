using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    HungerHeal,
    FatigueHeal,
    Persistence,
    Key,
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
    public short keyNum;

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
            case ItemType.Key:
                {
                    // 플레이어에게 key를 가지는 고유 변수를 주고 그 변수값을 바꾸는 형식으로 작동
                    // 사실 상속받는 형태로 설계했어야 됐다 Key는 Heal변수값이 필요없기때문도 있고 관리면도 있고
                    PlayerStatus.instance.OnKeyValue(keyNum);
                    Debug.Log("keyNum !!" + keyNum);

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
