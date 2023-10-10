using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTroTalkManager : MonoBehaviour
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

    /*
     말풍선의 대화를 저장하고있는 메소드입니다.
    Awkae에서 호출하고 있습니다.
    인덱스와 매칭하는 문자열을 작성하면 되고
    : 뒤에 오는 숫자는 이미지 배열에 저장되어 있는 인덱스입니다.
     */
    void GenerateData()
    {
        OutTroDialog();
        OutTroImage();
    }
    /*
     TalkData에서 인덱스로 구별하여 원하는 문자를 가져옵니다.
    매개변수로는 해당하는 인덱스와, 문자열의 순서를 받아
    저장되어 있는 문자열을 리턴합니다.
     */
    public string GetTalk(int ID, int talkIndex)
    {
        if (talkIndex == talkData[ID].Length)
        {
            return null;
        }
        else
            return talkData[ID][talkIndex];
    }
    /*
     portaitData에서 구별할 수 있는 인덱스로
    상황에 맞는 Sprite를 리턴합니다.
     */
    public Sprite GetPortraite(int ID, int portaitIndex)
    {
        return portraitData[ID + portaitIndex];
    }

 

    private void OutTroDialog()
    {
        talkData.Add(0, new string[] { "가까스로 해변에 도착한 존은 배를 향해 구조 신호를 보냈다.:0:0",
            "“이봐, 여기 사람이 있다고!!”:0:0",
            "“제발 여기 좀 봐달라고!!”:0:0",
            "쉬도록 외친 목에서 쇳소리가 났지만 아무도 그 소리를 못들은 듯 했다.:0:0",
            "그러나 존은 멈추지 않고 계속 배를 향해 손을 흔들었다.:0:0",
            "이를 아는지 모르는지 다신 없을 기회는 비명소리와 함께 멀어져만 갔다.:1:0"});
    }


    private void OutTroImage()
    {
        portraitData.Add(0, portaitArr[0]); 
        portraitData.Add(0 + 1, portaitArr[1]);

    }
}
