using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    // ���� ĭ�� ����Ǿ��ٸ� �븮�ڷ� �ٸ� �ֵ鿡�� �˷��ֱ�
    public delegate void OnSlotCountChange(int val);     // �븮�� ����
    public OnSlotCountChange onSlotCountChange;          // �븮�� �ν��Ͻ�ȭ


    // �������� �߰��Ǹ� ����UI���� �߰��Ǵ� �븮��
    public delegate void OnChangeItem(Item _item);
    public OnChangeItem onChangeItem;

    // ������ ��� / ȹ�� �� ���� �븮��
    public delegate void OnItemTextUI(int count, int capacity);
    public OnItemTextUI onChangeItemTextUI;


    // �������� ���Ǹ� ����UI���� �߰��Ǵ� �븮��


    //������ �ִ밳�� / ���簳�� 
    public int capacity;
    public int count;

    // ������ ����
    private int slotCnt;

    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        // �ʱ� ���� ����
        SlotCnt = 20;
        // �ʱ� �ִ� ġ
        capacity = 10;
        count = 0;
        onChangeItemTextUI.Invoke(count, capacity);
    }

    // ������ �߰�
    public bool AddItem(Item _item)
    {
        if (count < SlotCnt && count < capacity)
        {
            count++;
            onChangeItemTextUI.Invoke(count, capacity);
            //������ �߰��� ��������Ʈ�� UI�ڽ����� �����ϴ� �Լ� ȣ��
            if (onChangeItem != null)
                onChangeItem.Invoke(_item);

            return true;
        }

        return false;
    }

    // ������ ��� DroppableUI���� ȣ����.
    // ���⼭ ��� ������ ȿ�� ��ũ��Ʈ�� �ۼ��� ���� ���ʿ��� �Ұ����� ��
    // 
    // �׸��� ..  ���� capacity���������� ��� ȣ���Ұ��� 
    public bool RemoveItem()
    {
        if (count <= 0)
            return false;

        count--;
        onChangeItemTextUI.Invoke(count, capacity);


        return false;
    }

    

    // �÷��̾ �����۰� �浹�� ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� Tag�� FieldItem�� ���
        // �ش� ������Ʈ�� ������ �ִ� FildItem ������Ʈ�� ��������
        // FildItem ������Ʈ�� �ִ� ������ Item�� ��������
        // UI�� ������ ����ϴٸ� List�� Item ������ ��´�.
        // �׸��� �� ����Ǿ��ٸ� onChangeItem �Լ��� ȣ���ϰ� [��������Ʈ]
        // �ش� ������Ʈ�� �ı��Ѵ�.

        // ���� 2�� ������ ��찡 ����.
        // //2ȸ �浹 �� bool ������ ó��..


        if (collision.CompareTag("FieldItem"))
        {
            //Debug.Log("Inventory.cs �ε� ���� ��� �浹�߾� !!" + collision.name);
            //Debug.Log("�� �̸��� : " + gameObject.name + " �̾� !");
            FildItem filditems = collision.GetComponent<FildItem>();

            if (filditems.isAvailable)
                return;
            else
                filditems.isAvailable = true;

            if (AddItem(filditems.GetItem()))
            {
                //filditems.DestoryItem();
                collision.gameObject.SetActive(false);
            }
        }
    }




}
