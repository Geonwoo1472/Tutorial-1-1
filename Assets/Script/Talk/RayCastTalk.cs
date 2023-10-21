using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// Tag : TalkObject�� �繰�� ��ĵ�ؿɴϴ�
/// ���� [��ȣ�ۿ� Ű]�� ���ȴٸ�
/// �ش� �繰�� ID�� ���� �� ������ ��ǳ�� ����� �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
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


    private Player_Action action;               //�÷��̾��� ������ �޾ƿ��� ����.
    private GameObject scanObject;              //��ĵ�� ������Ʈ ����
    private Rigidbody2D rigid;                  // 
    private DalogManager dalogManager;          //Talk() ȣ���ϱ� ����.
    

    private void Start()
    {
        isButtonDown = true;
        action = GetComponent<Player_Action>();
        rigid = GetComponent<Rigidbody2D>();
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        
    }

    /*
     ������Ʈ�������� Ű�� ���ȴ��� �Ǵ��Ͽ�
    ���� ��縦 ȣ���մϴ�.
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
     Tag TalkObject�� �Ǿ��ִ� ��ü�� ��ĵ�ؿɴϴ�.
     Update�� �ۼ����� ���� ������ �޹��ϰ� ó���� �ʿ䰡 ���� ����
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
