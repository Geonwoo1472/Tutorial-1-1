using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// #�뵵#
/// UI���� �巡�װ� �����ϵ��� �մϴ�.
/// 
/// 
/// #���� ������Ʈ#
/// Prefab�� Item ���ӿ�����Ʈ
/// 
/// #Method#
/// -public void SetItemInfo(Item)
/// �ʿ� ��ġ�� �����ۿ�����Ʈ�� Item��ũ��Ʈ�� �޾ƿ�
/// UI�� ��ϵ� �����ۿ� �����͸� �����մϴ�.
/// 
/// -public void OnBeginDrag(PointerEventData)
/// �巡�װ� ���۵Ǵ� ���� ȣ��޽��ϴ�.
/// �ǵ����� ���� ���� ����Ǵ� ���� �����ϱ����� ���� �� ��ġ���� �����մϴ�.
/// �ֻ�ܿ� �������Ǿ�� �ϱ� ������ ������ �����մϴ�.
/// ����� �����ߴ� ����ĭ�� ��ũ��Ʈ�� ���� isFull�� ���� �����մϴ�.
/// 
/// -public void OnDrag(PointerEventData)
/// �巡�� �� �� ������ ȣ���մϴ�.
/// �������� ������Ʈ�մϴ�.
/// 
/// -public void OnEndDrag(PointerEventData)
/// �巡�׸� �����ϴ� ��� ȣ���մϴ�.
/// ���Կ� �巡������ ���ϴ� ��� ������ �ڸ���
/// �������� ������ ���� �����Դϴ�.
/// </summary>
public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;                   // //������ ���� ����

    private Transform canvas;           // UI�� �ҼӵǾ� �ִ� �ֻ���� Canvas Transform
    private Transform previousParent;   // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
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
        //���� �θ� droppableUI�� �ִٸ� ������ FULL��
        if (dropaableUI != null)
            dropaableUI.isFull = true;
    }

    //�̹��� ���� ���� [������ ���� �߰� �� ���� �۾��ؾ� ��]
    public void SetItemInfo(Item _item)
    {
        if (_item != null)
            item = _item;

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
            Debug.Log("DraggableUI.cs , 68Line Crash");

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
}
