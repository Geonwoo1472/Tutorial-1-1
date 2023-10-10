using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // 대화의 문자열을 저장하는 자료구조입니다.
    Dictionary<int, Sprite> portraitData; // 대화와 NPC의 이미지와 맵핑되어있는 자료구조입니다.
                                          //  Dictionary<int, Sound> soundData;

    public Sprite[] portaitArr;                             // 사용될 이미지를 저장하고있는 배열입니다.

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        OutTroDialog();
        OutTroImage();
    }

    public string GetTalk(int ID, int talkIndex)
    {
        if (talkIndex == talkData[ID].Length)
        {
            return null;
        }
        else
            return talkData[ID][talkIndex];
    }

    public Sprite GetPortraite(int ID, int portaitIndex)
    {
        return portraitData[ID + portaitIndex];
    }


    private void OutTroDialog()
    {
        talkData.Add(0, new string[] { "가까스로 해변에 도착한 존은 신호탄을 터뜨렸다.:0:11",
            "구조 신호를 발견한 배가 뱃머리를 돌리는 것이 보였다.:0:10",
            "희미하던 뱃소리가 가까워지고 부산스러운 사람들 소리가 주변을 둘러쌌다.:1:10",
            "선원의 도움으로 배에 올라탄 존은 그제야 마음 놓고 멀어지는 섬을 바라볼 수 있었다.:1:10"});
    }


    private void OutTroImage()
    {
        portraitData.Add(0, portaitArr[0]);
         portraitData.Add(0 + 1, portaitArr[1]);
    }
}
