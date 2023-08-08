using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* ���� */
/*
�巡�� ���� �� , �巡�� ��, �巡�׸� ������ �� ȣ��Ǵ� �Լ��� �ֽ��ϴ�.  



 */

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;           // UI�� �ҼӵǾ� �ִ� �ֻ���� Canvas Transform
    private Transform previousParent;   // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    private SlotManager slotManager; // [�������]
    private DroppableUI dropaableUI;

    //������ ���� ����
    public Item item;
    
    [Header("public���� private�� �ٲܰ�")]
    public Image image;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Manager�� �θ𿡰� �����Ƿ� 
        slotManager = GetComponentInParent<SlotManager>(); // [�������]
        dropaableUI = GetComponentInParent<DroppableUI>();
    }

    private void Start()
    {
        //���� �θ� droppableUI�� �ִٸ� ������ FULL��
        if (dropaableUI != null)
            dropaableUI.isFull = true;
    }

    //�̹��� ���� ���� [������ ���� �߰� �� ���� �۾��ؾ� ��]
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


    // �巡�װ� ���۵Ǵ� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ������ �ҼӵǾ� �ִ� �θ� transform���� ����
        previousParent = transform.parent;

        // ���� �巡������ UI�� ȭ���� �ֻ�ܿ� ��µǵ���
        transform.SetParent(canvas);    // �θ� ������Ʈ�� canvas�� ����
        transform.SetAsLastSibling();   // ���� �տ� ���̵��� ������ �ڽ�����

        // �巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ ���� �� �ֱ� ������
        // group���� ����
        // ���� �� �����ϰ�, ���� �浹ó�� ���� �ʵ���
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        //�θ��� isFull�� false��
        dropaableUI = previousParent.GetComponentInParent<DroppableUI>();
        if (dropaableUI != null)
            dropaableUI.isFull = false;
        else
            Debug.Log("ũ����! ����� GO ! ");

    }

    //���� ������Ʈ�� �巡�� ���� �� �� ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    // ���� ������Ʈ�� �巡�׸� �߷��� �� 1ȸ ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�׸� �����ϸ� �θ� canvas�� �����Ǳ� ������
        // �巡�׸� ������ �� �θ� cavnas�̸� ������ ������ �ƴ� ������ ����
        // ����� �ߴٴ� ���̱� ������ �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
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
        //Debug.Log("�θ� : " + slotManager);

    }

}
