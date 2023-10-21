using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 말풍선이 끝난 후 플레이어를 지정된 방향으로 강제 이동시킵니다.
/// 
/// #object used(부착 오브젝트)#
/// 통과시키지 않을 게임오브젝트
/// AutoTalk의 프로퍼티변수를 재사용으로, Compulsion 사용으로 해둔 후
/// 해당 컴포넌트를 추가하여 사용
/// 
/// #Method#
/// -public void CorotineCompulsionMove()
/// 지정된 방향으로 지정된 시간만큼
/// 플레이어 움직임을 막아두고 플레이어를 강제 이동시킵니다.
/// 
/// 
/// </summary>
public class PlayerCompulsionMove : MonoBehaviour
{
    public Direction compulsionDirection;               // 플레이어가 강제로 이동할 방향
    public float targetTime;                            // 강제로 이동할 목표 시간

    private float progressTime;                         // 현재 진행 시간
    private Vector2 direction;                          // 플레이어가 강제로 이동할 방향
    private Rigidbody2D playerRigid;                    // 플레이어 Rigid
    private Animator anim;                              // 플레이어 Animator
    private AutoTalk autoTalkScript;                    // AutoTalkScript의 세마포어 값 변경

    private void Awake()
    {
        progressTime = 0;
        InitDirection();
        autoTalkScript = GetComponent<AutoTalk>();
    }
    private void Start()
    {
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void InitDirection()
    {
        switch (compulsionDirection)
        {
            case Direction.Left:
                direction = Vector2.left;
                break;
            case Direction.Right:
                direction = Vector2.right;
                break;
            case Direction.Up:
                direction = Vector2.up;
                break;
            case Direction.Down:
                direction = Vector2.down;
                break;
            default:
                Debug.Log("InitDirection() Error");
                break;
        }
    }

    /*
     코루틴 시작 메소드입니다.
    호출하면 현재 지속시간을 초기화하고 코루틴을 시작합니다.
     */
    public void CoroutineCompulsionMove()
    {
        progressTime = 0;
        StartCoroutine(CompulsionMove());
    }

    /*
     게임 매니저에 있는 MoveStatus값을 변경하여
    플레이어의 움직임 입력키를 받지 못하게 막습니다.
    이후 설정한 방향으로 targetTime의 시간만큼 플레이어는 이동하게됩니다.
    플레이어 움직임이 끝난 후 
    Stay트리거에서 사용하고 있는 semapo값과
    움직임 제한하고있는 MoveStatus값을 변경하여 움직일 수 있도록 변경합니다.
     */
    IEnumerator CompulsionMove()
    {
        GameManager.instance.MoveStatus = true;
        anim.SetBool("isMoveDirection", false);
        while (progressTime < targetTime)
        {
            progressTime += Time.deltaTime;
            playerRigid.velocity = direction * 5;
            Anim();

            yield return new WaitForFixedUpdate();
        }
        GameManager.instance.MoveStatus = false;
        autoTalkScript.Semaphore = false;
    }

    /*
     코루틴 내부에서 사용하는 애니메이션 움직임 메소드입니다.
     */
    private void Anim()
    {
        switch (compulsionDirection)
        {
            case Direction.Up:
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("vRaw", (int)1);
                anim.SetInteger("hRaw", (int)0);
                break;
            case Direction.Down:
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("vRaw", (int)-1);
                anim.SetInteger("hRaw", (int)0);
                break;
            case Direction.Right:
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("hRaw", (int)1);
                anim.SetInteger("vRaw", (int)0);
                break;
            case Direction.Left:
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("hRaw", (int)-1);
                anim.SetInteger("vRaw", (int)0);
                break;
            default:
                Debug.Log("CompulsionMove() default");
                break;
        }
    }
}
