using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalogManager : MonoBehaviour
{
    public TypeEffect talk;
    public GameObject talkPanel;
    public bool isAction;
    public TalkManager talkManager;
    public Image portraitImg;
    public int talkIndex;


    private GameObject scanObject;
    private ObjectTalkData objData;
    


    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        objData = scanObject.GetComponent<ObjectTalkData>();
        Talk(objData.ID, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int ID, bool isNpc)
    {
        string talkData = "";

        if (talk.isAnim)
            talk.SetMsg("");
        else
            talkData = talkManager.GetTalk(ID, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;

            if (objData.isCollider)
                scanObject.SetActive(false);

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
