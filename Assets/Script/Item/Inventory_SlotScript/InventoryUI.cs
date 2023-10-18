using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// #용도#
/// 플레이어가 아이템을 획득할 시 인벤토리에 반영되기 위한 기능들이 있습니다.
/// 
/// #부착 오브젝트#
/// Canvas
/// 
/// #Method#
/// -void RedrawSlotUI(Item)
/// 플레이어가 아이템을 획득할 시 인벤토리를 랜더링합니다.
/// 실제로 그리는 것만이 아닌 게임오브젝트를 생성함으로써 랜더링됩니다.
/// 
/// -void TmpTextChange(int , int)
/// 인벤토리에 변동이 있을 시 무게 Text 변경용
/// 
/// -void SliderWeightChange(int , int)
/// 인벤토리에 변동이 있을 시 슬라이더 Value 변경용
/// 
/// [변경]
/// Slot[] 삭제 , Slot의 미사용으로 스크립트 삭제
/// SlotChange() 삭제, 슬롯 증가 기능 삭제로 Button의 interactable유무 판단이 불필요해짐.
/// inven.onSlotCountChange += SlotChange; 구문 삭제, SlotChange() 삭제로 인해 불필요.
/// AddSlot() 삭제, 슬롯 증가 기능 삭제로 불필요해짐.
/// 
/// </summary>
public class InventoryUI : MonoBehaviour
{
    // 자식들을 가져오기 위함. 인스펙터에서 할당
    public Transform slotHolder;

    //인벤토리
    Inventory inven;

    //item 프리팹
    public GameObject _prefeb;

    // 인벤토리 하단 TextUI
    public TextMeshProUGUI tmpCountText;
    public Slider invenSlider;
    

    void Start()
    { 
        inven = Inventory.instance;

        // 대리자 등록 , 아이템 획득 시 UI에 반영되도록
        inven.onChangeItem += RedrawSlotUI;

        // 대리자 등록 , 인벤토리 TextUI
        inven.onChangeItemTextUI += TmpTextChange;
        inven.onChangeItemTextUI += SliderWeightChange;
    }

    // 플레이어가 필드 아이템 획득 시 호출
    void RedrawSlotUI(Item _item)
    {
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
    void SliderWeightChange(int count, int capacity)
    {
        invenSlider.value = (float)count / (float)capacity;
    }

}
