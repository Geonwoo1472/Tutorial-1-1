using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ����ü , ����Ʈ �������� �� ���� �� ����� �ϴ� */
public class StatusManager : MonoBehaviour
{
    #region Singleton
    public static StatusManager instance;

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

    // ���������� ������ �ִ� �ε��� ����
    public Dictionary<string, int> FatigueDict;
    public Dictionary<string, int> HungerDict;

    [Header("�Ƿε� �ִ� ��ġ ����")]
    public float[] FatigueMaxData;
    [Header("�Ƿε� ���� ��ġ ����")]
    public float[] FatigueData;

    private int FatigueIndex = 0;

    [Header("����� �ִ� ��ġ ����")]
    public float[] HungerMaxData;
    [Header("����� ���� ��ġ ����")]
    public float[] HungerData;


    private int HungerIndex = 0;

    void Start()
    {
        /* ������Ʈ���� �� ���� ���� ���� �� */
        //FatigueMaxData = new float[] {15,15,15,15,0,0,0,0,0,0,15,15,15,15,15,15,15,15,15,0};
        //FatigueData = new float[] { 15,15,15,15,0,0,0,0,0,0,15,15,15,15,15,15,15,15,15,0 };
        //HungerData = new float[] { 2, 2 };
        //HungerMaxData = new float[] { 2, 2 };

        FatigueDict = new Dictionary<string, int>();
        FatigueDict.Add("CameraPos1", 0); // 1-1
        FatigueDict.Add("CameraPos2", 1); // 1-2
        FatigueDict.Add("CameraPos3", 2); // 1-3
        FatigueDict.Add("CameraPos4", 3); // 1-4

        FatigueDict.Add("CameraPos2-1", 10); // 2-1
        FatigueDict.Add("CameraPos2-2", 11); // 2-2
        FatigueDict.Add("CameraPos2-3", 12); // 2-3
        FatigueDict.Add("CameraPos2-4", 13); // 2-4
        FatigueDict.Add("CameraPos2-5", 14); // 2-5
        FatigueDict.Add("CameraPos2-6", 15); // 2-6
        FatigueDict.Add("CameraPos2-7", 16); // 2-7
        FatigueDict.Add("CameraPos2-8", 17); // 2-8
        FatigueDict.Add("CameraPos2-9", 18); // 2-9

        FatigueDict.Add("CameraPos3-1", 20); // 3-1
        FatigueDict.Add("CameraPos3-2", 21); // 3-2
        FatigueDict.Add("CameraPos3-3", 22); // 3-3
        FatigueDict.Add("CameraPos3-4", 23); // 3-4
        FatigueDict.Add("CameraPos3-5", 24); // 3-5
        FatigueDict.Add("CameraPos3-6", 25); // 3-6
        FatigueDict.Add("CameraPos3-7", 26); // 3-7
        FatigueDict.Add("CameraPos3-8", 27); // 3-8
        FatigueDict.Add("CameraPos3-9", 28); // 3-9


        HungerDict = new Dictionary<string, int>();
        HungerDict.Add("CameraPos1", 0); // 1 stage
        HungerDict.Add("CameraPos2", 0); // 1
        HungerDict.Add("CameraPos3", 0); // 1
        HungerDict.Add("CameraPos4", 0); // 1

        HungerDict.Add("CameraPos2-1", 1); // 2 stage
        HungerDict.Add("CameraPos2-2", 1); // 2
        HungerDict.Add("CameraPos2-3", 1); // 2
        HungerDict.Add("CameraPos2-4", 1); // 2
        HungerDict.Add("CameraPos2-5", 1); // 2
        HungerDict.Add("CameraPos2-6", 1); // 2
        HungerDict.Add("CameraPos2-7", 1); // 2
        HungerDict.Add("CameraPos2-8", 1); // 2
        HungerDict.Add("CameraPos2-9", 1); // 2

        HungerDict.Add("CameraPos3-1", 2); // 3 stage
        HungerDict.Add("CameraPos3-2", 2); // 3
        HungerDict.Add("CameraPos3-3", 2); // 3
        HungerDict.Add("CameraPos3-4", 2); // 3
        HungerDict.Add("CameraPos3-5", 2); // 3
        HungerDict.Add("CameraPos3-6", 2); // 3
        HungerDict.Add("CameraPos3-7", 2); // 3
        HungerDict.Add("CameraPos3-8", 2); // 3
        HungerDict.Add("CameraPos3-9", 2); // 3

        // ���� �ʿ� ���� �Ƿε� �ε��� ��������
        if (FatigueDict.ContainsKey(GameManager.instance.currentMapName))
            FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        else
            FatigueIndex = 0;

        // ���� �ʿ� ���� ����� �ε��� ��������
        if (HungerDict.ContainsKey(GameManager.instance.currentMapName))
            HungerIndex = HungerDict[GameManager.instance.currentMapName];
        else
            FatigueIndex = 0;

        // ���� �� ������ ���� ����� �Ƿε� ù �ʱ�ȭ 
        if (!PlayerStatus.instance.InitStatus(HungerMaxData[HungerIndex],
            FatigueMaxData[FatigueIndex], HungerData[HungerIndex], FatigueData[FatigueIndex]))
        {
            Debug.Log("�ʱ�ȭ ����");
        }

    }

    //�� �ٲ� �� ���� �Ƿε� ����
    public void FatigueSetting()
    { 
        if (!FatigueDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log("Fatigue Key ����.");
            return;
        }

        FatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitFatigueMax(FatigueMaxData[FatigueIndex]);
        PlayerStatus.instance.InitFatigue(FatigueData[FatigueIndex]);
    }
    
    public void Substitution()
    {
        //FatigueData = FatigueMaxData; // �̷��� �ּҰ� �����ȴ�.
        //HungerData = HungerMaxData; 

        for (int i=0; i<HungerMaxData.Length; ++i)
        {
            HungerData[i] = HungerMaxData[i];
        }

        for(int i=0; i<FatigueMaxData.Length; ++i)
        {
            FatigueData[i] = FatigueMaxData[i];
        }
    }

    public void FDChange(float value)
    {
        FatigueData[FatigueIndex] -= value;
    }

}
