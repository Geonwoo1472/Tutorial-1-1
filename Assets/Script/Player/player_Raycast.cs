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
                        scanObject.GetComponent<moveBox>().setisReady(true);

                        //ĳ���� ������ �ᱸ�� �޼ҵ�
                        _pA.isCharacterSetter(true);
                        break;
                    }
                case "Tree":
                    {
                        canTransTo = true;
                        scanObject = rayHit.collider.gameObject;
                        Debug.Log("��ĵ�� ������Ʈ �̸� : " + scanObject.name + "�Դϴ�.");

                        //Tree ��ȣ�ۿ� �޼ҵ� , Tree�� ���� ������ ���·� �����.
                        pastTag = rayTag;
                        scanObject.GetComponent<IDestroyable>().MyOnDestroy();

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
                // ���� ���� ���� 
                // ������ ��� ������Ʈ�� ã�� �� ���� ������., ������ �� !!
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
