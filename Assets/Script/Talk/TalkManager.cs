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
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        talkData.Add(100, new string[] { "�ڽ� 1", "�ٵ� 2��° ���� �ȵ���" });
        talkData.Add(101, new string[] { "�̷����� ǥ������ �ִٴ�, �ϴ� Ȯ���غ���." });


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


}
