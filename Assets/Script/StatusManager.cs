using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 구조체 , 리스트 설계방법이 더 좋을 것 같기는 하다 */
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

    // 스테이지가 가지고 있는 인덱스 정리
    public Dictionary<string, int> FatigueDict;
    public Dictionary<string, int> HungerDict;

    [Header("피로도 최대 수치 조절")]
    public float[] FatigueMaxData;
    [Header("피로도 현재 수치 조절")]
    public float[] FatigueData;
    [Header("배고픔 최대 수치 조절")]
    public float[] HungerMaxData;
    [Header("배고픔 현재 수치 조절")]
    public float[] HungerData;


    private int hungerIndex = 0;
    private int fatigueIndex = 0;
    public int HungerIndex
    {
        get { return hungerIndex; }
        set { hungerIndex = value; }
    }
    public int FatigueIndex
    {
        set { fatigueIndex = value; }
        get { return fatigueIndex; }
    }

    void Start()
    {
        FatigueDict = new Dictionary<string, int>();
        FatigueDictAdd();

        HungerDict = new Dictionary<string, int>();
        HungerDictAdd();

        // 현재 맵에 따른 피로도 인덱스 가져오기
        if (FatigueDict.ContainsKey(GameManager.instance.currentMapName))
            fatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        else
            fatigueIndex = 0;

        // 현재 맵에 따른 배고픔 인덱스 가져오기
        if (HungerDict.ContainsKey(GameManager.instance.currentMapName))
            hungerIndex = HungerDict[GameManager.instance.currentMapName];
        else
            fatigueIndex = 0;

        // 현재 맵 정보에 따라서 배고픔 피로도 첫 초기화 
        if (!PlayerStatus.instance.InitStatus(HungerMaxData[hungerIndex],
            FatigueMaxData[fatigueIndex], HungerData[hungerIndex], FatigueData[fatigueIndex]))
        {
            Debug.Log("초기화 실패");
        }
    }

    //맵 바뀔 때 마다 피로도 셋팅
    public void FatigueSet()
    { 
        if (!FatigueDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log("Fatigue Key 없음.");
            return;
        }

        fatigueIndex = FatigueDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitFatigueMax(FatigueMaxData[fatigueIndex]);
        PlayerStatus.instance.InitFatigue(FatigueData[fatigueIndex]);
    }
    
    //챕터 변경 마다 배고픔 셋팅
    public void HungerSet()
    {
        if(!HungerDict.ContainsKey(GameManager.instance.currentMapName))
        {
            Debug.Log(" StatusManager.cs , HungerSet() Null ");
            return;
        }
        hungerIndex = HungerDict[GameManager.instance.currentMapName];
        PlayerStatus.instance.InitHungerMax(HungerMaxData[hungerIndex]);
        PlayerStatus.instance.InitHunger(HungerData[hungerIndex]);
    }

    public void Substitution()
    { 
        for (int i=0; i<HungerMaxData.Length; ++i)
        {
            HungerData[i] = HungerMaxData[i];
        }

        for(int i=0; i<FatigueMaxData.Length; ++i)
        {
            FatigueData[i] = FatigueMaxData[i];
        }
    }

    public void FatigueDataReflection(float value,int type)
    {
        switch (type)
        {
            case OPERATIONTYPE.PLUS:
                FatigueData[fatigueIndex] += value;
                break;
            case OPERATIONTYPE.MINUS:
                FatigueData[fatigueIndex] -= value;
                break;
        }

        
    }

    public void HungerDataReflection(float value,int type)
    {
        switch (type)
        {
            case OPERATIONTYPE.PLUS:
                HungerData[hungerIndex] += value;
                break;
            case OPERATIONTYPE.MINUS:
                HungerData[hungerIndex] -= value;
                break;
        }
        
    }

    private void FatigueDictAdd()
    {
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

        FatigueDict.Add("CameraPos4-1", 30); // 4-1
        FatigueDict.Add("CameraPos4-2", 31); // 4-2
        FatigueDict.Add("CameraPos4-3", 32); // 4-3
        FatigueDict.Add("CameraPos4-4", 33); // 4-4
        FatigueDict.Add("CameraPos4-5", 34); // 4-5
        FatigueDict.Add("CameraPos4-6", 35); // 4-6
        FatigueDict.Add("CameraPos4-7", 36); // 4-7
        FatigueDict.Add("CameraPos4-8", 37); // 4-8
        FatigueDict.Add("CameraPos4-9", 38); // 4-9
        FatigueDict.Add("CameraPos4-h1", 39); // 4-1h
        FatigueDict.Add("CameraPos4-h2", 40); // 4-2h
        FatigueDict.Add("CameraPos4-h3", 41); // 4-3h
        FatigueDict.Add("CameraPos4-h4", 42); // 4-4h
        FatigueDict.Add("CameraPos4-h5", 43); // 4-5h

    }

    private void HungerDictAdd()
    {
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

        HungerDict.Add("CameraPos4-1", 3); // 4 stage
        HungerDict.Add("CameraPos4-2", 3); // 4
        HungerDict.Add("CameraPos4-3", 3); // 4
        HungerDict.Add("CameraPos4-4", 3); // 4
        HungerDict.Add("CameraPos4-5", 3); // 4
        HungerDict.Add("CameraPos4-6", 3); // 4
        HungerDict.Add("CameraPos4-7", 3); // 4
        HungerDict.Add("CameraPos4-8", 3); // 4
        HungerDict.Add("CameraPos4-9", 3); // 4

    }

}
