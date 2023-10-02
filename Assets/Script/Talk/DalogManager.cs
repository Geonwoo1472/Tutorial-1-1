using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalogManager : MonoBehaviour
{
    public TypeEffect talk;                     //TypeEffect.cs
    public GameObject talkPanel;                //�ΰ��� ��ǳ�� �ǳ� �̹���
    public bool isAction;                       // �ǳ��� ON/OFF �����Դϴ�.
    public bool IsAction
    {
        get { return isAction; }
        set { isAction = value; }
    }                                           //�ǳ� ������Ƽ

    public TalkManager talkManager;             //talkManger.cs
    public Image portraitImg;                   //NPC �̹���
    public int talkIndex;                       //���� ���ڿ� �ε��� ����


    private GameObject scanObject;
    private ObjectTalkData objData;
    private PlayerCompulsionMove compulsionScript;

    public delegate void LastDalog();           //���ڿ� ���� �� ����� �޼ҵ� ȣ��� ��������Ʈ
    public LastDalog lastDalog;

    /* 
     ��ĵ�� ������Ʈ�� ID�� Ȯ���ϰ�
     Talk �޼ҵ带 ȣ���մϴ�.
    ���� ��ǳ�� �ǳ��� Ȱ�������� �����մϴ�.

    ��ǳ���� ������ ������ ȣ���� ��� 
    �÷��̾��� ������ �� �ֵ��� �����ϰ�
    ���� compulsion����� ����Ѵٸ� �÷��̾��� �������� �ٽ� �����ϰ�
    ������ ����� �ð����� ������ �̵��մϴ�.
     */
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        objData = scanObject.GetComponent<ObjectTalkData>();
        Talk(objData.ID, objData.isNpc);

        talkPanel.SetActive(isAction);
        GameManager.instance.setMove(isAction);
        if(compulsionScript != null)
        {
            if(isAction == false)
            {
                compulsionScript.CoroutineCompulsionMove();
                compulsionScript = null;
            }
        }
    }

    /* 
    �Ű������� ������Ʈ�� ID�� Npc�� ���θ� �޽��ϴ�.
    ID�� �ش��ϴ� ���ڿ��� �ִ� ��쿡��
    ��ǳ�� �ǳ��� Ű�� ���ϴ�.
    ��ǳ�� �ȿ� �� ���ڿ��� talkManager�� �ִ� GetTalk�޼ҵ带 ȣ���Ͽ� ���Ϲ޽��ϴ�.

    talkData�� null�� ���� ��ǳ���� �������������̸�
    ���ο��� ����ϰ��ִ� ���� �ʱ�ȭ�մϴ�.
    ���� autoTalk�� ����ϰ� �ִٸ�, ���� ���� ���� Ȱ��/��Ȱ���� �����ϸ�
    compulsion�� ����Ѵٸ� ���� ������ ���� ������
    ������ ȣ�⿡ �÷��̾ ���� �̵��� �� �ְ� �����մϴ�.
     */
    void Talk(int ID, bool isNpc)
    {
        string talkData = "";

        if (talk.isAnim)
        { 
            talk.SetMsg("");
            return;
        }
        else
            talkData = talkManager.GetTalk(ID, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;

            if (lastDalog != null)
                lastDalog.Invoke();

            if (objData.autoTalkUse == true)
            {
                AutoTalk autoTalkScript = scanObject.GetComponent<AutoTalk>();
                if(autoTalkScript.talkProperty == TalkProperty.Disposable)
                    scanObject.SetActive(false);

                if(autoTalkScript.compulsionUse)
                {
                    compulsionScript = scanObject.GetComponent<PlayerCompulsionMove>();
                }
            }
                
            return;
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);
            
            portraitImg.sprite = talkManager.GetPortraite(ID, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;

    }
}
