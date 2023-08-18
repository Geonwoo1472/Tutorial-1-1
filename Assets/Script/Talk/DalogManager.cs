using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalogManager : MonoBehaviour
{
    public TypeEffect talk;                     //TypeEffect.cs
    public GameObject talkPanel;                //인게임 말풍선 판넬 이미지
    public bool isAction;                       // 
    public TalkManager talkManager;             //talkManger.cs
    public Image portraitImg;                   //NPC 이미지
    public int talkIndex;                       //현재 문자열 인덱스 구분


    private GameObject scanObject;
    private ObjectTalkData objData;
    

    /* 
     스캔된 오브젝트의 ID를 확인하고
     Talk 메소드를 호출합니다.
    이후 말풍선 판넬의 활성유무를 결정합니다.
     */
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        objData = scanObject.GetComponent<ObjectTalkData>();
        Talk(objData.ID, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    /* 
     
     */
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
