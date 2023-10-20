using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// RayCast로 앞에있는 오브젝트를 판별합니다.
/// 
/// #object used(부착 오브젝트)#
/// Player
/// 
/// #Method#
/// -void Update()
/// Layer, Object로 등록된 물체들을 읽어옵니다.
/// 현재 관리하는 게임오브젝트는 Box, Tree, Switch입니다.
/// 
/// 
/// </summary>
public class player_Raycast : MonoBehaviour
{
    Rigidbody2D rigid;                          // player의 Rigidbody
    Player_Action playerAction;                 // 박스 민 경우 플레이어 컨트롤 정지용
    public GameObject scanObject;               // 현재 스캔중인 오브젝트
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
            // ray로 상호작용 중이라면 return
            if (canTransTo)
                return;

            string rayTag = rayHit.collider.tag;

            switch (rayTag)
            {
                case "Box":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;
                        //박스 움직이는 메소드
                        scanObject.GetComponent<moveBox>().SetIsReady(true);

                        //캐릭터 움직임 잠구는 메소드
                        playerAction.MovePause(true);
                        break;
                    }
                case "Tree":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;

                        //Tree 상호작용 메소드 , Tree가 제거 가능한 상태로 만든다.
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
        // pastTag 처리
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
