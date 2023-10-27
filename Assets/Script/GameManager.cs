using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : UIActive
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
        activeInventory = false;
        isGameover = false;
        activeEscPanel = false;
        moveStatus = false;
        sceneIndex = 1;
    }
    #endregion

    public string playerStartingPt;                     // 플레이어 재시작 위치입니다. MapPotal.cs에서 사용하고 있습니다.
    [Header("시작 맵 작성해야 피로도 배고픔 반영")]
    public string currentMapName;                       // 현재 맵의 이름
    public int sceneIndex;                              // 현재 Scene의 Index번호 
    public InvenActive invenPanel;                      // InventoryPanel 오브젝트
    public GameOverUIActive OverUI;                     // GameOverUI 오브젝트입니다.
    public GameObject escPanel;                         // ESC UI 오브젝트입니다.

    [HideInInspector]
    private bool moveStatus;                             // Just stop moving
    [HideInInspector]
    public bool isGameover;                             // Key All stop
    public bool IsGameOver
    {
        get { return isGameover; }
        set { isGameover = value; }
    }

    private bool activeEscPanel;                        // ESC Panel SetActive유무 변수
    private bool activeInventory;                       // InventoryPanel SetActive유무 변수
    private Inventory inven;                            // 인벤토리 스크립트 저장 변수
    [HideInInspector]
    public bool interationGetKey;                     // 상호작용키 사용 유무 판단 
    [HideInInspector]
    public player_Raycast playerRay;                    //playerRaycast  
    private DalogManager dalogManager;

    public delegate void OnInterationMap();
    public OnInterationMap onInterationMap;             // Map키 델리게이트
   
    public bool ActiveEscPanel
    {
        get { return activeEscPanel; }
        set { activeEscPanel = value; }
    }

    public bool MoveStatus
    {
        get => moveStatus;
        set => moveStatus = value;
    }

    public int SceneIndex
    {
        get => sceneIndex;
        set => sceneIndex = value;
    }

    void Start()
    {
        inven = Inventory.instance;
        interationGetKey = false;
        playerRay = GameObject.Find("Player").GetComponent<player_Raycast>();
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();

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
                invenPanel.InvenOnActive();
                //OnInvenActive();
                CommunalSound.instance.SoundPlaying(SoundType.inventoryOpen);
            }
            // M 키를 눌렀을 때 맵
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map 기능 !!");
                if (onInterationMap != null)
                    onInterationMap.Invoke();
            }
            // SPACEBAR 눌렀을 때 상호작용
            if (Input.GetKey(KeySetting.keys[KeyAction.INTERACTION]))
            {
                interationGetKey = true;
                if (playerRay.scanObject != null)
                {
                    switch (playerRay.pastTag)
                    {
                        case "Tree":
                            {
                                IDestroyable iDestroyable = playerRay.scanObject.GetComponent<IDestroyable>();
                                if (iDestroyable != null)
                                    iDestroyable.InteractionDestroy();
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            else
            {
                interationGetKey = false;
            }
            /*SPACEBAR , KeyDown. 현재는 스위치만 사용하고 있다.
             판넬 ON중인 경우 스위치는 작동할 필요 없으므로 return */
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
            {
                if (playerRay.scanObject != null && !dalogManager.IsAction)
                {
                    switch (playerRay.pastTag)
                    {
                        case "Switch":
                            {
                                playerRay.scanObject.GetComponent<OperationSwitch>().IsAction();
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.ESC]))
            {
                if (ESCManager.instance.UIStack.Count == 0)
                {
                    OnActive();
                    ESCManager.instance.UIStack.Push(this);
                }
                else
                {
                    escKeyDown();
                }

                Debug.Log("현재 Stack 수 : " + ESCManager.instance.UIStack.Count);
            }

        }
    }

    public override void OnActive()
    {
        OnEscActive();
    }

    /* 버튼을 다시 누른 경우나 [X] 를 누른경우 호출합니다
     스택에 있는 추상화 클래스를 꺼내 작성된 메소드를 호출합니다. */
    public void escKeyDown()
    {
        UIActive obj = ESCManager.instance.UIStack.Pop();
        obj.OnActive();
    }

    //인벤토리
    public void OnInvenActive()
    {
        activeInventory = !activeInventory;
        //inventoryPanel.SetActive(activeInventory);
    }

    public void OnEscActive()
    {
        activeEscPanel = !activeEscPanel;
        ModifyMoveChange();
        escPanel.SetActive(activeEscPanel);
    }

    // 게임오버인 경우 UI 활성화
    public void StartGame()
    {
        isGameover = false;
        OverUI.OnActive();
    }

    public void EndGame()
    {
        isGameover = true;
        OverUI.OnActive();
    }

    public void ModifyMoveChange()
    {
        MoveStatus = !MoveStatus;
        Player_Action.instance.ModifyRigidbody(MoveStatus);
    }

    public void setMove(bool _setMove)
    {
        MoveStatus = _setMove;
        Player_Action.instance.ModifyRigidbody(MoveStatus);
    }

    private void NullChecking()
    {
        if (playerRay == null)
            Debug.Log("playerRay crash , GameManager.cs ");
    }
}
