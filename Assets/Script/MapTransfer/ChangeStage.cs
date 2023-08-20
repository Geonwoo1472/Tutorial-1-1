using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStage : MonoBehaviour
{
    [Header("���Ա� KeyValue ����")]
    public short mapChangeKeyValue;                                         // ����� ���εǾ���ϴ� ���� ��

    private Inventory inven;                                                // ���� �ִ� ���� �������� ����
    private Transform itemIvenpanel;                                        // ������ ������ �����ϴ� �ǳ�

    private void Start()
    {
        inven = Inventory.instance;
        itemIvenpanel = GameObject.Find("ItemInvenPanel").GetComponent<RectTransform>();
    }

    /*
     �ε��� ��ü�� �÷��̾��� ���
    �÷��̾� �κ��丮 ���� ����������� �ִ°�쿡
    ���踦 �ڵ����� �Ҹ��ϰ�, ���� ������ �Ѿ�ϴ�.
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < inven.SlotCnt; ++i)
            {
                GameObject invenSlot = itemIvenpanel.GetChild(i).gameObject;
                if (invenSlot.transform.childCount > 0)
                {
                    invenSlot = invenSlot.transform.GetChild(0).gameObject;
                    DraggableUI draggableUI = invenSlot.GetComponent<DraggableUI>();
                    Item item = draggableUI.item;

                    if (item.itemType == ItemType.key)
                    {
                        KeyItem keyItem = (KeyItem)item;
                        if (keyItem.keyValue == mapChangeKeyValue)
                        {
                            keyItem.Use();
                            SceneManager.LoadScene(SceneConstIndex.CHAPTERSAVE);
                        }
                    }
                }
            }
        }
    }
}
