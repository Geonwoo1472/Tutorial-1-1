using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTalk : MonoBehaviour
{
    private Player_Action action;               //플레이어의 방향을 받아오기 위함.
    private GameObject scanObject;              //스캔된 오브젝트 저장
    private Rigidbody2D rigid;                  // 
    private DalogManager dalogManager;          //Talk() 호출하기 위함.
    

    private void Start()
    {
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
                dalogManager.Action(scanObject);
            }
        }
    }

    /*
     Tag TalkObject로 되어있는 물체를 스캔해옵니다.
     */
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, action.get_v_dir() * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, action.get_v_dir(), 0.7f, LayerMask.GetMask("TalkObject"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    /*
     스캔된 오브젝트를 외부로 반환해줍니다.
     */
    public GameObject getScanObject()
    {
        return scanObject;
    }
}
