using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStage : MonoBehaviour
{
    public short exitKey;                                                   // 열쇠와 맵핑되어야하는 고유 값
    public string transferMapname;                                          // 이동할 맵의 이름

    private Inventory inven;                                                // 슬롯 최대 개수 가져오기 위함
    private Transform itemIvenpanel;                                        // 아이템 슬롯을 관리하는 판넬
    private GameManager gameManager;                                        // currentMapName 변경을 위함.

    private void Start()
    {
        inven = Inventory.instance;
        itemIvenpanel = GameObject.Find("Canvas").transform.Find("InventoryPanel").Find("ItemInvenPanel").GetComponent<RectTransform>();
        gameManager = GameManager.instance;
    }

    /*
     부딪힌 객체가 플레이어의 경우
    플레이어 인벤토리 내에 열쇠아이템이 있는경우에
    열쇠를 자동으로 소모하고, 세이브 씬으로 넘어갑니다.
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
