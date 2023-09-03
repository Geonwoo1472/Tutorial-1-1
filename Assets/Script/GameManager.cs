using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

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

    public string playerStartingPt;                     // �÷��̾� ����� ��ġ�Դϴ�. MapPotal.cs���� ����ϰ� �ֽ��ϴ�.
    [Header("���� �� �ۼ��ؾ� �Ƿε� ����� �ݿ�")]
    public string currentMapName;                       // ���� ���� �̸�
    public int SceneIndex;                              // ���� Scene�� Index��ȣ 
    public GameObject inventoryPanel;                   // InventoryPanel ������Ʈ
    public GameObject OverUI;                           // GameOverUI ������Ʈ�Դϴ�.
    public GameObject escPanel;                         // ESC UI ������Ʈ�Դϴ�.

    [HideInInspector]
    public bool moveStatus;                             // Just stop moving
    [HideInInspector]
    public bool isGameover;                             // Key All stop

    private bool activeEscPanel;                        // ESC Panel SetActive���� ����
    private bool activeInventory;                       // InventoryPanel SetActive���� ����

    
    private Inventory inven;                            // �κ��丮 ��ũ��Ʈ ���� ����
    private GameObject quick1;                          // ��1 ������Ʈ
    private GameObject quick2;                          // ��2 ������Ʈ
    private GameObject quick3;                          // ��3 ������Ʈ
    private GameObject quick4;                          // ��4 ������Ʈ
    private GameObject quick5;                          // ��5 ������Ʈ

    
    [HideInInspector]
    public bool interationGetKey;                     // ��ȣ�ۿ�Ű ��� ���� �Ǵ� 
    [HideInInspector]
    public player_Raycast playerRay;                    //playerRaycast  

    void Start()
    {
        activeInventory = false;
        isGameover = false;
        activeEscPanel = false;
        moveStatus = false;
        SceneIndex = 1;
        quick1 = GameObject.Find("QuickSlot");
        quick2 = GameObject.Find("QuickSlot (1)");
        quick3 = GameObject.Find("QuickSlot (2)");
        quick4 = GameObject.Find("QuickSlot (3)");
        quick5 = GameObject.Find("QuickSlot (4)");
        inven = Inventory.instance;
        interationGetKey = false;
        playerRay = GameObject.Find("Player").GetComponent<player_Raycast>();

        NullChecking();
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // I Ű�� ������ �� �κ��丮
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INVENTORY]))
            {
                Debug.Log("Inventory ��� !!");
                OnInvenActive();
            }
            // M Ű�� ������ �� ��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map ��� !!");
            }
            // SPACEBAR ������ �� ��ȣ�ۿ�
            if (Input.GetKey(KeySetting.keys[KeyAction.INTERACTION]))
            {
                Debug.Log("Interaction ��� !!");

                interationGetKey = true;

                if (playerRay.scanObject != null)
                {
                    IDestroyable iDestroyable = playerRay.scanObject.GetComponent<IDestroyable>();
                    if (iDestroyable != null)
                        iDestroyable.interactionDestroy();
                }
            }
            else
            {
                interationGetKey = false;
            }
            // ������ 1��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKONE]))
            {
                Debug.Log("Quick1 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick1.transform.childCount > 0))
                    return;

                GameObject gameobject = quick1.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 2��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTWO]))
            {
                Debug.Log("Quick2 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick2.transform.childCount > 0))
                    return;

                GameObject gameobject = quick2.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 3��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTHREE]))
            {
                Debug.Log("Quick3 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick3.transform.childCount > 0))
                    return;

                GameObject gameobject = quick3.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 4��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFOUR]))
            {
                Debug.Log("Quick4 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick4.transform.childCount > 0))
                    return;

                GameObject gameobject = quick4.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ������ 5��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFIVE]))
            {
                Debug.Log("Quick5 ��� !!");

                /* �ش� �� ���Կ� �ڽ��� �ִٸ� �� �ڽĿ�����Ʈ�� ������ Item.Use�� ���� ��Ű�� ���� ����*/
                if (!(quick5.transform.childCount > 0))
                    return;

                GameObject gameobject = quick5.transform.GetChild(0).gameObject;
                if (gameobject != null)
                {
                    DraggableUI ui = gameobject.GetComponent<DraggableUI>();
                    Item item = ui.item;
                    if (item != null)
                    {
                        inven.RemoveItem();
                        item.Use();

                        Destroy(gameobject);
                    }
                    else
                        Debug.Log("DraggableUI�� ItemŬ������ ����!");
                }
            }
            // ESCŰ 
            if(Input.GetKeyDown(KeySetting.keys[KeyAction.ESC]))
            {
                Debug.Log("ESC ��� !");
                OnEscActive();

            }
        }
        else
        {
            
        }



    }
    


    //�κ��丮
    public void OnInvenActive()
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

    //ESC
    public void OnEscActive()
    {
        activeEscPanel = !activeEscPanel;
        // ĳ���� ����
        ModifyMove();
        escPanel.SetActive(activeEscPanel);
    }

    // ���ӿ����� ��� UI Ȱ��ȭ
    public void StartGame()
    {
        isGameover = false;
        OverUI.SetActive(false);
    }

    public void EndGame()
    {
        isGameover = true;
        OverUI.SetActive(true);

    }

    public void ModifyMove()
    {
        moveStatus = !moveStatus;
        Player_Action.instance.ModifyRigidbody(moveStatus);
    }

    public void setMove(bool _setMove)
    {
        moveStatus = _setMove;
        Player_Action.instance.ModifyRigidbody(moveStatus);
    }


    private void NullChecking()
    {
        if (quick1 == null)
            Debug.Log("quick crash .. ");
        if (quick2 == null)
            Debug.Log("quick(1) crash , GameManager.cs  ");
        if (quick3 == null)
            Debug.Log("quick(2) crash , GameManager.cs  ");
        if (quick4 == null)
            Debug.Log("quick(3) crash , GameManager.cs  ");
        if (quick5 == null)
            Debug.Log("quick(4) crash , GameManager.cs  ");
        if (playerRay == null)
            Debug.Log("playerRay crash , GameManager.cs ");
    }
}
