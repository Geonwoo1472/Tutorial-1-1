using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // ��ȭ�� ���ڿ��� �����ϴ� �ڷᱸ���Դϴ�.
    Dictionary<int, Sprite> portraitData; // ��ȭ�� NPC�� �̹����� ���εǾ��ִ� �ڷᱸ���Դϴ�.
                                          //  Dictionary<int, Sound> soundData;

    public Sprite[] portaitArr;                             // ���� �̹����� �����ϰ��ִ� �迭�Դϴ�.

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
        talkData.Add(0, new string[] { "����� �غ��� ������ ���� ��ȣź�� �Ͷ߷ȴ�.:0:11",
            "���� ��ȣ�� �߰��� �谡 ��Ӹ��� ������ ���� ������.:0:10",
            "����ϴ� ��Ҹ��� ��������� �λ꽺���� ����� �Ҹ��� �ֺ��� �ѷ��մ�.:1:10",
            "������ �������� �迡 �ö�ź ���� ������ ���� ���� �־����� ���� �ٶ� �� �־���.:1:10"});
    }


    private void OutTroImage()
    {
        portraitData.Add(0, portaitArr[0]);
         portraitData.Add(0 + 1, portaitArr[1]);
    }
}
