using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalogManager : MonoBehaviour
{
    public TypeEffect talk;                     //TypeEffect.cs
    public GameObject talkPanel;                //인게임 말풍선 판넬 이미지
    public bool isAction;                       // 판넬의 ON/OFF 여부입니다.
    public bool IsAction
    {
        get { return isAction; }
        set { isAction = value; }
    }                                           //판넬 프로퍼티

    public TalkManager talkManager;             //talkManger.cs
    public Image portraitImg;                   //NPC 이미지
    public int talkIndex;                       //현재 문자열 인덱스 구분


    private GameObject scanObject;
    private ObjectTalkData objData;
    private PlayerCompulsionMove compulsionScript;

    public delegate void LastDalog();           //문자열 종료 시 연결된 메소드 호출용 델리게이트
    public LastDalog lastDalog;

    /* 
     스캔된 오브젝트의 ID를 확인하고
     Talk 메소드를 호출합니다.
    이후 말풍선 판넬의 활성유무를 결정합니다.

    말풍선이 끝나는 마지막 호출의 경우 
    플레이어의 움직일 수 있도록 변경하고
    만약 compulsion기능을 사용한다면 플레이어의 움직임을 다시 제한하고
    설정한 방향과 시간동안 강제로 이동합니다.
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
    매개변수로 오브젝트의 ID와 Npc의 여부를 받습니다.
    ID에 해당하는 문자열이 있는 경우에는
    말풍선 판넬을 키고 끕니다.
    말풍선 안에 들어갈 문자열은 talkManager에 있는 GetTalk메소드를 호출하여 리턴받습니다.

    talkData가 null인 경우는 말풍선의 마지막데이터이며
    내부에서 사용하고있는 값을 초기화합니다.
    만약 autoTalk을 사용하고 있다면, 내부 값에 따라서 활성/비활성을 결정하며
    compulsion을 사용한다면 내부 변수에 값을 저장해
    마지막 호출에 플레이어가 강제 이동될 수 있게 설정합니다.
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
