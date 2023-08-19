using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTalk : MonoBehaviour
{
    private Player_Action action;               //�÷��̾��� ������ �޾ƿ��� ����.
    private GameObject scanObject;              //��ĵ�� ������Ʈ ����
    private Rigidbody2D rigid;                  // 
    private DalogManager dalogManager;          //Talk() ȣ���ϱ� ����.
    

    private void Start()
    {
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
                dalogManager.Action(scanObject);
            }
        }
    }

    /*
     Tag TalkObject�� �Ǿ��ִ� ��ü�� ��ĵ�ؿɴϴ�.
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
     ��ĵ�� ������Ʈ�� �ܺη� ��ȯ���ݴϴ�.
     */
    public GameObject getScanObject()
    {
        return scanObject;
    }
}
