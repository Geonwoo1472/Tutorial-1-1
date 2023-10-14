using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public int savePointCount;
    public DalogManager dalogManager;
    public GameObject saveYNPanel;
    public RayCastTalk rayCastTalk;
    public Transform playerTransform;
    public Sprite[] imagePanelSource;
    public GameObject itemIvenPanel;

    public Image[] imagePanel;
    public Text[] datePanel;
    public Text[] stagePanel;
    public Text[] storyPanel;

    public GameObject loadPenel;
    public GameObject itemPrefab;
    public Item[] itemArray;

    public FadeEffect fadeEffect;


    private List<int> itemNumberList;
    private int stageNumber;
    private int slotNumber;

    

    private bool saveMode;
    public bool SaveMode
    {
        set { saveMode = value; }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        dalogManager.saveDalog += LastDalogAfterCall;

        itemNumberList = new List<int>();
    }

    private void Start()
    {
        LoadPopupUIRendering();
    }

    /*저장하시겠습니까? 문구 이후 델리게이트로 호출, 매개변수로는 Talk의 ID를 받음 */
    private void LastDalogAfterCall(int val)
    {
        int ret = val - 2000;
        if (ret >= 0 && ret < savePointCount)
        {
            stageNumber = ret;
            openLoadCanvas();
        }
    }

    public void openLoadCanvas()
    {
        SaveMode = true;
        loadPenel.SetActive(true);
    }

    /*Load Popup의 Button 누르면 호출
     매개변수로
    3000-1
    3001-2
    3002-3 */
    public void SaveScreenButtonClick(int number)
    {
        Debug.Log("SaveScreenButtonClick() method Call, 매개변수 : " + number);

        if (saveMode)
            SaveInformationWindow(number);
        else
            Load(number);
    }

    /*저장하시겠습니까? 와 [예/아니오] 판넬 출력 */
    private void SaveInformationWindow(int number)
    {
        slotNumber = number - 3000;
        dalogManager.Action(number);
        saveYNPanel.SetActive(true);
        rayCastTalk.IsButtonDown = false;
    }

    /* [예] 버튼을 눌렀을 경우 Save*/
    public void Save()
    {
        FileSave();

        rayCastTalk.IsButtonDown = true;
        saveYNPanel.SetActive(false);
        loadPenel.SetActive(false);
        SaveMode = false;
        dalogManager.Action(0);             //예 아니오 누른 뒤에 텍스트 판넬이 남아 움직임이 불가능하여 추가

    }

    /* [아니오] 버튼을 눌렀을 경우 */
    public void DoNotSave()
    {
        rayCastTalk.IsButtonDown = true;
        saveYNPanel.SetActive(false);
        loadPenel.SetActive(false);
        SaveMode = false;
        dalogManager.Action(0);             //예 아니오 누른 뒤에 텍스트 판넬이 남아 움직임이 불가능하여 추가
    }

    private void FileSave()
    {
        int imageNumber = stageNumber;
        string stageLineText = SetStageLine();
        string storyLineText = SetStoryLine();
        ItemNumberListInit();

        DataFile jTest1 = new DataFile(imageNumber,stageLineText, storyLineText, playerTransform.position.x, playerTransform.position.y, itemNumberList);
        string jsonData = JsonConvert.SerializeObject(jTest1);
        LoadPopupUpdate(slotNumber, jTest1.imageNumber,jTest1.timeLine, jTest1.stageLine, jTest1.storyLine);

        FileStream stream = new FileStream(Application.dataPath + "/SaveFile/" + slotNumber + "SlotFile.json", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        stream.Write(data, 0, data.Length);
        stream.Close();
    }

    private void Load(int number)
    {
        slotNumber = number - 3000;

        try
        {
            FileStream stream = new FileStream(Application.dataPath + "/SaveFile/" + slotNumber + "SlotFile.json", FileMode.Open);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();
            string dataDeserialize = Encoding.UTF8.GetString(data);
            var dataFile = JsonConvert.DeserializeObject<DataFile>(dataDeserialize);

            if (dataFile.timeLine == "저장 기록이 없습니다 .. ")
            {
                Debug.Log("파일은 존재하나 저장 기록 없음.");
                return;
            }

            SceneManager.LoadScene(SceneConstIndex.CHAPTERSAVE);
            DataSetting(dataFile.playerPos.x, dataFile.playerPos.y, dataFile.itemNumberList);

            // 용도는 켜져있는 판넬창 전부 끄는용
            loadPenel.SetActive(false);
            // 용도는 켜져있는 판넬창 전부 끄는용
            /*if(GameManager.instance.EscKeyDown ==true)
                GameManager.instance.OnEscActive();*/


            fadeEffect.OnFade(FadeState.FadeIn);
        }
        catch
        {
            Debug.Log(slotNumber + "슬롯 칸 저장 파일 없음.");
        }
    }

    /* LoadPopup 캔버스 업데이트 */
    private void LoadPopupUpdate(int _slotNumber, int _imageNumber, string _date, string _stage, string _story)
    {
        imagePanel[_slotNumber].sprite = imagePanelSource[_imageNumber];
        datePanel[_slotNumber].text = _date;
        stagePanel[_slotNumber].text = _stage;
        storyPanel[_slotNumber].text = _story;
    }

    /*
     LoadPopUp Canvas Text Update용
     */
    private void LoadPopupUIRendering()
    {
        for(int i=0; i<3; ++i)
        {
            SlotFile(i);
        }
    }
    private void SlotFile(int slotNumber)
    {
        try
        {
            FileStream stream = new FileStream(Application.dataPath + "/SaveFile/" + slotNumber + "SlotFile.json", FileMode.Open);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();

            string dataDeserialize = Encoding.UTF8.GetString(data);
            var dataFile = JsonConvert.DeserializeObject<DataFile>(dataDeserialize);
            LoadPopupUpdate(slotNumber, dataFile.imageNumber, dataFile.timeLine, dataFile.stageLine, dataFile.storyLine);
        }
        catch
        {
            LoadPopupUpdate(slotNumber, 0, "저장 기록이 없습니다 .. ", "스테이지 저장 기록이 없습니다 ..", "진행 중 목표 없음 ..");
        }
        
    }



    /*관리자용 데이터 삭제 버튼 , 맨 처음으로 초기화함. */
    public void DeleteSaveFile(int slotNumber)
    {
        DataFile defaultData = new DataFile();
        defaultData.timeLine = "저장 기록이 없습니다 .. ";
        defaultData.stageLine = "스테이지 저장 기록이 없습니다 ..";
        defaultData.storyLine = "진행 중 목표 없음 ..";

        string jsonData = JsonConvert.SerializeObject(defaultData);
        LoadPopupUpdate(slotNumber, defaultData.imageNumber, defaultData.timeLine, defaultData.stageLine, defaultData.storyLine);

        FileStream stream = new FileStream(Application.dataPath + "/SaveFile/" + slotNumber + "SlotFile.json", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        stream.Write(data, 0, data.Length);
        stream.Close();
    }

    private void DataSetting(float _x, float _y, List<int> _itemList)
    {
        playerTransform.position = new Vector2(_x, _y);
        ItemClear();
        ItemSetting(_itemList);

    }
    private void ItemClear()
    {
        for (int i = 0; i < itemIvenPanel.transform.childCount; ++i)
        {
            if(itemIvenPanel.transform.GetChild(i).childCount >0)
            {
                GameObject deleteObject = itemIvenPanel.transform.GetChild(i).GetChild(0).gameObject;
                Destroy(deleteObject);
            }
        }
    }
    private void ItemSetting(List<int> _itemList)
    {
        for(int i=0; i< _itemList.Count; ++i)
        {
            GameObject fish = Instantiate(itemPrefab);
            fish.transform.SetParent(itemIvenPanel.transform.GetChild(i), false);
            DraggableUI ui = fish.GetComponent<DraggableUI>();
            ui.SetItemInfo(itemArray[_itemList[i]]);
        }
    }
    private string SetStageLine()
    {
        string str = string.Format("{0}.5 스테이지 ", stageNumber + 1);

        switch (stageNumber)
        {
            case 0:
                str += ",숲으로 가는 길";
                break;
            case 1:
                str += ", 동굴로 가는 길";
                break;
            case 2:
                str += ", 유적으로 가는 길";
                break;
            case 3:
                str += ", 해변가로 가는 길";
                break;
        }

        return str;
    }
    private string SetStoryLine()
    {
        string str = string.Format("{0} 스테이지를 향해 !!", stageNumber + 2);

        return str;
    }
    private void ItemNumberListInit()
    {
        itemNumberList.Clear();
        for (int i = 0; i < itemIvenPanel.transform.childCount; ++i)
        {
            if (itemIvenPanel.transform.GetChild(i).childCount > 0)
            {
                DraggableUI ui = itemIvenPanel.transform.GetChild(i).GetChild(0).GetComponent<DraggableUI>();
                int itemNum = ui.item.itemNumber;
                itemNumberList.Add(itemNum);
            }
        }
    }
}
