using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* ���� */
/*
    ���Կ� �ִ� ��ũ��Ʈ��
    ���� ���콺 Ŭ�� ��
    ���Կ��� ���콺 �����Ͱ� ���� ���
    ���Կ��� ���콺 �����Ͱ� ���� ���
    ���� ���� ���ο��� ����� �Ǿ��� �� ȣ��˴ϴ�.

    
 */
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
        Debug.Log("DroppableUI.cs �� OnPointerClick() �޼ҵ� ���� �� .. ");
        /*  �̰������� Ŭ�� �� ���� ���Կ� �ִ� �ڽ� ������Ʈ�� �������� 
            �ش� ������Ʈ�� FildItem��ũ��Ʈ���� Item������ �����;��մϴ�.
            �����Դٸ�  Iventory�� RemoveItem �� ȣ���Ͽ� ������ ������Ű��
            Item�� Use�� ����մϴ�.
            ���� �ڽ��� �����ϴ� ������ ��Ĩ�ϴ�.    

         */

        GameObject gameObject = transform.GetChild(0).gameObject;
        DraggableUI draggableUI = gameObject.GetComponent<DraggableUI>();
        Item item = draggableUI.item;
        if (item == null)
        {
            Debug.Log("item �Ҵ� �ȵ� !");
            return;
        }
        inven.RemoveItem();
        item.Use();

        Destroy(gameObject);
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

}
