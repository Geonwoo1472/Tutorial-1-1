using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// #�뵵#
/// �÷��̾ �������� ȹ���� �� �κ��丮�� �ݿ��Ǳ� ���� ��ɵ��� �ֽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// Canvas
/// 
/// #Method#
/// -void RedrawSlotUI(Item)
/// �÷��̾ �������� ȹ���� �� �κ��丮�� �������մϴ�.
/// ������ �׸��� �͸��� �ƴ� ���ӿ�����Ʈ�� ���������ν� �������˴ϴ�.
/// 
/// -void TmpTextChange(int , int)
/// �κ��丮�� ������ ���� �� ���� Text �����
/// 
/// -void SliderWeightChange(int , int)
/// �κ��丮�� ������ ���� �� �����̴� Value �����
/// 
/// [����]
/// Slot[] ���� , Slot�� �̻������ ��ũ��Ʈ ����
/// SlotChange() ����, ���� ���� ��� ������ Button�� interactable���� �Ǵ��� ���ʿ�����.
/// inven.onSlotCountChange += SlotChange; ���� ����, SlotChange() ������ ���� ���ʿ�.
/// AddSlot() ����, ���� ���� ��� ������ ���ʿ�����.
/// 
/// </summary>
public class InventoryUI : MonoBehaviour
{
    // �ڽĵ��� �������� ����. �ν����Ϳ��� �Ҵ�
    public Transform slotHolder;

    //�κ��丮
    Inventory inven;

    //item ������
    public GameObject _prefeb;

    // �κ��丮 �ϴ� TextUI
    public TextMeshProUGUI tmpCountText;
    public Slider invenSlider;
    

    void Start()
    { 
        inven = Inventory.instance;

        // �븮�� ��� , ������ ȹ�� �� UI�� �ݿ��ǵ���
        inven.onChangeItem += RedrawSlotUI;

        // �븮�� ��� , �κ��丮 TextUI
        inven.onChangeItemTextUI += TmpTextChange;
        inven.onChangeItemTextUI += SliderWeightChange;
    }

    // �÷��̾ �ʵ� ������ ȹ�� �� ȣ��
    void RedrawSlotUI(Item _item)
    {
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
    void SliderWeightChange(int count, int capacity)
    {
        invenSlider.value = (float)count / (float)capacity;
    }

}
