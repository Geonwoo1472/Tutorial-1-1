[Unity2D 캡스톤 프로젝트 0da7cec4ae724466a0cea80563ae70a9.md](https://github.com/Geonwoo1472/Tutorial-1-1/files/13196108/Unity2D.0da7cec4ae724466a0cea80563ae70a9.md)# Tutorial-1-1
GameMap

hello!
[Uploading Un# Unity2D 캡스톤 프로젝트

| 번호 | 스크립트 명 | 기능 | 사용 유무 | Folder |
| --- | --- | --- | --- | --- |
| 0 | AudioMixerManager.cs | Slider컴포넌트에서 0~1사이의 실수 값을 받아 데시벨 -80~0의 값으로 조정합니다. | o | AudioMixer |
| 1 | moveBox.cs | 플레이어가 박스를 미는 경우, 박스가 이동되기 위한 로직이 구현되어 있습니다. | o | Box |
| 2 | CameraController.cs | 카메라가 플레이어를 따라다니게 합니다. 지정한 외곽위치까지만 따라다닙니다. | o | Camera |
| 3 | CameraMove.cs | 카메라가 맵 정보를 얻어와 그 기반으로 위치로 새롭게 셋팅합니다. | x | Camera |
| 4 | CameraSizeSet.cs | 씬마다 카메라 사이즈 변경에 따라 카메라 사이즈를 새롭게 설정합니다. | o | Camera |
| 5 | MapCoordinate.cs | 맵 이동 시 카메라가 제한범위에 예외처리 되어 따라오지 못하는 경우를 방지합니다. | o | Camera |
| 6 | DEFINECONST.cs | 인덱스를 문자열로 관리하기 위해 선언된 클래스입니다. | o | DefineConst |
| 7 | [Camera/Canvas/CommunalSound/Dalog/EventSystem/GameManager/KeyManager/Mixer/Player/TalkManager] DontDestroy | 씬이 넘어가도 객체가 파괴되지 않는 기능이 정의되어 있습니다. | o | DontDestory |
| 8 | ControlOptionActive.cs | 옵션 팝업을 키거나 끕니다. | o | Esc |
| 9 | ESCManager.cs | ESC로 닫을 수 있는 UI를 관리하는 컴포넌트입니다. | o | Esc |
| 10 | InvenActive.cs | 인벤토리를 키거나 끕니다. | o | Esc |
| 11 | LoadPopupActive.cs | 로딩화면을 키거나 끕니다. | o | Esc |
| 12 | SoundOptionActive.cs | 사운드옵션 판넬을 활성/비활성합니다. | o | Esc |
| 13 | TitleMove.cs | 메인 타이틀로의 씬 이동. | o | Esc[수정 필요] |
| 14 | UIActive.cs | UI를 ESC로 닫기 위한 Stack에서 관리되는 데이터 단위, 추상클래스 | o | Esc |
| 15 | FadeEffect.cs | 부착된 Image컴포넌트의 이미지 알파 값을 서서히 변경시킵니다. | o | Fade |
| 16 | DraggableUI.cs | 인벤토리의 아이템을 마우스로 드래그 할 수 있는 기능이 정의되어 있습니다.  | o | Inventory_SlotScript |
| 17 | DroppableUI.cs | 아이템 슬롯에 대한 기능이 정의되어 있습니다. 슬롯을 클릭, 마우스 포인터가 들어오는 경우, 나가는 경우 아이템이 슬롯에 들어오는 경우의 기능을 처리합니다. | o | Inventory_SlotScript |
| 18 | FildItem.cs | 필드에 배치된 게임 오브젝트에 아이템의 정보를 저장시킵니다. | o | Inventory_SlotScript |
| 19 | Inventory.cs | 플레이어가 맵에 배치된 아이템을 획득할 수 있도록 합니다.
인벤토리에 아이템이 들어가고, 델리게이트 호출합니다. | o | Inventory_SlotScript |
| 20 | InventoryUI.cs | 플레이어가 아이템을 획득할 시 인벤토리에 반영되기 위한 기능들이 있습니다. | o | Inventory_SlotScript |
| 21 | Slot.cs | 삭제 | x | Inventory_SlotScript |
| 22 | SlotManager.cs | 삭제 | x | Inventory_SlotScript |
| 23 | MapItem.cs | 단축키로 맵의 지도가 UI에 노출될 수 있도록 하는 MapInteration클래스를 조작합니다. |  | Item |
| 24 | KeyItem.cs | Key의 Value값을 정의합니다. |  | Item |
| 25 | Item.cs | 아이템이 가져야할 기본 정보들이 정의되어 있습니다. |  | Item |
| 26 | HungerItem.cs | 플레이어의 배고픔을 회복하는 수치를 설정하고, 회복되는 기능이 구현되어 있습니다. | x | Item |
| 27 | FruitItem.cs | 플레이어의 피로도를 회복시키거나 감소시키는 기능이 구현되어 있습니다. |  | Item |
| 28 | FatigueItem.cs | 플레이어의 피로도를 회복시키는는 수치 값을 설정하고, 사용시 반영되는 기능이 구현되어 있습니다. |  | Item |
| 29 | EyesightItem.cs | 플레이어의 시야를 어느정도 밝힐 치 값을 설정하고, PlayerLight2D에 정의되어 있는 코루틴을 실행하는 기능입니다. |  | Item |
| 30 | PlayerLight2DController.cs | Light2D의 밝기범위의 를 관리합니다. |  | Light |
| 31 | SetLightComponent.cs | Light의 SetActive유무를 결정합니다. |  | Light |
| 32 | KeyManager.cs | 입력키를 원하는 키로 변경할 수 있는 기능입니다. |  | MainTitleScript |
| 33 | MainExit.cs | 유니티 프로세스를 종료하는 기능입니다. |  | MainTitleScript |
| 34 | NewGame.cs | 게임을 진행합니다. |  | MainTitleScript |
| 35 | OptionPopupManager.cs | 키 변경창의 UI를 Rendering합니다.  |  | MainTitleScript |
| 36 | PlayerActionBlock.cs | 플레이어의 움직임을 막습니다. |  | MainTitleScript |
| 37 | BrightnessCheck.cs | 플레이어의 시야 넓이를 defalut값으로 변경합니다. |  | MapTransfer |
| 38 | BrittleCollapse.cs | 붕괴 기능이후 지정오브젝트를 비활성 시킵니다. |  | MapTransfer |
| 39 | CameraSizeChange.cs | 카메라의 크기를 재설정합니다. |  | MapTransfer |
| 40 | ChangeStage.cs | 열쇠 보유를 검사 후 다음 씬으로 넘어가는 기능입니다. |  | MapTransfer |
| 41 | Collapse.cs | 1회용이며 지정한 곳으로 텔레포트합니다. 한 쌍으로 이루어져 작동합니다. |  | MapTransfer |
| 42 | MapDictionary.cs | 맵이름과 일치하는 게임오브젝트 명의 자료형이 선언되어 있습니다. |  | MapTransfer |
| 43 | MapPotal.cs | 맵 이동 기능이 구현되어 있습니다. |  | MapTransfer |
| 44 | NextStage.cs | 플레이어의 스텟을 셋팅합니다. |  | MapTransfer |
| 45 | SavePoint.cs | 씬 변경 후 플레이어 위치를 재설정합니다. |  | MapTransfer |
| 46 | Teleport.cs |  |  | MapTransfer |
| 47 | TeleportParent.cs |  |  | MapTransfer |
| 48 | Player_Action.cs | 플레이어의 움직임을 담당하는 로직이 작성되어 있습니다. |  | Player |
| 49 | player_Raycast.cs | RayCast로 앞에있는 Layer : Object인 오브젝트를 판별합니다. |  | Player |
| 50 | PlayerStatus.cs | 플레이어 스텟 클래스입니다. |  | Player |
| 51 | DataFile.cs | 파일을 저장하기 위한 직렬화데이터 클래스입니다. |  | Save |
| 52 | SaveManager.cs | 파일을 통해 저장/불러오기 기능이 구현되어 있습니다. |  | Save |
| 53 | SaveManagerDontDestroy.cs | SaveManager가 씬 이동시에도 파괴되지 않도록 합니다. |  | Save |
| 54 | CheckLandProperties.cs | 발판을 새롭게 밟은 경우 플레이어 발소리를 출력하는 AudioSource의 Clip을 상황에 맞는 소리로 변경합니다. |  | Sound |
| 55 | CommunalSound.cs | 게임 모든챕터에서 사용하는 사운드를 관리하고 출력합니다. |  | Sound |
| 56 | SetLandValue.cs | 해당 발판의 종류를 정의합니다. |  | Sound |
| 57 | SoundManager.cs | 현재 맵에서 사용되는 사운드를 관리하고 출력합니다. |  | Sound |
| 58 | TalkManager.cs | 오브젝트 ID와 말풍선 문자열이 맵핑되어 저장되어 있습니다. |  | Talk |
| 59 | RayCastTalk.cs | Tag : TalkObject의 사물을 스캔해 상호작용 키가 눌리면 말풍선 기능을 실행합니다. |  | Talk |
| 60 | PlayerCompulsionMove.cs | 말풍선이 끝난 후 플레이어를 지정된 방향으로 강제 이동시킵니다. |  | Talk |
| 61 | ObjectTalkData.cs | 말풍선 오브젝트가 가져야할 기본 정보를 가지고 있습니다. |  | Talk |
| 62 | DisposableObject.cs | 플레이어가 상호작용하여 실행되는 말풍선 기능을 1회성으로 변경합니다. |  | Talk |
| 63 | DisableTarget.cs | 소멸할때 같이 소멸할 게임오브젝트를 정합니다. |  | Talk |
| 64 | DalogManager.cs | 말풍선 관련 UI기능을 담당하며 저장된 문자열 정보를 받아 말풍선 Text를 변경합니다. |  | Talk |
| 65 | AutoTalk.cs | 충돌체와 부딪힌 경우 상호작용 없이 말풍선이 뜰 수 있도록 합니다. |  | Talk |
| 66 | TypeEffect.cs | 말풍선의 Text UI가 한번에 셋팅되는 것이 아닌 점진적으로 셋팅될 수 있도록 합니다. |  | Talk |
| 67 | OperationSwitch.cs | 플레이어가 상호작용을 해야하는 스위치의 기능입니다. |  | Tile |
| 68 | OperationSwitchPotal.cs | 오브젝트가 등록한 스위치로 인해 활성/비활성되는 기능입니다. |  | Tile |
| 69 | PushSwitchTile.cs | 누르는 스위치 기능입니다. |  | Tile |
| 70 | StunTile.cs | 해당 오브젝트와 충돌한 경우 플레이어를 내부 변수의 값의 시간만큼 정지시킵니다. |  | Tile |
| 71 | SwampTile.cs | 플레이어의 속도를 늦추고 피로도를 소모시킵니다. |  | Tile |
| 72 | SwitchPotal.cs | 누르는 스위치의 작동여부에 따라 오브젝트를 활성/비활성 합니다. |  | Tile |
| 73 | TreeTile.cs | 플레이어가 상호작용하면 나무 오브젝트를 비활성 시키고 관련된 기능들이 실행됩니다. |  | Tile |
| 74 | HidenMapCollider.cs | 히든맵에 들어가는 경우 Light를 활성화 시키고 TimeText의 UI가 활성화 되도록합니다. |  | TimeText |
| 75 | TimeText.cs | 타이머 기능이 구현되어 있습니다. 시간이 0이 되면 GameOver됩니다. |  | TimeText |
| 76 | HF_UI.cs | 플레이어의 스텟 상태를 UI에 반영합니다. |  | UI |
| 77 | MapInteration.cs | Map Imgae UI에 알맞은 지도 이미지 데이터를 셋팅하고 플레이어가 조작키로 해당 이미지UI를 활성/비활성할 수 있게 합니다. |  | UI |
| 78 | OverUIExit.cs | 프로세스를 종료합니다. |  | UI |
| 79 | OverUIMainMenu.cs | 게임오버됐을 시 플레이어가 메인화면으로 돌아갈 수 있도록하고 진행했던 정보들을 초기화합니다. |  | UI |
| 80 | AxeItem.cs | Player와 Trigger이벤트 발동 시 오브젝트를 비활성합니다. |  | Item |
| 81 | DebugManager.cs | 카메라가 캐릭터가 존재하는 맵을 촬영하도록하고, 플레이어가 오브젝트 상호작용 시 스테미너가 소모되지 않도록 합니다. |  | Player |
| 82 | ItemEffect.cs | 아이템이 공중에 떠보일 수 있도록 합니다. |  | Item |
| 83 | GameManager.cs | 플레이어의 입력을 받아 처리합니다. |  |  |
| 84 | IDestroyable.cs | 제거가 가능한지의 여부와 관련 메소드들이 정의되어 있습니다. |  |  |
| 85 | LoadCaller.cs | 로드창을 끄고 키는 스크립트를 작동합니다. |  | UI |
| 86 | OptionCaller.cs | 옵션창을 끄고 키는 스크립트를 작동합니다. |  | UI |
| 87 | StatusManager.cs | 맵마다 기준이 되는 배고픔, 피로도 데이터들을 저장하고 있습니다. |  |  |
| 88 | TitleMove.cs | 메인타이틀의 씬으로 이동합니다. |  |  |
| 89 | Utils.cs | 계산식을 관리하는 정적 클래스입니다. |  |  |
| 90 |  |  |  |  |

-보완할 부분-

1. Stack에서 바로 Pop해서 사용하는 것이 아닌

값을 가져온 후, 로직이 올바르게 처리된 후 Pop하는 기능으로 만들었다면

인벤토리의 InvenOnActive() 라는 메소드를 따로 만들지 않아도 됐었을 것 같다.

1. UIActive.cs 의 추상 메소드 명

OnActive로 되어 있음. 메소드 명만 보았을 때는 단순히 오브젝트를 활성화하는 용도로 생각됨.

범용적인 단어로 변경할 필요가 있다.

1. 클래스를 매개변수로 받는 경우

```jsx
public void SetItemInfo(Item _item)
    {
        if (_item != null)
            item = _item;
        /*item.itemType = _item.itemType;
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemHeal = _item.itemHeal;

        */
        image.sprite = item.itemImage;
    }
```

유니티에서 클래스는 CallByReference이다.

주석 처리 된 부분이 오류가 나는 이유는

item이 동적 할당되지 않은 상태이다.

C/C++ 에서는 포인터로 선언하지 않으면 메모리 공간이 할당되지만

C#에서는 그렇지 않다는 것.

1. script executor order

![Untitled](Unity2D%20%E1%84%8F%E1%85%A2%E1%86%B8%E1%84%89%E1%85%B3%E1%84%90%E1%85%A9%E1%86%AB%20%E1%84%91%E1%85%B3%E1%84%85%E1%85%A9%E1%84%8C%E1%85%A6%E1%86%A8%E1%84%90%E1%85%B3%200da7cec4ae724466a0cea80563ae70a9/Untitled.png)

스크립트 호출 순서 , 음수부터 양수까지의 순서대로 스크립트가 실행된다.

같은 Awake()라도 그 호출에 순서가 정할 수 있다.

1. Item Script의 애매함

```csharp
public class Item : ScriptableObject
{
    public ItemType itemType;           // 아이템 Type
    public string itemName;             // 아이템 Name
    public Sprite itemImage;            // 아이템 Image
    public int itemNumber;               // 아이템 고유번호

    protected bool retValue = false;    // 오버라이딩이 잘 되었는지 확인하는 변수

    public virtual bool Use()
    {
        return retValue;
    }
}
```

추상화를 사용하는 편이 더 좋았을까?

가상함수를 사용하는 편이 더 좋았을까?

현 지식으로 답을 내놓을 수 없음..

가상함수를 보다 잘 이해했다면 답을 내놓을 수 있을 것 같음.

1. static 클래스의 관리

```jsx
public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}
```

어떤 .cs 파일에 선언해야 올바른 것일까?

![Untitled](Unity2D%20%E1%84%8F%E1%85%A2%E1%86%B8%E1%84%89%E1%85%B3%E1%84%90%E1%85%A9%E1%86%AB%20%E1%84%91%E1%85%B3%E1%84%85%E1%85%A9%E1%84%8C%E1%85%A6%E1%86%A8%E1%84%90%E1%85%B3%200da7cec4ae724466a0cea80563ae70a9/Untitled%201.png)

1. 단일 기능만 사용하고 싶은 경우

```jsx
public class PlayerActionBlock : MonoBehaviour
{
    public bool isValue;
    
    void Start()
    {
        GameManager.instance.MoveStatus = isValue;
    }
}
```

스크립트를 하나 씩 만드는 것은 비효율적인 것 같은데

좋은 방법이 없는가?

1. 열쇠 검사를 위한 비효율 로직

```jsx
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
```

보유한 열쇠 자료구조를 만들어 관리하는 것이 유리한가?

다른 아이템은 검사할 필요 없으므로 유리할 듯함.

9. MapPotal.cs 의 일부 코드

CMove는 현재 사용하고 있지 않으므로 코드 수정이 필요하다.

1. SavePoint.cs 에서 메소드

시작지점이 많아지는 경우 많이 호출하게 된다.

이 부분은 불필요한 호출임 어떻게 수정해볼 수 있을까?

1. PlayerStatus.cs

```jsx
public bool OnDamageFatigue(float damage)
public bool OnHealHunger(float heal)
```

힐과 감소하는 걸 인자의 값으로 구분할 수 있는데 메소드를 2개만든 것.

메소드를 사용할땐 편했는데 이게 음.. 어떻게 짜는게 옳은건지를 모르겠다.

```jsx
private MyStates states;
```

클래스안에서 정의된 구조체를 사용하고 있다.

어차피 이 클래스만 사용하는데 굳이 분리를 시켜놓은 것 같기도 하다.

1. SaveManager.cs

매개변수로 3000을 받는다는 것이 조금 아쉽다.

판넬을 Rendering하는 부분은 분리하지 않은 것이 아쉽다.

아이템이 몇개 있는지 몰라서 20번 순회하는 것이 아쉽다.

1. CheckLandProperties.cs 에서의 Collider

Trigger마다 동작을 다르게 하여 처리해야하므로

자식 오브젝트를 생성하여 OnTrigger 함수만 따로 작성.

문제는 중복해서 OnTrigger 메소드가 호출된다는 것.

만약 새로운 물체와 충돌하면

DebugManager의 OnTrigger도 들어오고

FootholdCheck의 OnTrigger도 들어온다.

if(other .. tag.compare(”..”); 가 달라서 바로 return해서 튕겨나가지만

호출하는 행위 자체가 손해(?)로 이어지는 것이 아닌가?

한군데에서 호출하고 switch로 분기문을 타는 것이 바람직하지 않은가?

1. SwampTile.cs

코루틴으로 업데이트문을 지속적으로 호출할 필요가 없었다.

Invoke를 사용해서 플레이어의 speed를 감소시켰다가

다시 원복시켰으면 더 간결했을 것 같다.

피로도 소모시키는 값을 1로 고정하지말고 내부 변수를 추가해 확장성을 고려하고

슬로우 되는 속도, 슬로우 지속시간 등 내부변수로 초기화 하는 편이 좋았을 것 같다.

1. TreeTile.cs

```csharp
public class TreeTile : IDestroyable
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    public override void InteractionDestroy()
    {
        if (!destroyTree)
            return;

        PlayerStatus.instance.OnDamageFatigue(HF_Constance.TREETILE);
        soundManager.SoundPlaying(SoundType.breakTree);
        gameObject.SetActive(false);
        
    }
}
```

‘상호작용기능 호출 시 오브젝트를 비활성하는 기능’을 중점으로 개발했어야했는데

‘나무를 부셔지게 하는 기능’을 중점으로 개발한 것이 아쉬움.

음.. 가상함수를 사용해서 괜찮은가?

아무튼 큰 나무라면 피로도2 달게 피로도를 소모시키는 값 변수를 따로 할당해 사용하는 것이

나쁘지 않아보임. , static const 변수를 사용하는 것보다.

1.ity2D 캡스톤 프로젝트 0da7cec4ae724466a0cea80563ae70a9.md…]()
