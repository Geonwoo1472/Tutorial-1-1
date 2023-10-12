using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* 설명 */
/*
    슬롯에 있는 스크립트로
    슬롯 마우스 클릭 시
    슬롯에서 마우스 포인터가 들어온 경우
    슬롯에서 마우스 포인터가 나간 경우
    슬롯 영역 내부에서 드롭이 되었을 때 호출됩니다.

    
 */
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
