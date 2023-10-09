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

        /* CommonData */
        CommonDialog();

        /* Chapter 1  Data */
        FirstChapterDialog();
        FirstSaveDialog();
        /* Chapter 2 Data */
        SecondChapterDialog();
        SecondSaveDialog();
        /* Chapter 3 Data */
        ThirdChapterDialog();
        ThridSaveDialog();
        /* Chapter 4 Data */
        FourthChapterDialog();
        FourthSaveDialog();
        /* Chapter 5 Data */
        FifthChapterDialog();

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

    private void CommonDialog()
    {
        talkData.Add(1000, new string[] { "다음 장소로 이동 할 수 있는 열쇠를 소지하지 않아서 지나갈 수 없습니다." ,
            "p, 열쇠라고? 내가 지나온 길에 열쇠 같은건 없었는데?",
            "이런.. 설마 열쇠를 찾으러 되돌아가야 하나?"});
        talkData.Add(2000, new string[] { "1.5 스테이지 저장하시겠습니까?" });
        talkData.Add(2001, new string[] { "2.5 스테이지 저장하시겠습니까?" });
        talkData.Add(2002, new string[] { "3.5 스테이지 저장하시겠습니까?" });
        talkData.Add(2003, new string[] { "4.5 스테이지 저장하시겠습니까?" });

        talkData.Add(3000, new string[] { "1번 슬롯칸에 저장하시겠습니까?" });
        talkData.Add(3001, new string[] { "2번 슬롯칸에 저장하시겠습니까?" });
        talkData.Add(3002, new string[] { "3번 슬롯칸에 저장하시겠습니까?" });

    }

    /*Chapter 1 Data */
    private void FirstChapterDialog()
    {
        talkData.Add(100, new string[] { "p,이런곳에 표지판이 있다니, 일단 확인해보자.",
            "Space bar를 누르면 물체와 상호작용 할 수 있습니다." });

        talkData.Add(101, new string[] { "앞을 가로막고 있는 상자를 움직여 길을 지나갈 수 있습니다." ,
            "p,상자를 움직여서 길을 뚫고 앞으로 나아가라는 건가?",
            "p,설마 함정은 아니겠지...",
            "p,다른 방법도 없으니 일단 표지판에 쓰여진 대로 해볼까?",
            "상자를 이동하면 피로도가 감소합니다.",
            "피로도를 전부 소모하면 게임이 종료됩니다."});

        talkData.Add(102, new string[] { "맵을 이동할 때 마다 배고픔이 감소합니다.",
            "주어진 배고픔을 전부 소모하면 게임이 종료됩니다.",
            "p,저기 있는 건 뭐지? 뭔가 먹을 수 있는 거라면 좋겠는데.."});

        talkData.Add(103, new string[] { "음식을 획득하였습니다." ,
            "음식을 먹으면 배고픔을 회복할 수 있습니다." ,
            "I키를 눌러 인벤토리를 열고 아이템을 사용해보세요."
            });

        talkData.Add(104, new string[] { "p, 이건 뭐지?" ,
            "p, 열쇠..? 이런 곳에 열쇠가 왜 있는 거야?",
            "p, 그래도 혹시 모르니까 일단 챙겨두자.",
            "열쇠를 획득하였습니다."});
        
        talkData.Add(105, new string[] { "가지고 있던 열쇠를 사용하여 다음 장소로 이동할 수 있습니다." ,
            "p, 아까 구한 열쇠를 여기서 사용하는 건가 보군.",
            "p, 역시 챙겨 놓길 잘했어.",
            "입구에 열쇠를 가져다 대자 문이 열렸다.",
            "p, 이 다음엔 어떤 함정이 있을지 모르니 마음 단단히 먹고 움직여야겠어."});        
    }
    private void FirstSaveDialog()
    {
        talkData.Add(200, new string[] { "p 이제 슬슬 주변에 나무들이 많아지기 시작하는군.",
            "p 해변은 겨우 탈출한 건가.",
            "p 그나저나 혼자서 계속 돌아다녔더니 진이 다 빠져서 이거 원..",
            "p 눈 좀 붙이고 싶은데 어디 쉬어갈 곳 없나?",
            "p 어? 저건 천막이잖아?",
            "p 낡긴 했지만 몸을 못 누일 정도는 아니야.",
            "p 이 곳에서 잠깐 쉬어가는 게 좋겠어.",
            "천막에서 쉬어가면 지난 기록들이 저장됩니다."});
        talkData.Add(201, new string[] { "p 역시 잠시라도 쉬길 잘했군. 몸이 가벼워졌어.",
            "피로도가 일정 수치 회복됐습니다."});
        talkData.Add(202, new string[] {"p 여기 웬 도끼가 떨어져 있잖아? 이거 잘하면 요긴하게 쓰이겠는 걸?",
            "SPACE BAR를 통해 도끼를 사용할 수 있습니다."});
        talkData.Add(203, new string[] {"p 방금 주운 도끼를 여기다가 써보면 되겠군.",
            "p 어디 한 번 베어 볼까?",
            "p 이런, 너무 단단해서 안 베어지잖아?"});
        talkData.Add(204, new string[] {"나무를 베어 막혀있던 길이 열렸습니다.",
            "좋았어. 이렇게 하면 금방 이동할 수 있겠군."});
        talkData.Add(205, new string[] { "p 이 나무라면 충분히 벨 수 있겠는데?",
            "SPACE BAR를 눌러 도끼를 사용하세요."});

        talkData.Add(206, new string[] { "다시 돌아갈 필요는 없을 것 같다." });
    }
    private void SecondChapterDialog()
    {
        talkData.Add(300, new string[] { "아무래도 잠긴 것 같다.",
            "p 한 번 통과한 문은 다시 통과할 수 없는 건가 보군."});

        talkData.Add(301, new string[] { "p 드디어 숲 입구까지 들어 온 건가? 어두워지기 전에 서둘러야겠어.",
            "p 그런데 이곳은...",
            "p 전부 나무로 둘러싸여 있잖아?",
            "p 무슨 미로 같군. 여길 지나가려면 정신을 바짝 차려야겠어. "});

        talkData.Add(302, new string[] { "p 여기 웬 도끼가 떨어져 있잖아? 이거 잘하면 요긴하게 쓰이겠는 걸?",
            "SPACE BAR를 통해 도끼를 사용할 수 있습니다. "});

 

        

        talkData.Add(305, new string[] { "나무를 베어 막혀있던 길이 열렸습니다.",
            "p 좋았어. 이렇게 하면 금방 이동할 수 있겠군."});

        talkData.Add(306, new string[] { "p 이런, 늪지에 발이 빠져버렸어."});

        talkData.Add(307, new string[] { "p가지고 있던 열쇠를 사용했다." ,
            "문이 열렸다.",
            "그럼 들어가 볼까?"});

        talkData.Add(308, new string[] {"열리지 않는다.", 
            "p 문을 열려면 열쇠가 필요해."});

        talkData.Add(309, new string[] { "열매를 획득했다.",
        "열매를 사용하면 배고픔이 랜덤으로 회복 혹은 감소합니다."});

        talkData.Add(310, new string[] { "열쇠를 획득했다." });


    }
    private void SecondSaveDialog()
    {
        talkData.Add(400, new string[] { "p 어? 여기 또 천막이 있잖아?" ,
            "p 이런 것 보면 사람의 왕래가 아예 없던 무인도는 아닌 것 같은데...",
            "p 우선 쉬었다 갈까?"});

        talkData.Add(401, new string[] { "피로도가 일정 수치 회복됐습니다." });

        talkData.Add(402, new string[] { "p 뭐지? 아깐 천막에 정신 팔려서 못 봤는데 숲 한가운데 동굴이 있잖아?",
            "p 딱 봐도 위험해 보이는데.",
            "...",
            "다른 길은 전부 막혀있어서 선택지가 딱히 없어 보여. 들어가 보자."});

        talkData.Add(403, new string[] {"되돌아 갈 필요는 없어보인다."});
    }

    private void ThirdChapterDialog()
    {
        talkData.Add(500, new string[] {"아무래도 잠긴 것 같다.",
            "한 번 통과한 문은 다시 통과할 수 없는 건가 보군."});
        talkData.Add(501, new string[] {"열리지 않는다."});
        talkData.Add(502, new string[] { "들어올 때부터 예상은 했지만 역시 앞이 거의 보이지 않는군.",
            "어디 빛을 비출만한 게 있으면 좋을 텐데."});
        talkData.Add(503, new string[] { "버섯을 획득했다.",
            "버섯을 사용하면 배고픔이 랜덤으로 회복 혹은 감소합니다."});
        talkData.Add(504, new string[] { "횃불을 획득했다.",
            "빛이 약하긴 하지만, 없는 것 보단 낫겠지.",
            " 횃불을 사용하면 잠시 동안 주변 시야가 밝아집니다."});
        talkData.Add(505, new string[] { "이 곳은 뭐지? 설마 여기도 열쇠를 이용해서 들어가야 되나?",
            "일단 한 번 지나가 보자."});
        talkData.Add(506, new string[] { ".....!!!!",
            "ㅁ, 뭐야.. 방금 지나온 데가 무너져 내렸어…!",
            "만약 다 못지나가고 저 아래 깔렸다면…",
            "……",
            "윽.. 상상하기도 싫은데…",
            "젠장, 갑자기 긴장했더니 온 몸이 다 아프군.",
            "그나저나 길이 막혀버렸는데 이제 어쩌면 좋지.",
            "붕괴된 곳은 다시 지나갈 수 없습니다."});
        talkData.Add(507, new string[] {"가지고 있던 열쇠를 사용했다."});
        
    }
    private void ThridSaveDialog()
    {
        talkData.Add(600, new string[] { "“드디어 밖인가.”",
            "“그새 어둠에 익숙해졌나 눈이 부시는군...”",
        "“그래도 언제 깔려 죽을 지도 모르는 동굴에 있는 것 보다 눈부신게 훨씬 낫군.”",
        "“이 근방에도 천막이 있으려나?”"});
    }

    private void FourthChapterDialog()
    {
        talkData.Add(700, new string[] { "“여긴 뭔가 유적같은데.”",
            "“이 곳에도 함정이 설치돼 있을지 모르니 조심하는게 좋겠어.”",
            "사방이 박스로 막혀있다. 퍼즐을 풀어 막혀있는 출구를 찾아 탈출하자. " });
        talkData.Add(701, new string[] { "땅굴을 통과하자 지나온 길이 막혔다. ",
           "한 번 통과한 땅굴은 다시 지나갈 수 없습니다. ",
            "“어떤 땅굴끼리 연결돼 있는지 알 수가 없군.”",
            "“전부 다 들어가보는 수 밖에 없겠어.”"});
        talkData.Add(702, new string[] { "스위치를 누르자 막혀있던 길이 열렸다.",
            "“막혀있는 길은 이런식으로 열 수 있나보군.”" });
        talkData.Add(703, new string[] { "스턴 블록을 밟으면 잠깐 동안 이동이 제한됩니다." });
        talkData.Add(704, new string[] { "아래 문제를 해결하면 숨겨진 방으로 갈 수 있는 방법을 알 수 있습니다. " });
        talkData.Add(705, new string[] { "“?!”",
            "“구덩이에 발이 빠진건가?”",
            "“여긴 어디지?”",
            "“앞이 잘 보이지 않아서 주변을 파악하기 어렵군.”",
            "이곳은 외부인에게 무언가를 숨기기위해 만들어진 비밀의 방입니다. ",
            "미로를 풀어 제한 시간 안에 탈출하세요.",
            "“...뭐 하나 쉬운 일이 없군.”",
            "“근데 뭘 숨기려고 만든 방이지?”"});

    }
    
    private void FourthSaveDialog()
    {
        talkData.Add(800, new string[] { "“드디어 탈출한 건가?”",
            "“갈 수록 길이 험해지는군.”",
            "“하루라도 빨리 여기서 탈출하고 싶어.”",
            "“우선 천막에서 피로를 회복하자.”" });
        talkData.Add(801, new string[] { "“...!”",
            "“이건 분명… 뱃소리잖아?”",
            "“해변까지 서두르면 구조 신호를 보낼 수 있을지도 몰라.”",
            "“이러고 있을 시간이 없어.”",
            "“어서 움직이자.” " });
    }

    private void FifthChapterDialog()
    {

    }
}
