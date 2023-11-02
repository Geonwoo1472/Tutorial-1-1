using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// ���� ������ �˻� �� ���� ������ �Ѿ�� ����Դϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ���������� �Ѿ�� �Ա�
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// �÷��̾����� Ȯ�� ��
/// �κ��丮�� ���� ������ �Ǵ��ϱ� ���� ��ȸ�մϴ�.
/// �ùٸ� Key�� �ִٸ� ���� ������ �̵��մϴ�.
/// 
/// </summary>
public class ChangeStage : MonoBehaviour
{
    public short exitKey;                                                   // ����� ���εǾ���ϴ� ���� ��
    public string transferMapname;                                          // �̵��� ���� �̸�

    private Inventory inven;                                                // ���� �ִ� ���� �������� ����
    private Transform itemIvenpanel;                                        // ������ ������ �����ϴ� �ǳ�
    private GameManager gameManager;                                        // currentMapName ������ ����.

    private void Start()
    {
        inven = Inventory.instance;
        itemIvenpanel = GameObject.Find("Canvas").transform.Find("InventoryPanel").Find("ItemInvenPanel").GetComponent<RectTransform>();
        gameManager = GameManager.instance;
    }


    private GameObject invenSlot;
    private DraggableUI draggableUI;
    private Item item;

    public bool CheckKeyYN()
    {
        for (int i = 0; i < inven.SlotCnt; ++i)
        {
            invenSlot = itemIvenpanel.GetChild(i).gameObject;
            if (invenSlot.transform.childCount > 0)
            {
                invenSlot = invenSlot.transform.GetChild(0).gameObject;
                draggableUI = invenSlot.GetComponent<DraggableUI>();
                item = draggableUI.item;

                if (item.itemType == ItemType.key)
                {
                    KeyItem keyItem = (KeyItem)item;
                    if (keyItem.keyValue == exitKey)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /*
     �ε��� ��ü�� �÷��̾��� ���
    �÷��̾� �κ��丮 ���� ����������� �ִ°�쿡
    ���踦 �ڵ����� �Ҹ��ϰ�, ���̺� ������ �Ѿ�ϴ�.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(CheckKeyYN())
            {
                inven.RemoveItem();
                item.Use();
                Destroy(invenSlot);

                gameManager.currentMapName = transferMapname;
                CommunalSound.instance.SoundPlaying(SoundType.sceneSound);
                SceneManager.LoadScene(SceneConstIndex.CHAPTERSAVE);
            }
        }
    }
}
