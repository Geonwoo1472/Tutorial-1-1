using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // 대화의 문자열을 저장하는 자료구조입니다.
    Dictionary<int, Sprite> portraitData; // 대화와 NPC의 이미지와 맵핑되어있는 자료구조입니다.
   //  Dictionary<int, Sound> soundData;

    public Sprite[] portaitArr;                             // 사용될 이미지를 저장하고있는 배열입니다.
    // public Sound[] soundClip;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        // soundData = new Dictionary<int, Sound>();
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
        /*Intro*/
        IntroDialog();
        IntroImage();
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

    /*public Sound GetSound(int ID, int soundIndex)
    {
        return portaitIndex(int ID + int soundIndex);
    } */

    private void IntroDialog()      
    {
        talkData.Add(0, new string[] { "멀지 않은 곳에서 파도 소리가 들려온다.:0:0",
            "입안 가득 퍼석한 모래알이 씹힌다.:0:0",
            "기침과 함께 토해냈지만 여전히 혓바닥과 입 천장은 까끌거린다.:0:0",
            "뻑뻑한 눈을 손으로 비벼 억지로 뜨니 그제야 주변 풍경이 눈에 들어온다.:0:0",
            "쨍쨍히 내리쬐며 시야를 방해하는 햇살, 모래사장과 사방이 바다로 둘러싸인, 이곳은 사람 한 명 살 것 같지 않은 무인도다.:0:0",
            "‘분명 마지막엔…’ :1:1",
            "존은 기억을 떠올렸다.:1:1",
            "폭풍우와 부서진 배, 그리고 항해를 함께 했던 선원들의 모습이 조각조각 떠오른다.:1:1",
            "“이봐! 아무도 없어?!”:1:1",
            "큰 소리로 외쳤지만 돌아오는 것은 부서진 배의 파편이 파도를 따라 밀려왔다 다시 떠내려가는 모습 뿐이었다.:1:1",
            "“설마 나만 살아 남은 건가?”:1:1",
            "작은 중얼거림이 파도 소리에 묻혀 흩어졌다.:1:1",
            "“여기가 어딘진 모르겠지만 우선 살아 나갈 방법을 찾아 봐야겠어.”:1:1",
            "방향키나 WASD 를 눌러 이동할 수 있습니다.:1:1"});


        /* Ending 대사 */
        talkData.Add(1, new string[] { "ABC.:0:0",
            "DEF.:0:0",
            "GHIJK.:0:0",
            "QWER.:0:0",
            "TYUI.:0:0"});

    }


    private void IntroImage()
    {
        portraitData.Add(0, portaitArr[0]); // soundClip[0] ~ 
        portraitData.Add(0 + 1, portaitArr[1]);
        portraitData.Add(0 + 2, portaitArr[2]);
        /* portraitData.Add(0 + 3, portaitArr[3]);
        portraitData.Add(0 + 4, portaitArr[4]);
        portraitData.Add(0 + 5, portaitArr[5]);
        portraitData.Add(0 + 6, portaitArr[6]);
        portraitData.Add(0 + 7, portaitArr[7]);
        portraitData.Add(0 + 8, portaitArr[8]);
        portraitData.Add(0 + 9, portaitArr[9]);
        portraitData.Add(0 + 10, portaitArr[10]);
        portraitData.Add(0 + 11, portaitArr[11]); */
    } 
}
