using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Raycast : MonoBehaviour
{

    Rigidbody2D rigid;
    Player_Action _pA;
    public GameObject scanObject;
    bool canTransTo;
    float canTransTime;

    string pastTag;

    void Start()
    {
        canTransTo = false;
        canTransTime = 0f;
        rigid = GetComponent<Rigidbody2D>();
        _pA = GetComponent<Player_Action>();
        pastTag = null;
    }

    void Update()
    {
        Debug.DrawRay(rigid.position, _pA.GetVector3DirVec() * RayConstants.objectRayLength , new Color(1, 1, 1));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, _pA.GetVector3DirVec(), RayConstants.objectRayLength, LayerMask.GetMask("Object"));


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
                        scanObject.GetComponent<moveBox>().setisReady(true);

                        //캐릭터 움직임 잠구는 메소드
                        _pA.isCharacterSetter(true);
                        break;
                    }
                case "Tree":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;
                        Debug.Log("스캔된 오브젝트 이름 : " + scanObject.name + "입니다.");

                        //Tree 상호작용 메소드 , Tree가 제거 가능한 상태로 만든다.
                        pastTag = rayTag;
                        scanObject.GetComponent<IDestroyable>().MyOnDestroy();

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
                // 수정 수정 수정 
                // 삭제된 경우 컴포넌트를 찾을 수 없어 오류남., 수정할 것 !!
                scanObject.GetComponent<IDestroyable>().OffDestroy();

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
