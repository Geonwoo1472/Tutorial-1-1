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

    //플레이어 재시작 위치
    public string playerStartingPt;

    //현재 맵 이름
    //playerStatus와 종속되어 있음.. 초기화 안하면 피로도 부여 오류가 생김 ㅜㅜ 고쳐야함
    [Header("시작 맵 작성해야 피로도 배고픔 반영이 됨")]
    public string currentMapName;
    public int SceneIndex;

    //인벤토리
    public GameObject inventoryPanel;
    bool activeInventory;

    // 움직임 제한
    [HideInInspector]
    public bool isGameover; // Key All stop
    public bool allowsMove; // Just stop moving

    //게임오버 UI
    public GameObject OverUI;

    //페이드
    //FadeEffect fadeEffect;

    //ESC UI
    public GameObject escPanel;
    bool activeEscPanel;


    //인벤  & 퀵슬롯 1,2,3,4,5
    Inventory inven;
    private GameObject quick1;
    private GameObject quick2;
    private GameObject quick3;
    private GameObject quick4;
    private GameObject quick5;

    //상호작용키
    public bool interactionKeyDown;

    //playerRaycast
    public player_Raycast playerRay;

    void Start()
    {
        activeInventory = false;
        isGameover = false;
        activeEscPanel = false;
        allowsMove = false;
        SceneIndex = 1;
        quick1 = GameObject.Find("QuickSlot");
        if (quick1 == null)
            Debug.Log("quick crash .. ");

        quick2 = GameObject.Find("QuickSlot (1)");
        if (quick2 == null)
            Debug.Log("quick(1) crash .. ");

        quick3 = GameObject.Find("QuickSlot (2)");
        if (quick3 == null)
            Debug.Log("quick(2) crash .. ");

        quick4 = GameObject.Find("QuickSlot (3)");
        if (quick4 == null)
            Debug.Log("quick(3) crash .. ");

        quick5 = GameObject.Find("QuickSlot (4)");
        if (quick5 == null)
            Debug.Log("quick(4) crash .. ");

        inven = Inventory.instance;

        interactionKeyDown = false;

        playerRay = GameObject.Find("Player").GetComponent<player_Raycast>();
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
            // SPACEBAR 눌렀을 때 상호작용 , getkeyDown 아닌 getkey로
            if (Input.GetKey(KeySetting.keys[KeyAction.INTERACTION]))
            {
                Debug.Log("Interaction 기능 !!");

                interactionKeyDown = true;

                if (playerRay.scanObject != null)
                {
                    IDestroyable iDestroyable = playerRay.scanObject.GetComponent<IDestroyable>();
                    if (iDestroyable != null)
                        iDestroyable.interactionDestroy();
                }
            }
            else
            {
                interactionKeyDown = false;
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
        modifyMove();
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

    public void modifyMove()
    {
        allowsMove = !allowsMove;
        // 캐릭터 정지시 애니메이션 발동해주어야 함 / Rigidy 잠구어야 함
        Player_Action.instance.modifyRigidbody(allowsMove);
    }

    /*public bool interactionKeyDown()
    {
        // SPACEBAR 눌렀을 때 상호작용 , getkeyDown 아닌 getkey로
        if (Input.GetKey(KeySetting.keys[KeyAction.INTERACTION]))
        {
            Debug.Log("GameManager에서 Interaction 눌림!!");
            return true;
        }

        return false;
    }*/
}
