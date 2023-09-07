using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // ��ȭ�� ���ڿ��� �����ϴ� �ڷᱸ���Դϴ�.
    Dictionary<int, Sprite> portraitData;                   // ��ȭ�� NPC�� �̹����� ���εǾ��ִ� �ڷᱸ���Դϴ�.

    public Sprite[] portaitArr;                             // ���� �̹����� �����ϰ��ִ� �迭�Դϴ�.

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    /*
     ��ǳ���� ��ȭ�� �����ϰ��ִ� �޼ҵ��Դϴ�.
    Awkae���� ȣ���ϰ� �ֽ��ϴ�.
    �ε����� ��Ī�ϴ� ���ڿ��� �ۼ��ϸ� �ǰ�
    : �ڿ� ���� ���ڴ� �̹��� �迭�� ����Ǿ� �ִ� �ε����Դϴ�.
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
     TalkData���� �ε����� �����Ͽ� ���ϴ� ���ڸ� �����ɴϴ�.
    �Ű������δ� �ش��ϴ� �ε�����, ���ڿ��� ������ �޾�
    ����Ǿ� �ִ� ���ڿ��� �����մϴ�.
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
     portaitData���� ������ �� �ִ� �ε�����
    ��Ȳ�� �´� Sprite�� �����մϴ�.
     */
    public Sprite GetPortraite(int ID, int portaitIndex)
    {
        return portraitData[ID + portaitIndex];
    }

    private void CommonDialog()
    {
        talkData.Add(1000, new string[] { "���� ��ҷ� �̵� �� �� �ִ� ���踦 �������� �ʾƼ� ������ �� �����ϴ�." ,
            "p, ������? ���� ������ �濡 ���� ������ �����µ�?",
            "�̷�.. ���� ���踦 ã���� �ǵ��ư��� �ϳ�?"});
    }

    /*Chapter 1 Data */
    private void FirstChapterDialog()
    {
        talkData.Add(100, new string[] { "p,�̷����� ǥ������ �ִٴ�, �ϴ� Ȯ���غ���.",
            "Space bar�� ������ ��ü�� ��ȣ�ۿ� �� �� �ֽ��ϴ�." });

        talkData.Add(101, new string[] { "���� ���θ��� �ִ� ���ڸ� ������ ���� ������ �� �ֽ��ϴ�." ,
            "p,���ڸ� �������� ���� �հ� ������ ���ư���� �ǰ�?",
            "p,���� ������ �ƴϰ���...",
            "p,�ٸ� ����� ������ �ϴ� ǥ���ǿ� ������ ��� �غ���?",
            "���ڸ� �̵��ϸ� �Ƿε��� �����մϴ�.",
            "�Ƿε��� ���� �Ҹ��ϸ� ������ ����˴ϴ�."});

        talkData.Add(102, new string[] { "���� �̵��� �� ���� ������� �����մϴ�.",
            "�־��� ������� ���� �Ҹ��ϸ� ������ ����˴ϴ�.",
            "p,���� �ִ� �� ����? ���� ���� �� �ִ� �Ŷ�� ���ڴµ�.."});

        talkData.Add(103, new string[] { "������ ȹ���Ͽ����ϴ�." ,
            "������ ������ ������� ȸ���� �� �ֽ��ϴ�." ,
            "IŰ�� ���� �κ��丮�� ���� �������� ����غ�����.",
            "���� ����ϴ� �������� �� ���Կ� ����Ͽ� �����ϰ� ����� �� �ֽ��ϴ�."});

        talkData.Add(104, new string[] { "p, �̰� ����?" ,
            "p, ����..? �̷� ���� ���谡 �� �ִ� �ž�?",
            "p, �׷��� Ȥ�� �𸣴ϱ� �ϴ� ì�ܵ���.",
            "���踦 ȹ���Ͽ����ϴ�."});
        
        talkData.Add(105, new string[] { "������ �ִ� ���踦 ����Ͽ� ���� ��ҷ� �̵��� �� �ֽ��ϴ�." ,
            "p, �Ʊ� ���� ���踦 ���⼭ ����ϴ� �ǰ� ����.",
            "p, ���� ì�� ���� ���߾�.",
            "�Ա��� ���踦 ������ ���� ���� ���ȴ�.",
            "p, �� ������ � ������ ������ �𸣴� ���� �ܴ��� �԰� �������߰ھ�."});        
    }
    private void FirstSaveDialog()
    {
        talkData.Add(200, new string[] { "p ���� ���� �ֺ��� �������� �������� �����ϴ±�.",
            "p �غ��� �ܿ� Ż���� �ǰ�.",
            "p �׳����� ȥ�ڼ� ��� ���ƴٳ���� ���� �� ������ �̰� ��..",
            "p �� �� ���̰� ������ ��� ��� �� ����?",
            "p ��? ���� õ�����ݾ�?",
            "p ���� ������ ���� �� ���� ������ �ƴϾ�.",
            "p �� ������ ��� ����� �� ���ھ�.",
            "õ������ ����� ���� ��ϵ��� ����˴ϴ�."});
        talkData.Add(201, new string[] { "p ���� ��ö� ���� ���߱�. ���� ����������.",
            "�Ƿε��� ���� ��ġ ȸ���ƽ��ϴ�."});
    }
    private void SecondChapterDialog()
    {
        talkData.Add(300, new string[] { "�ƹ����� ��� �� ����.",
            "p �� �� ����� ���� �ٽ� ����� �� ���� �ǰ� ����."});

        talkData.Add(301, new string[] { "p ���� �� �Ա����� ��� �� �ǰ�? ��ο����� ���� ���ѷ��߰ھ�.",
            "p �׷��� �̰���...",
            "p ���� ������ �ѷ��ο� ���ݾ�?",
            "p ���� �̷� ����. ���� ���������� ������ ��¦ �����߰ھ�. "});

        talkData.Add(302, new string[] { "p ���� �� ������ ������ ���ݾ�? �̰� ���ϸ� ����ϰ� ���̰ڴ� ��?",
            "SPACE BAR�� ���� ������ ����� �� �ֽ��ϴ�. "});

        talkData.Add(303, new string[] { "p �Ʊ� ���� ������ ����ٰ� �Ẹ�� �ǰڱ�.", 
            "p ��� �� �� ���� ����?",
            "p �̷�, �ʹ� �ܴ��ؼ� �� �������ݾ�?"});

        talkData.Add(304, new string[] { "p �� ������� ����� �� �� �ְڴµ�?",
            "SPACE BAR�� ���� ������ ����ϼ���."});

        talkData.Add(305, new string[] { "������ ���� �����ִ� ���� ���Ƚ��ϴ�.",
            "p ���Ҿ�. �̷��� �ϸ� �ݹ� �̵��� �� �ְڱ�."});

        talkData.Add(306, new string[] { "p �̷�, ������ ���� �������Ⱦ�. ���� Ż������ ������ ������..!",
            "���� ����� ������ ������ �� �����ϴ�. ����Ű ��,�츦 ��Ÿ�Ͽ� Ż���ϼ��� (�������) "});

        talkData.Add(307, new string[] { "p������ �ִ� ���踦 ����ߴ�." ,
            "���� ���ȴ�.",
            "�׷� �� ����?"});

        talkData.Add(308, new string[] {"������ �ʴ´�.", 
            "p ���� ������ ���谡 �ʿ���."});

    }
    private void SecondSaveDialog()
    {
        talkData.Add(400, new string[] { "p ��? ���� �� õ���� ���ݾ�?" ,
            "p �̷� �� ���� ����� �շ��� �ƿ� ���� ���ε��� �ƴ� �� ������...",
            "p �켱 ������ ����?"});

        talkData.Add(401, new string[] { "�Ƿε��� ���� ��ġ ȸ���ƽ��ϴ�." });

        talkData.Add(402, new string[] { "p ����? �Ʊ� õ���� ���� �ȷ��� �� �ôµ� �� �Ѱ�� ������ ���ݾ�?",
            "p �� ���� ������ ���̴µ�.",
            "...",
            "�ٸ� ���� ���� �����־ �������� ���� ���� ����. �� ����."});

        talkData.Add(403, new string[] {""});
    }

    private void ThirdChapterDialog()
    {

    }
    private void ThridSaveDialog()
    {

    }

    private void FourthChapterDialog()
    {

    }
    
    private void FourthSaveDialog()
    {

    }

    private void FifthChapterDialog()
    {

    }
}
