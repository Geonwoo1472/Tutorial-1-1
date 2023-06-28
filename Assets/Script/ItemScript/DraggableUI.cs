using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 설명 */
/*
드래그 시작 시 , 드래그 중, 드래그를 종료할 때 호출되는 함수가 있습니다.  



 */

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;           // UI가 소속되어 있는 최상단의 Canvas Transform
    private Transform previousParent;   // 해당 오브젝트가 직전에 소속되어 있었던 부모 Transform
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    private SlotManager slotManager; // [삭제대상]
    private DroppableUI dropaableUI;

    //아이템 정보 저장
    public Item item;
    
    [Header("public에서 private로 바꿀것")]
    public Image image;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Manager는 부모에게 있으므로 
        slotManager = GetComponentInParent<SlotManager>(); // [삭제대상]
        dropaableUI = GetComponentInParent<DroppableUI>();
    }

    private void Start()
    {
        //만약 부모 droppableUI가 있다면 슬롯을 FULL로
        if (dropaableUI != null)
            dropaableUI.isFull = true;
    }

    //이미지 정보 셋팅 [아이템 정보 추가 시 여기 작업해야 함]
    public void SetItemInfo(Item _item)
    {
        if (_item != null)
            item = _item;
        /*item.itemType = _item.itemType;
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemHeal = _item.itemHeal;

        */
        image.sprite = item.itemImage;
    }


    // 드래그가 시작되는 순간
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 직전에 소속되어 있던 부모 transform정보 저장
        previousParent = transform.parent;

        // 현재 드래그중인 UI가 화면의 최상단에 출력되도록
        transform.SetParent(canvas);    // 부모 오브젝트를 canvas로 지정
        transform.SetAsLastSibling();   // 가장 앞에 보이도록 마지막 자식으로

        // 드래그 가능한 오브젝트가 하나가 아닌 자식들을 가지고 있을 수 있기 때문에
        // group으로 통제
        // 알파 값 변경하고, 광선 충돌처리 하지 않도록
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        //부모의 isFull을 false로
        dropaableUI = previousParent.GetComponentInParent<DroppableUI>();
        if (dropaableUI != null)
            dropaableUI.isFull = false;
        else
            Debug.Log("크래쉬! 디버그 GO ! ");

    }

    //현재 오브젝트를 드래그 중일 때 매 프레임 호출
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    // 현재 오브젝트의 드래그를 중료할 때 1회 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그를 시작하면 부모가 canvas로 설정되기 때문에
        // 드래그를 종료할 때 부모가 cavnas이면 아이템 슬롯이 아닌 엉뚱한 곳에
        // 드롭을 했다는 뜻이기 때문에 드래그 직전에 소속되어 있던 아이템 슬롯으로 아이템 이동
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;

            dropaableUI = previousParent.GetComponentInParent<DroppableUI>();
            dropaableUI.isFull = true;

        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }


    private void Update()
    {
        //Debug.Log("부모 : " + slotManager);

    }

}
