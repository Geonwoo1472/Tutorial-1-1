using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /*
     �ε��� ��ü�� �÷��̾��� ���
    �÷��̾� �κ��丮 ���� ����������� �ִ°�쿡
    ���踦 �ڵ����� �Ҹ��ϰ�, ���̺� ������ �Ѿ�ϴ�.
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
                        if (keyItem.keyValue == exitKey)
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
        }
    }
}
