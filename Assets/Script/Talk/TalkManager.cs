using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // 대화의 문자열을 저장하는 자료구조입니다.
    Dictionary<int, Sprite> portraitData;                   // 대화와 NPC의 이미지와 맵핑되어있는 자료구조입니다.

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
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(100, new string[] { "박스 1", "근데 2번째 대사는 안되지" });
        talkData.Add(101, new string[] { "이런곳에 표지판이 있다니, 일단 확인해보자." });


        {
            /*
            portraitData.Add(200 + 0, portaitArr[0]);
            portraitData.Add(200 + 1, portaitArr[1]);
            portraitData.Add(200 + 2, portaitArr[2]);
            portraitData.Add(200 + 3, portaitArr[3]);
            portraitData.Add(1000 + 0, portaitArr[4]);
            portraitData.Add(1000 + 1, portaitArr[5]);
            portraitData.Add(1000 + 2, portaitArr[6]);
            portraitData.Add(1000 + 3, portaitArr[7]);
            */
        }
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


}
