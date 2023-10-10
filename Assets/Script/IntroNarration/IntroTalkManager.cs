using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // ��ȭ�� ���ڿ��� �����ϴ� �ڷᱸ���Դϴ�.
    Dictionary<int, Sprite> portraitData; // ��ȭ�� NPC�� �̹����� ���εǾ��ִ� �ڷᱸ���Դϴ�.

    public Sprite[] portaitArr;                             // ���� �̹����� �����ϰ��ִ� �迭�Դϴ�.

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    void GenerateData()
    {
        /*Intro*/
        IntroDialog();
        IntroImage();
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



    private void IntroDialog()      
    {
        talkData.Add(0, new string[] { "���� ���� ������ �ĵ� �Ҹ��� ����´�.:1:0",
            "�Ծ� ���� �ۼ��� �𷡾��� ������.:1:0",
            "��ħ�� �Բ� ���س����� ������ ���ٴڰ� �� õ���� ����Ÿ���.:1:0",
            "������ ���� ������ �� ������ �ߴ� ������ �ֺ� ǳ���� ���� ���´�.:1:0",
            "¸¸�� �����ظ� �þ߸� �����ϴ� �޻�, �𷡻���� ����� �ٴٷ� �ѷ�����, �̰��� ��� �� �� �� �� ���� ���� ���ε���.:1:0",
            "���и� ������������ :1:0",
            "���� ����� ���÷ȴ�.:0:11",
            "��ǳ��� �μ��� ��, �׸��� ���ظ� �Բ� �ߴ� �������� ����� �������� ��������.:0:0",
            "���̺�! �ƹ��� ����?!��:1:10",
            "ū �Ҹ��� �������� ���ƿ��� ���� �μ��� ���� ������ �ĵ��� ���� �з��Դ� �ٽ� ���������� ��� ���̾���.:1:10",
            "������ ���� ��� ���� �ǰ�?��:1:0",
            "���� �߾�Ÿ��� �ĵ� �Ҹ��� ���� �������.:1:10",
            "�����Ⱑ ����� �𸣰����� �켱 ��� ���� ����� ã�� ���߰ھ�.��:1:10",
            "����Ű�� WASD �� ���� �̵��� �� �ֽ��ϴ�.:1:10"});

    }


    private void IntroImage()
    {
        portraitData.Add(0, portaitArr[0]);
        portraitData.Add(0 + 1, portaitArr[1]);
    } 
}
