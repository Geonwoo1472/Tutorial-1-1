using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// �÷��̾ �ʿ� ��ġ�� �������� ȹ���� �� �ֵ��� �մϴ�.
/// �κ��丮�� �������� ����, ��������Ʈ ȣ���մϴ�.
/// 
/// #���� ������Ʈ#
/// Player
/// 
/// #Method#
/// -public bool AddItem(Item)
/// �������� ȹ���� �� 
/// ���Կ� ������� �ְų�, �ִ�뷮�� �ʰ����� �ʴ´ٸ�
/// �������� ȹ���մϴ�.
/// 
/// -public bool RemoveItem()
/// �Ϲ������� �������� �Ҹ�Ǵ� ��� ȣ���մϴ�.
/// ������ ���� �ϰ� �����մϴ�
/// 
/// -private void OnTriggerEnter2D(Collider2D)
/// �÷��̾ �����۰� �ε����� ���
/// �������� ������ ���� �κ��丮�� �߰��Ѵ�.
/// �κ��丮�� ������ �ִ� ��� ��������Ʈ ����� ���ȴ�.
/// 
/// [����]
/// OnSlotCountChange(int) ����, ������ ĭ�� �����ϴ� ����� �������Ƿ� ���ʿ�.
/// </summary>
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
    // �ε��� Tag�� FieldItem�� ���
    // �ش� ������Ʈ�� ������ �ִ� FildItem ������Ʈ�� ��������
    // FildItem ������Ʈ�� �ִ� ������ Item�� ��������
    // UI�� ������ ����ϴٸ� List�� Item ������ ��´�.
    // �׸��� �� ����Ǿ��ٸ� onChangeItem �Լ��� ȣ���ϰ� [��������Ʈ]
    // �ش� ������Ʈ�� �ı��Ѵ�.

    // ���� 2�� ������ ��찡 ����.
    // //2ȸ �浹 �� bool ������ ó��..
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FildItem filditems = collision.GetComponent<FildItem>();

            if (filditems.isAvailable)
                return;
            else
                filditems.isAvailable = true;

            if (AddItem(filditems.GetItem()))
            {
                collision.gameObject.SetActive(false);
                CommunalSound.instance.SoundPlaying(SoundType.itemPickUp);
            }
        }
    }




}
