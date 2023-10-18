using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 플레이어가 맵에 배치된 아이템을 획득할 수 있도록 합니다.
/// 인벤토리에 아이템이 들어가고, 델리게이트 호출합니다.
/// 
/// #부착 오브젝트#
/// Player
/// 
/// #Method#
/// -public bool AddItem(Item)
/// 아이템을 획득할 때 
/// 슬롯에 빈공간이 있거나, 최대용량을 초과하지 않는다면
/// 아이템을 획득합니다.
/// 
/// -public bool RemoveItem()
/// 일반적으로 아이템이 소모되는 경우 호출합니다.
/// 아이템 수를 일괄 관리합니다
/// 
/// -private void OnTriggerEnter2D(Collider2D)
/// 플레이어가 아이템과 부딪히는 경우
/// 아이템의 정보를 얻어와 인벤토리에 추가한다.
/// 인벤토리에 변동이 있는 경우 델리게이트 기능이 사용된다.
/// 
/// [변경]
/// OnSlotCountChange(int) 삭제, 아이템 칸이 증가하는 기능이 없어지므로 불필요.
/// </summary>
public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    // 아이템이 추가되면 슬롯UI에도 추가되는 대리자
    public delegate void OnChangeItem(Item _item);
    public OnChangeItem onChangeItem;

    // 아이템 사용 / 획득 시 사용될 대리자
    public delegate void OnItemTextUI(int count, int capacity);
    public OnItemTextUI onChangeItemTextUI;


    // 아이템이 사용되면 슬롯UI에도 추가되는 대리자


    //아이템 최대개수 / 현재개수 
    public int capacity;
    public int count;
    // 슬롯의 개수
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
        }
    }

    void Start()
    {
        // 초기 슬롯 개수
        SlotCnt = 20;
        // 초기 최대 치
        capacity = 10;
        count = 0;
        onChangeItemTextUI.Invoke(count, capacity);
    }

    // 아이템 추가
    public bool AddItem(Item _item)
    {
        if (count < SlotCnt && count < capacity)
        {
            count++;
            onChangeItemTextUI.Invoke(count, capacity);
            //아이템 추가시 델리게이트로 UI자식으로 생성하는 함수 호출
            if (onChangeItem != null)
                onChangeItem.Invoke(_item);

            return true;
        }

        return false;
    }

    // 아이템 사용 DroppableUI에서 호출함.
    // 여기서 사용 아이템 효과 스크립트를 작성할 건지 저쪽에서 할것인지 택
    // 
    // 그리고 ..  슬롯 capacity증가에대해 어디서 호출할건지 
    public bool RemoveItem()
    {
        if (count <= 0)
            return false;

        count--;
        onChangeItemTextUI.Invoke(count, capacity);


        return false;
    }



    // 플레이어가 아이템과 충돌한 경우
    // 부딪힌 Tag가 FieldItem인 경우
    // 해당 오브젝트가 가지고 있는 FildItem 컴포넌트를 가져오고
    // FildItem 컴포넌트에 있는 정보인 Item을 가져오고
    // UI내 슬롯이 충분하다면 List에 Item 정보를 담는다.
    // 그리고 잘 저장되었다면 onChangeItem 함수를 호출하고 [델리게이트]
    // 해당 오브젝트는 파괴한다.

    // 가끔 2번 들어오는 경우가 있음.
    // //2회 충돌 시 bool 값으로 처리..
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FildItem filditems = collision.GetComponent<FildItem>();

            if (filditems.isAvailable)
                return;
            else
                filditems.isAvailable = true;

            if (AddItem(filditems.GetItem()))
            {
                collision.gameObject.SetActive(false);
                CommunalSound.instance.SoundPlaying(SoundType.itemPickUp);
            }
        }
    }




}
