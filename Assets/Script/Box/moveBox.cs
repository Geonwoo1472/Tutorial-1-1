using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ �ڽ��� �̴� ���
/// �ڽ��� �̵��Ǳ� ���� ������ �����Ǿ� �ֽ��ϴ�.
/// 
/// -Method
/// void MoveObject() : �ڽ��� �и��� �������� ó���մϴ�. / ������ �������� �����ϴ�.
/// void setisReady(bool) : �ڽ��� ������ ���� ���� isReady�� ���� Set�ϴ� �뵵�� ���˴ϴ�.
/// public void ResetPos() : �ڽ��� �ùٸ��� �и� �� ���� ó���� ����մϴ�.
/// void SoundPlaying() : soundType������ ���߾� ���� �Ŵ����� ȣ���Ͽ� �ڽ��� �и��� �Ҹ��� ȣ���մϴ�.
/// </summary>
public class moveBox : MonoBehaviour
{
    public float speed;
    public BoxSoundType soundType;

    Rigidbody2D rigid;
    GameObject obj;
    Player_Action player;

    Vector3 past_pos;

    bool isReady;
    float boxMoveTime;

    

    private void Awake()
    {
        obj = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = obj.GetComponent<Player_Action>();
        isReady = false;
        past_pos = transform.position;


    }

    private void FixedUpdate()
    {
        if (isReady)
        {
            SoundPlaying();
            MoveObject();
        }
        else
            ResetPos();
    }

    void MoveObject()
    {
        Debug.Log("moveObject() .. ");

        boxMoveTime += Time.deltaTime;
        switch (player.GetShortDirection())
        {
            // ĳ���Ͱ� ���ʿ��� �ڽ��� �о��� �� 
            case Constants.DL:
                if (past_pos.x - 0.9f <= transform.position.x)
                {
                    if (boxMoveTime == 0.02f)
                    {
                        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                        rigid.velocity = Vector2.left * speed;
                    }

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                        rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
                // �ڽ��� ����� �� ���
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.x -= 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                    PlayerStatus.instance.OnDamageFatigue(HF_Constance.BOXMOVE);
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    
                }
                break;
            // ĳ���Ͱ� ���ʿ��� �ڽ��� �о��� �� 
            case Constants.DR:
                if (past_pos.x + 0.9f >= transform.position.x)
                {
                    if (boxMoveTime == 0.02f)
                    {
                        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                        rigid.velocity = Vector2.right * speed;
                    }
                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                        rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
                // �ڽ��� ����� �� ���
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.x += 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                    PlayerStatus.instance.OnDamageFatigue(HF_Constance.BOXMOVE);
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    
                }
                break;
            // ĳ���Ͱ� ���ʿ��� �ڽ��� �о��� �� 
            case Constants.DD:
                if (past_pos.y - 0.9f <= transform.position.y)
                {
                    if (boxMoveTime == 0.02f)
                    {
                        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                        rigid.velocity = Vector2.down * speed;
                    }

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                        rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
                // �ڽ��� ����� �� ���
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.y -= 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                    PlayerStatus.instance.OnDamageFatigue(HF_Constance.BOXMOVE);
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    
                }
                break;
            // ĳ���Ͱ� ���ʿ��� �ڽ��� �о��� �� 
            case Constants.DU:
                if (past_pos.y + 0.9f >= transform.position.y)
                {
                    if (boxMoveTime == 0.02f)
                    {
                        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                        rigid.velocity = Vector2.up * speed;
                    }

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                        rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    }
                }
                // �ڽ��� ����� �� ���
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.y += 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                    PlayerStatus.instance.OnDamageFatigue(HF_Constance.BOXMOVE);
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                    
                }
                break;

            default:
                Debug.Log(" ĳ���� ���� ���� !! default ");
                break;
        }



    }

    void ResetPos()
    {
        rigid.velocity = Vector2.zero;
        transform.position = past_pos;
    }

    public void SetIsReady(bool isReady)
    {
        this.isReady = isReady;
    }

    private void SoundPlaying()
    {
        switch(soundType)
        {
            case BoxSoundType.Beach:
                {
                    SoundManager.instance.SoundPlaying(SoundType.oneBoxSound);
                }
                break;
            case BoxSoundType.Forest:
                {
                    SoundManager.instance.SoundPlaying(SoundType.twoBoxSound);
                }
                break;
            case BoxSoundType.Cave:
                {
                    SoundManager.instance.SoundPlaying(SoundType.threeBoxSound);
                }
                break;
            case BoxSoundType.Ruins:
                {
                    SoundManager.instance.SoundPlaying(SoundType.fourBoxSound);
                }
                break;
            case BoxSoundType.LastMap:
                {
                    SoundManager.instance.SoundPlaying(SoundType.fiveBoxSound);
                }
                break;
        }
    }
}
