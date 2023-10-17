using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// #용도#
/// 아이템 슬롯에 대한 기능이 정의되어 있습니다.
/// 슬롯을 클릭, 마우스 포인터가 들어오는 경우, 나가는 경우
/// 아이템이 슬롯에 들어오는 경우의 기능을 처리합니다.
/// 
/// #부착 오브젝트#
/// InventorySlot [Prefab]
/// 
/// #Method#
/// -public void OnPointerClick(PointerEventData)
/// 마우스를 클릭할 때 호출됩니다.
/// 아이템을 사용하는 로직이 작성되어 있습니다.
/// 아이템이 사용할 수 있는 Type이라면 Use()를 호출하여 사용되고 소멸합니다.
/// 
/// -public void OnPointerEnter(PointerEventData)
/// 마우스 포인터가 들어온 경우 호출됩니다.
/// 마우스가 들어왔다는 것을 알리기위해 이미지의 색을 변경합니다.
/// 
/// - public void OnPointerExit(PointerEventData)
/// 마우스가 나갈 때 호출됩니다.
/// 이미지를 원래의 색으로 변경합니다.
/// 
/// -public void OnDrop(PointerEventData)
/// 아이템이 드랍되는 경우 아이템을 슬롯의 자식으로 삼습니다.
/// 
///
/// </summary>
public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler,
    IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private RectTransform rect;

    public bool isFull;

    //인벤토리
    Inventory inven;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        inven = Inventory.instance;
    }

    //마우스 클릭할 때
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemUsing();
    }

    // 마우스 포인터 들어올 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }

    // 마우스 포인터 나갈 때
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    // 현재 아이템 슬롯 영역 내부에서 드롭을 했을 때 1회 호출
    public void OnDrop(PointerEventData eventData)
    {
        // 슬롯영역의 button컴포넌트 interactable가 켜져있고 && 비어있다면
        if (eventData.pointerEnter.GetComponent<Button>().interactable && !isFull)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            isFull = true;
        }
    }


    /*  
            이곳에서는 클릭 된 순간 슬롯에 있는 자식 오브젝트를 가져오고 
            해당 오브젝트의 FildItem스크립트에서 Item정보도 가져와야합니다.
            가져왔다면  Iventory의 RemoveItem 를 호출하여 개수를 차감시키고
            Item의 Use를 사용합니다.
            이후 자식을 삭제하는 과정을 거칩니다.    
         */
    private void ItemUsing()
    {
        if (transform.childCount == 0)
            return;

        GameObject slotObject = transform.GetChild(0).gameObject;
        DraggableUI draggableUI = slotObject.GetComponent<DraggableUI>();
        Item item = draggableUI.item;
        if (item == null)
        {
            Debug.Log("item 할당 안됨 !");
            return;
        }
        
        switch(item.itemType)
        {
            case ItemType.consumable:
                {
                    inven.RemoveItem();
                    item.Use();
                    Destroy(slotObject);
                }
                break;
            case ItemType.material:
                {
                    /*작동할 기능 없으므로 공백 */
                }
                break;
            default:
                Debug.Log(" DroppableUI.cs , switch 문 default");
                break;
        }

        
    }

}
