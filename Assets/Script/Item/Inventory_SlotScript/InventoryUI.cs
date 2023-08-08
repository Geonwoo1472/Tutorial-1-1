using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // �ڽ��� slots ��ũ��Ʈ�� �迭�� ����
    public Slot[] slots; // [�������]
    // �ڽĵ��� �������� ����. �ν����Ϳ��� �Ҵ�
    public Transform slotHolder;

    //�κ��丮
    Inventory inven;

    //item ������
    public GameObject _prefeb;

    // �κ��丮 �ϴ� TextUI
    public TextMeshProUGUI tmpCountText;

    void Start()
    {
        //�ڽ� ������Ʈ �� Slot��ũ��Ʈ�� ���� �����´�.
        slots = slotHolder.GetComponentsInChildren<Slot>(); // [�������]


        inven = Inventory.instance;
        // �븮�� ��� , �κ��丮���� set�ϸ� SlotChange �޼ҵ� ȣ��
        inven.onSlotCountChange += SlotChange;

        // �븮�� ��� , ������ ȹ�� �� UI�� �ݿ��ǵ���
        inven.onChangeItem += RedrawSlotUI;

        // �븮�� ��� , �κ��丮 TextUI
        inven.onChangeItemTextUI += TmpTextChange;
    }

    private void SlotChange(int val)
    {
        // ��밡�� ���� ������ŭ ���� ON/OFF
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    // ���� �������� ������ �� �޼ҵ带 ȣ��!!
    // https://www.youtube.com/watch?v=TT7wJbpt2H4 �������� ���⺸�� ���� ����
    // -> �̰� ���ĸ� �븮�ڰ� �޼ҵ带 �����ϱ����� ȣ���ؼ� ����� ����
    public void AddSlot()
    {
        // �κ� 4ĭ�� ����
        inven.SlotCnt += 4;
    }

    // ������ �κ��丮 ȹ�� �ø��� �븮�ڿ� ���� ȣ��Ǵ� �Լ�
    void RedrawSlotUI(Item _item)
    {
        // Ȱ��ȭ�� ���� ������ŭ �ݺ�
        // ���� �ڽ��� ���ٸ� �װ��� ������Ʈ ����
        // �ش� ������Ʈ�� Item ������
        // ������ �������� item�� ���� �Ű����� ����
        for (int i = 0; i < inven.SlotCnt; ++i)
        {
            // ��ư�� Ȱ��ȭ ���ְ� && �ڽ��� ���ٸ�
            if (slotHolder.GetChild(i).GetComponent<Button>().interactable && slotHolder.GetChild(i).childCount < 1)
            {
                GameObject fish = Instantiate(_prefeb);
                fish.transform.SetParent(slotHolder.GetChild(i), false);
                fish.GetComponent<DraggableUI>().SetItemInfo(_item);

                break;
            }
        }


    }

    // �κ��丮 �ؽ�Ʈ ���� ����
    void TmpTextChange(int count, int capacity)
    {
        tmpCountText.text = count + "/" + capacity;
    }

    void Update()
    {
        // eŰ ������ ��� �׽�Ʈ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddSlot();
        }
    }
}
