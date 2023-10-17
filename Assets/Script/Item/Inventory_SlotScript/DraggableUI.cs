using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// #용도#
/// UI에서 드래그가 가능하도록 합니다.
/// 
/// 
/// #부착 오브젝트#
/// Prefab의 Item 게임오브젝트
/// 
/// #Method#
/// -public void SetItemInfo(Item)
/// 맵에 배치된 아이템오브젝트의 Item스크립트를 받아와
/// UI에 등록될 아이템에 데이터를 복사합니다.
/// 
/// -public void OnBeginDrag(PointerEventData)
/// 드래그가 시작되는 순간 호출받습니다.
/// 의도하지 않은 곳에 드랍되는 것을 방지하기위해 변경 전 위치값을 저장합니다.
/// 최상단에 랜더링되어야 하기 때문에 순위를 변경합니다.
/// 드랍이 가능했던 슬롯칸의 스크립트의 변수 isFull의 값을 변경합니다.
/// 
/// -public void OnDrag(PointerEventData)
/// 드래그 중 매 프레임 호출합니다.
/// 포지션을 업데이트합니다.
/// 
/// -public void OnEndDrag(PointerEventData)
/// 드래그를 종료하는 경우 호출합니다.
/// 슬롯에 드래그하지 못하는 경우 아이템 자리를
/// 이전으로 복구를 위한 로직입니다.
/// </summary>
public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;                   // //아이템 정보 저장

    private Transform canvas;           // UI가 소속되어 있는 최상단의 Canvas Transform
    private Transform previousParent;   // 해당 오브젝트가 직전에 소속되어 있었던 부모 Transform
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    private DroppableUI dropaableUI;
    private Image image;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        dropaableUI = GetComponentInParent<DroppableUI>();
        image = GetComponentInParent<Image>();
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
            Debug.Log("DraggableUI.cs , 68Line Crash");

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
}
