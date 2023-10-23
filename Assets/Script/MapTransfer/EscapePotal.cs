using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePotal : MonoBehaviour
{
    public int exitKey;

    private Transform itemIvenpanel;
    private Inventory inven;

    private void Start()
    {
        inven = Inventory.instance;
        itemIvenpanel = GameObject.Find("Canvas").transform.Find("InventoryPanel").Find("ItemInvenPanel").GetComponent<RectTransform>();
    }

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

                            
                            CommunalSound.instance.SoundPlaying(SoundType.sceneSound);
                            SceneManager.LoadScene(SceneConstIndex.ENDING);
                            return;
                        }
                    }
                }
            }

            SceneManager.LoadScene(SceneConstIndex.BADENDING);

        }
    }
}
