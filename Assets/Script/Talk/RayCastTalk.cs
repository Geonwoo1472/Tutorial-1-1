using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// Tag : TalkObject의 사물을 스캔해옵니다
/// 이후 [상호작용 키]가 눌렸다면
/// 해당 사물의 ID를 얻어와 그 정보로 말풍선 기능을 실행합니다.
/// 
/// #object used(부착 오브젝트)#
/// Player
/// 
/// #Method#
/// X
/// 
/// </summary>
public class RayCastTalk : MonoBehaviour
{
    private bool isButtonDown;
    public bool IsButtonDown
    {
        get { return isButtonDown; }
        set { isButtonDown = value; }
    }
    public GameObject ScanObject
    {
        get { return scanObject; }
    }


    private Player_Action action;               //플레이어의 방향을 받아오기 위함.
    private GameObject scanObject;              //스캔된 오브젝트 저장
    private Rigidbody2D rigid;                  // 
    private DalogManager dalogManager;          //Talk() 호출하기 위함.
    

    private void Start()
    {
        isButtonDown = true;
        action = GetComponent<Player_Action>();
        rigid = GetComponent<Rigidbody2D>();
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        
    }

    /*
     업데이트문에서는 키가 눌렸는지 판단하여
    다음 대사를 호출합니다.
     */
    private void Update()
    { 
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
        {
            if (scanObject != null)
            {
                if (isButtonDown)
                {
                    Debug.Log("RayCastTalk.cs , Interation button Down");
                    dalogManager.Action(scanObject);
                }
            }
        }
    }

    /*
     Tag TalkObject로 되어있는 물체를 스캔해옵니다.
     Update에 작성하지 않은 이유는 급박하게 처리할 필요가 없기 때문
     */
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, action.GetVector3DirVec() * RayConstants.talkRayLength, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, action.GetVector3DirVec(), RayConstants.talkRayLength , LayerMask.GetMask("TalkObject"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
