using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// #�뵵#
/// ������ ���Կ� ���� ����� ���ǵǾ� �ֽ��ϴ�.
/// ������ Ŭ��, ���콺 �����Ͱ� ������ ���, ������ ���
/// �������� ���Կ� ������ ����� ����� ó���մϴ�.
/// 
/// #���� ������Ʈ#
/// InventorySlot [Prefab]
/// 
/// #Method#
/// -public void OnPointerClick(PointerEventData)
/// ���콺�� Ŭ���� �� ȣ��˴ϴ�.
/// �������� ����ϴ� ������ �ۼ��Ǿ� �ֽ��ϴ�.
/// �������� ����� �� �ִ� Type�̶�� Use()�� ȣ���Ͽ� ���ǰ� �Ҹ��մϴ�.
/// 
/// -public void OnPointerEnter(PointerEventData)
/// ���콺 �����Ͱ� ���� ��� ȣ��˴ϴ�.
/// ���콺�� ���Դٴ� ���� �˸������� �̹����� ���� �����մϴ�.
/// 
/// - public void OnPointerExit(PointerEventData)
/// ���콺�� ���� �� ȣ��˴ϴ�.
/// �̹����� ������ ������ �����մϴ�.
/// 
/// -public void OnDrop(PointerEventData)
/// �������� ����Ǵ� ��� �������� ������ �ڽ����� ����ϴ�.
/// 
///
/// </summary>
public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler,
    IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private RectTransform rect;

    public bool isFull;

    //�κ��丮
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

    //���콺 Ŭ���� ��
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemUsing();
    }

    // ���콺 ������ ���� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }

    // ���콺 ������ ���� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    // ���� ������ ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
    public void OnDrop(PointerEventData eventData)
    {
        // ���Կ����� button������Ʈ interactable�� �����ְ� && ����ִٸ�
        if (eventData.pointerEnter.GetComponent<Button>().interactable && !isFull)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            isFull = true;
        }
    }


    /*  
            �̰������� Ŭ�� �� ���� ���Կ� �ִ� �ڽ� ������Ʈ�� �������� 
            �ش� ������Ʈ�� FildItem��ũ��Ʈ���� Item������ �����;��մϴ�.
            �����Դٸ�  Iventory�� RemoveItem �� ȣ���Ͽ� ������ ������Ű��
            Item�� Use�� ����մϴ�.
            ���� �ڽ��� �����ϴ� ������ ��Ĩ�ϴ�.    
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
            Debug.Log("item �Ҵ� �ȵ� !");
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
                    /*�۵��� ��� �����Ƿ� ���� */
                }
                break;
            default:
                Debug.Log(" DroppableUI.cs , switch �� default");
                break;
        }

        
    }

}
