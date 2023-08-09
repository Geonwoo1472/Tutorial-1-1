using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // 슬롯 칸이 변경되었다면 대리자로 다른 애들에게 알려주기
    public delegate void OnSlotCountChange(int val);     // 대리자 정의
    public OnSlotCountChange onSlotCountChange;          // 대리자 인스턴스화


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
            onSlotCountChange.Invoke(slotCnt);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 Tag가 FieldItem인 경우
        // 해당 오브젝트가 가지고 있는 FildItem 컴포넌트를 가져오고
        // FildItem 컴포넌트에 있는 정보인 Item을 가져오고
        // UI내 슬롯이 충분하다면 List에 Item 정보를 담는다.
        // 그리고 잘 저장되었다면 onChangeItem 함수를 호출하고 [델리게이트]
        // 해당 오브젝트는 파괴한다.

        // 가끔 2번 들어오는 경우가 있음.
        // //2회 충돌 시 bool 값으로 처리..


        if (collision.CompareTag("FieldItem"))
        {
            //Debug.Log("Inventory.cs 인데 나는 얘랑 충돌했어 !!" + collision.name);
            //Debug.Log("내 이름은 : " + gameObject.name + " 이야 !");
            FildItem filditems = collision.GetComponent<FildItem>();

            if (filditems.isAvailable)
                return;
            else
                filditems.isAvailable = true;

            if (AddItem(filditems.GetItem()))
            {
                //filditems.DestoryItem();
                collision.gameObject.SetActive(false);
            }
        }
    }




}
