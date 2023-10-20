using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// RayCast�� �տ��ִ� ������Ʈ�� �Ǻ��մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Player
/// 
/// #Method#
/// -void Update()
/// Layer, Object�� ��ϵ� ��ü���� �о�ɴϴ�.
/// ���� �����ϴ� ���ӿ�����Ʈ�� Box, Tree, Switch�Դϴ�.
/// 
/// 
/// </summary>
public class player_Raycast : MonoBehaviour
{
    Rigidbody2D rigid;                          // player�� Rigidbody
    Player_Action playerAction;                 // �ڽ� �� ��� �÷��̾� ��Ʈ�� ������
    public GameObject scanObject;               // ���� ��ĵ���� ������Ʈ
    bool canTransTo;                            // 
    float canTransTime;                         // 

    public string pastTag;                      // 

    void Start()
    {
        canTransTo = false;
        canTransTime = 0f;
        rigid = GetComponent<Rigidbody2D>();
        playerAction = GetComponent<Player_Action>();
        pastTag = null;
    }

    void Update()
    {
        Debug.DrawRay(rigid.position, playerAction.GetVector3DirVec() * RayConstants.objectRayLength , new Color(1, 1, 1));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, playerAction.GetVector3DirVec(), RayConstants.objectRayLength, LayerMask.GetMask("Object"));


        if (rayHit.collider != null)
        {
            // ray�� ��ȣ�ۿ� ���̶�� return
            if (canTransTo)
                return;

            string rayTag = rayHit.collider.tag;

            switch (rayTag)
            {
                case "Box":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;
                        //�ڽ� �����̴� �޼ҵ�
                        scanObject.GetComponent<moveBox>().SetIsReady(true);

                        //ĳ���� ������ �ᱸ�� �޼ҵ�
                        playerAction.MovePause(true);
                        break;
                    }
                case "Tree":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;

                        //Tree ��ȣ�ۿ� �޼ҵ� , Tree�� ���� ������ ���·� �����.
                        pastTag = rayTag;
                        scanObject.GetComponent<IDestroyable>().MyOnDestroy();

                        break;
                    }
                case "Switch":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;
                        pastTag = rayTag;

                        break;
                    }
                default:
                    Debug.Log("player_raycase.cs switch default ..");
                    break;
            }

            
        }
        // pastTag ó��
        else
        {
            if (pastTag == "Tree")
            {
                if(scanObject!=null)
                    scanObject.GetComponent<IDestroyable>().OffDestroy();

                scanObject = null;
                pastTag = null;
            }

            if(pastTag == "Switch")
            {
                scanObject = null;
                pastTag = null;
            }
        }

    }

    private void FixedUpdate()
    {
        if (canTransTo)
        {
            canTransTime += Time.deltaTime;
            if (canTransTime >= 1f)
            {
                canTransTime = 0;
                canTransTo = false;
            }
        }
    }
}
