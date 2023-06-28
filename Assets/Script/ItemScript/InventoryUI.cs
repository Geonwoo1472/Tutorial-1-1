using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // inventory ON/OFF
    public GameObject InventoryPanel;
    bool activeInven;

    // 자식의 slots 스크립트를 배열로 관리
    public Slot[] slots; // [삭제대상]
    // 자식들을 가져오기 위함. 인스펙터에서 할당
    public Transform slotHolder;

    //인벤토리
    Inventory inven;

    //item 프리팹
    public GameObject _prefeb;

    // 인벤토리 하단 TextUI
    public TextMeshProUGUI tmpCountText;

    void Start()
    {
        //자식 오브젝트 중 Slot스크립트를 전부 가져온다.
        slots = slotHolder.GetComponentsInChildren<Slot>(); // [삭제대상]


        inven = Inventory.instance;
        // 대리자 등록 , 인벤토리에서 set하면 SlotChange 메소드 호출
        inven.onSlotCountChange += SlotChange;

        // 대리자 등록 , 아이템 획득 시 UI에 반영되도록
        inven.onChangeItem += RedrawSlotUI;

        // 대리자 등록 , 인벤토리 TextUI
        inven.onChangeItemTextUI += TmpTextChange;
    }

    private void SlotChange(int val)
    {
        // 사용가능 슬롯 개수만큼 슬롯 ON/OFF
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    // 가방 아이템을 먹으면 이 메소드를 호출!!
    // https://www.youtube.com/watch?v=TT7wJbpt2H4 오류나면 여기보고 순서 설정
    // -> 이게 뭐냐면 대리자가 메소드를 참조하기전에 호출해서 생기는 버그
    public void AddSlot()
    {
        // 인벤 4칸씩 증가
        inven.SlotCnt += 4;
    }

    // 아이템 인벤토리 획득 시마다 대리자에 의해 호출되는 함수
    void RedrawSlotUI(Item _item)
    {
        // 활성화된 슬롯 개수만큼 반복
        // 만약 자식이 없다면 그곳에 오브젝트 생성
        // 해당 오브젝트는 Item 프리팹
        // 생성한 프리팹의 item에 들어온 매개변수 저장
        for (int i = 0; i < inven.SlotCnt; ++i)
        {
            // 버튼이 활성화 되있고 && 자식이 없다면
            if (slotHolder.GetChild(i).GetComponent<Button>().interactable && slotHolder.GetChild(i).childCount < 1)
            {
                GameObject fish = Instantiate(_prefeb);
                fish.transform.SetParent(slotHolder.GetChild(i), false);
                fish.GetComponent<DraggableUI>().SetItemInfo(_item);

                break;
            }
        }


    }

    // 인벤토리 텍스트 내용 변경
    void TmpTextChange(int count, int capacity)
    {
        tmpCountText.text = count + "/" + capacity;
    }

    void Update()
    {
        // i 키 눌렸을 경우
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInven = !activeInven;
            InventoryPanel.SetActive(activeInven);
        }
        // e키 눌렀을 경우 테스트용
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddSlot();
        }
    }
}
