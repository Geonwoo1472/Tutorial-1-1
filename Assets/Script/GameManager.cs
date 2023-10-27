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

    public string playerStartingPt;                     // �÷��̾� ����� ��ġ�Դϴ�. MapPotal.cs���� ����ϰ� �ֽ��ϴ�.
    [Header("���� �� �ۼ��ؾ� �Ƿε� ����� �ݿ�")]
    public string currentMapName;                       // ���� ���� �̸�
    public int sceneIndex;                              // ���� Scene�� Index��ȣ 
    public InvenActive invenPanel;                      // InventoryPanel ������Ʈ
    public GameOverUIActive OverUI;                     // GameOverUI ������Ʈ�Դϴ�.
    public GameObject escPanel;                         // ESC UI ������Ʈ�Դϴ�.

    [HideInInspector]
    private bool moveStatus;                             // Just stop moving
    [HideInInspector]
    public bool isGameover;                             // Key All stop
    public bool IsGameOver
    {
        get { return isGameover; }
        set { isGameover = value; }
    }

    private bool activeEscPanel;                        // ESC Panel SetActive���� ����
    private bool activeInventory;                       // InventoryPanel SetActive���� ����
    private Inventory inven;                            // �κ��丮 ��ũ��Ʈ ���� ����
    [HideInInspector]
    public bool interationGetKey;                     // ��ȣ�ۿ�Ű ��� ���� �Ǵ� 
    [HideInInspector]
    public player_Raycast playerRay;                    //playerRaycast  
    private DalogManager dalogManager;

    public delegate void OnInterationMap();
    public OnInterationMap onInterationMap;             // MapŰ ��������Ʈ
   
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
        // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // I Ű�� ������ �� �κ��丮
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.INVENTORY]))
            {
                Debug.Log("Inventory ��� !!");
                invenPanel.InvenOnActive();
                //OnInvenActive();
                CommunalSound.instance.SoundPlaying(SoundType.inventoryOpen);
            }
            // M Ű�� ������ �� ��
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.MAP]))
            {
                Debug.Log("Map ��� !!");
                if (onInterationMap != null)
                    onInterationMap.Invoke();
            }
            // SPACEBAR ������ �� ��ȣ�ۿ�
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
            /*SPACEBAR , KeyDown. ����� ����ġ�� ����ϰ� �ִ�.
             �ǳ� ON���� ��� ����ġ�� �۵��� �ʿ� �����Ƿ� return */
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

                Debug.Log("���� Stack �� : " + ESCManager.instance.UIStack.Count);
            }

        }
    }

    public override void OnActive()
    {
        OnEscActive();
    }

    /* ��ư�� �ٽ� ���� ��쳪 [X] �� ������� ȣ���մϴ�
     ���ÿ� �ִ� �߻�ȭ Ŭ������ ���� �ۼ��� �޼ҵ带 ȣ���մϴ�. */
    public void escKeyDown()
    {
        UIActive obj = ESCManager.instance.UIStack.Pop();
        obj.OnActive();
    }

    //�κ��丮
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

    // ���ӿ����� ��� UI Ȱ��ȭ
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
