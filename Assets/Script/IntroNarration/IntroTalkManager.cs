using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;                     // ��ȭ�� ���ڿ��� �����ϴ� �ڷᱸ���Դϴ�.
    Dictionary<int, Sprite> portraitData; // ��ȭ�� NPC�� �̹����� ���εǾ��ִ� �ڷᱸ���Դϴ�.
   //  Dictionary<int, Sound> soundData;

    public Sprite[] portaitArr;                             // ���� �̹����� �����ϰ��ִ� �迭�Դϴ�.
    // public Sound[] soundClip;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        // soundData = new Dictionary<int, Sound>();
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

    /*public Sound GetSound(int ID, int soundIndex)
    {
        return portaitIndex(int ID + int soundIndex);
    } */

    private void IntroDialog()      
    {
        talkData.Add(0, new string[] { "���� ���� ������ �ĵ� �Ҹ��� ����´�.:0:0",
            "�Ծ� ���� �ۼ��� �𷡾��� ������.:0:0",
            "��ħ�� �Բ� ���س����� ������ ���ٴڰ� �� õ���� ����Ÿ���.:0:0",
            "������ ���� ������ �� ������ �ߴ� ������ �ֺ� ǳ���� ���� ���´�.:0:0",
            "¸¸�� �����ظ� �þ߸� �����ϴ� �޻�, �𷡻���� ����� �ٴٷ� �ѷ�����, �̰��� ��� �� �� �� �� ���� ���� ���ε���.:0:0",
            "���и� ������������ :1:1",
            "���� ����� ���÷ȴ�.:1:1",
            "��ǳ��� �μ��� ��, �׸��� ���ظ� �Բ� �ߴ� �������� ����� �������� ��������.:1:1",
            "���̺�! �ƹ��� ����?!��:1:1",
            "ū �Ҹ��� �������� ���ƿ��� ���� �μ��� ���� ������ �ĵ��� ���� �з��Դ� �ٽ� ���������� ��� ���̾���.:1:1",
            "������ ���� ��� ���� �ǰ�?��:1:1",
            "���� �߾�Ÿ��� �ĵ� �Ҹ��� ���� �������.:1:1",
            "�����Ⱑ ����� �𸣰����� �켱 ��� ���� ����� ã�� ���߰ھ�.��:1:1",
            "����Ű�� WASD �� ���� �̵��� �� �ֽ��ϴ�.:1:1"});


        /* Ending ��� */
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
