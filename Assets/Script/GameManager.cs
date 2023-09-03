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

    public string playerStartingPt;                     // 플레이어 재시작 위치입니다. MapPotal.cs에서 사용하고 있습니다.
    [Header("시작 맵 작성해야 피로도 배고픔 반영")]
    public string currentMapName;                       // 현재 맵의 이름
    public int SceneIndex;                              // 현재 Scene의 Index번호 
    public GameObject inventoryPanel;                   // InventoryPanel 오브젝트
    public GameObject OverUI;                           // GameOverUI 오브젝트입니다.
    public GameObject escPanel;                         // ESC UI 오브젝트입니다.

    [HideInInspector]
    public bool moveStatus;                             // Just stop moving
    [HideInInspector]
    public bool isGameover;                             // Key All stop

    private bool activeEscPanel;                        // ESC Panel SetActive유무 변수
    private bool activeInventory;                       // InventoryPanel SetActive유무 변수

    
    private Inventory inven;                            // 인벤토리 스크립트 저장 변수
    private GameObject quick1;                          // 퀵1 오브젝트
    private GameObject quick2;                          // 퀵2 오브젝트
    private GameObject quick3;                          // 퀵3 오브젝트
    private GameObject quick4;                          // 퀵4 오브젝트
    private GameObject quick5;                          // 퀵5 오브젝트

    
    [HideInInspector]
    public bool interationGetKey;                     // 상호작용키 사용 유무 판단 
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
        // 게임오버가 아닌 동안
        if (!isGameover)
        {
            // I 키를 눌렀을 때 인벤토리
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INVENTORY]))
            {
                Debug.Log("Inventory 기능 !!");
                OnInvenActive();
            }
            // M 키를 눌렀을 때 맵
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map 기능 !!");
            }
            // SPACEBAR 눌렀을 때 상호작용
            if (Input.GetKey(KeySetting.keys[KeyAction.INTERACTION]))
            {
                Debug.Log("Interaction 기능 !!");

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
            // 아이템 1번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKONE]))
            {
                Debug.Log("Quick1 기능 !!");

                /* 해당 퀵 슬롯에 자식이 있다면 그 자식오브젝트를 가져와 Item.Use를 실행 시키는 것이 목적*/
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
                        Debug.Log("DraggableUI에 Item클래스가 없음!");
                }
            }
            // 아이템 2번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTWO]))
            {
                Debug.Log("Quick2 기능 !!");

                /* 해당 퀵 슬롯에 자식이 있다면 그 자식오브젝트를 가져와 Item.Use를 실행 시키는 것이 목적*/
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
                        Debug.Log("DraggableUI에 Item클래스가 없음!");
                }
            }
            // 아이템 3번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKTHREE]))
            {
                Debug.Log("Quick3 기능 !!");

                /* 해당 퀵 슬롯에 자식이 있다면 그 자식오브젝트를 가져와 Item.Use를 실행 시키는 것이 목적*/
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
                        Debug.Log("DraggableUI에 Item클래스가 없음!");
                }
            }
            // 아이템 4번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFOUR]))
            {
                Debug.Log("Quick4 기능 !!");

                /* 해당 퀵 슬롯에 자식이 있다면 그 자식오브젝트를 가져와 Item.Use를 실행 시키는 것이 목적*/
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
                        Debug.Log("DraggableUI에 Item클래스가 없음!");
                }
            }
            // 아이템 5번
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.QUICKFIVE]))
            {
                Debug.Log("Quick5 기능 !!");

                /* 해당 퀵 슬롯에 자식이 있다면 그 자식오브젝트를 가져와 Item.Use를 실행 시키는 것이 목적*/
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
                        Debug.Log("DraggableUI에 Item클래스가 없음!");
                }
            }
            // ESC키 
            if(Input.GetKeyDown(KeySetting.keys[KeyAction.ESC]))
            {
                Debug.Log("ESC 기능 !");
                OnEscActive();

            }
        }
        else
        {
            
        }



    }
    


    //인벤토리
    public void OnInvenActive()
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

    //ESC
    public void OnEscActive()
    {
        activeEscPanel = !activeEscPanel;
        // 캐릭터 정지
        ModifyMove();
        escPanel.SetActive(activeEscPanel);
    }

    // 게임오버인 경우 UI 활성화
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
