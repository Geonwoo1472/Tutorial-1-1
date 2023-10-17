using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 박스를 미는 경우
/// 박스가 이동되기 위한 로직이 구현되어 있습니다.
/// 
/// -Method
/// void MoveObject() : 박스가 밀리는 움직임을 처리합니다. / 유저의 움직임을 막습니다.
/// void setisReady(bool) : 박스의 움직임 유무 변수 isReady의 값을 Set하는 용도로 사용됩니다.
/// public void ResetPos() : 박스가 올바르게 밀린 후 정지 처리를 담당합니다.
/// void SoundPlaying() : soundType변수에 맞추어 사운드 매니저를 호출하여 박스의 밀리는 소리를 호출합니다.
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
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
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
                // 박스를 제대로 민 경우
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
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
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
                // 박스를 제대로 민 경우
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
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
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
                // 박스를 제대로 민 경우
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
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
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
                // 박스를 제대로 민 경우
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
                Debug.Log(" 캐릭터 방향 없음 !! default ");
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
