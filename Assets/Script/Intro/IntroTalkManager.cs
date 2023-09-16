using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTalkManager : MonoBehaviour
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
        /*Intro*/
        IntroDialog();
        IntroImage();
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

    private void IntroDialog()
    {
        talkData.Add(0, new string[] { "���� ���� ������ �ĵ� �Ҹ��� ����´�.:0",
            "�Ծ� ���� �ۼ��� �𷡾��� ������.:1",
            "��ħ�� �Բ� ���س����� ������ ���ٴڰ� �� õ���� ����Ÿ���.:2",
            "������ ���� ������ �� ������ �ߴ� ������ �ֺ� ǳ���� ���� ���´�.:3",
            "¸¸�� �����ظ� �þ߸� �����ϴ� �޻�, �𷡻���� ����� �ٴٷ� �ѷ�����, �̰��� ��� �� �� �� �� ���� ���� ���ε���.:4",
            "���и� ������������ :5",
            "���� ����� ���÷ȴ�.:6",
            "��ǳ��� �μ��� ��, �׸��� ���ظ� �Բ� �ߴ� �������� ����� �������� ��������.:7",
            "���̺�! �ƹ��� ����?!��:8",
            "ū �Ҹ��� �������� ���ƿ��� ���� �μ��� ���� ������ �ĵ��� ���� �з��Դ� �ٽ� ���������� ��� ���̾���.:9",
            "������ ���� ��� ���� �ǰ�?��:10",
            "���� �߾�Ÿ��� �ĵ� �Ҹ��� ���� �������.:11",
            "�����Ⱑ ����� �𸣰����� �켱 ��� ���� ����� ã�� ���߰ھ�.��:11",
            "����Ű�� WASD �� ���� �̵��� �� �ֽ��ϴ�.:11"});
    }

    private void IntroImage()
    {
        portraitData.Add(0, portaitArr[0]);
        portraitData.Add(0 + 1, portaitArr[1]);
        portraitData.Add(0 + 2, portaitArr[2]);
        portraitData.Add(0 + 3, portaitArr[3]);
        portraitData.Add(0 + 4, portaitArr[4]);
        portraitData.Add(0 + 5, portaitArr[5]);
        portraitData.Add(0 + 6, portaitArr[6]);
        portraitData.Add(0 + 7, portaitArr[7]);
        portraitData.Add(0 + 8, portaitArr[8]);
        portraitData.Add(0 + 9, portaitArr[9]);
        portraitData.Add(0 + 10, portaitArr[10]);
        portraitData.Add(0 + 11, portaitArr[11]);
    }
}
