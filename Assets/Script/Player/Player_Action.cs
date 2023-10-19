using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 BugList
1) 코루틴에서 멈추었는데 Update에서 풀어서 움직이는 것 같음
   맵탄 상태에서 키 계속 누르고 있으면 미세하게 반응함.
 */

/// <summary>
/// #Usage(용도)#
/// 플레이어의 움직임을 담당하는 로직이 작성되어 있습니다.
/// 
/// #object used(부착 오브젝트)#
/// Player
/// 
/// #Method#
/// -void Player_Move()
/// 방향키입력을 받아 캐릭터가 움직일 수 있도록 합니다.
/// 
/// -void PlayerVelocity()
/// 입력한 방향을 바탕으로 플레이어가 바라보는 방향을 저장합니다.
/// 
/// -public short GetShortDirection()
/// getter
/// 
/// -public Vector3 GetVector3DirVec()
/// getter
/// 
/// -public void MovePause(bool)
/// 움직임을 잠시 멈추기 위해
/// 내부 bool값을 변경합니다.
/// 
/// -public void ModifyRigidbody(bool)
/// 정지한경우의 캐릭터 애니메이션로직입니다.
/// 
/// -private void MoveSfx()
/// 캐릭터가 이동 중이라면 발소리를 냅니다.
/// 
/// -public void PlayerCorouine(PlayerState, float)
/// 플레이어 움직임임을 제어하는 코루틴 메서드입니다.
/// 상태와, 시간을 매개변수로 받아 잠시 멈춥니다.
/// 
/// </summary>
public enum PlayerState
{
    pauseMovement,
    slowMovement
}

public class Player_Action : MonoBehaviour
{
    #region Singleton
    public static Player_Action instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    private PlayerState playerState;

    public float speed;
    private float baseSpeed;
    private float decreaseSpeed;

    short direction;                    //캐릭터 방향
    Vector3 dirVec;                     //캐릭터 방향
    bool playerStop;               //캐릭터를 잠시 멈추기 위한 구분자
    float isCharacterTime;              //캐릭터 내부 시간
    float h;                            //수평 값
    float v;                            //수직 값
    bool isHorizonMove;                 //
    Animator anim;                      //플레이어 애니메이션
    private AudioSource audioSrc;       //플레이어 오디오소스
    private Rigidbody2D rigid;          //플레이어 rigidbody2D
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = Constants.DD;
        dirVec = Vector3.down;
        isCharacterTime = 0f;
        playerStop = false;
        baseSpeed = speed;
        decreaseSpeed = speed / 2;
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (GameManager.instance != null)
        {
            //임시방편으로 게임오버 활성화 중 움직임 불가함.
            if (GameManager.instance.isGameover)
                return;

            //
            if (GameManager.instance.MoveStatus)
                return;
        }
        //키보드 입력 받는 메소드
        Player_Move();
        //실제 게임 velocity 주는 메소드
        PlayerVelocity();
        //캐릭터 발 사운드
        MoveSfx();
    }

    /* 캐릭터가 일시정지하고자 한다면
     0.7초 동안 멈추고 값 변경*/
    void FixedUpdate()
    {
        if (playerStop)
        {
            isCharacterTime += Time.deltaTime;
            if (isCharacterTime >= 0.7f)
            {
                playerStop = false;
                isCharacterTime = 0f;
            }
        }
    }

    void Player_Move()
    {

        if (playerStop)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            anim.SetInteger("hRaw", 0);
            anim.SetInteger("vRaw", 0);

        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

            /* <- 방향 Value -1 , -> 방향 Value 1 */
            h = Input.GetAxisRaw("Horizontal");
            /* 아래 방향 Value -1, 윗 방향 Value 1 */
            v = Input.GetAxisRaw("Vertical");

            bool hDown = Input.GetButtonDown("Horizontal");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");

            // 방향전환 시점
            if (hDown)
            {
                isHorizonMove = true;

            }
            else if (vDown)
            {
                isHorizonMove = false;

            }
            else if (hUp || vUp)
            {
                isHorizonMove = h != 0;
            }

            // 애니메이션 [ h가 가로 !! v는 세로 !! ]
            if (anim.GetInteger("hRaw") != h)
            {
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("hRaw", (int)h);
            }
            else if (anim.GetInteger("vRaw") != v)
            {
                anim.SetBool("isMoveDirection", true);
                anim.SetInteger("vRaw", (int)v);
            }
            else
            {
                anim.SetBool("isMoveDirection", false);
            }


        }
    }

    void PlayerVelocity()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        if (moveVec == Vector2.right)
        {
            direction = Constants.DR;
            dirVec = Vector3.right;
        }
        else if (moveVec == Vector2.left)
        {
            direction = Constants.DL;
            dirVec = Vector3.left;
        }
        else if (moveVec == Vector2.down)
        {
            direction = Constants.DD;
            dirVec = Vector3.down;
        }
        else if (moveVec == Vector2.up)
        {
            direction = Constants.DU;
            dirVec = Vector3.up;
        }

        rigid.velocity = moveVec * speed;
    }

    //캐릭터 방향 getter
    public short GetShortDirection()
    {
        return direction;
    }

    public Vector3 GetVector3DirVec()
    {
        return dirVec;
    }

    public void MovePause(bool value)
    {
        playerStop = value;
    }

    //정지시 캐릭터 애니메이션 
    public void ModifyRigidbody(bool change)
    {
        if (change)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            anim.SetInteger("hRaw", 0);
            anim.SetInteger("vRaw", 0);
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void MoveSfx()
    {
        if (rigid.velocity.x != 0 || rigid.velocity.y != 0)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();
    }

    /*
    플레이어 움직임 제어를 위한 코루틴시작 함수입니다.
    코루틴을 호출할 때 플레이어의 원하는 코루틴과, 활성시간을 매개변수로 받습니다.     
     */
    public void PlayerCorouine(PlayerState state, float applyTime)
    {
        playerState = state;

        switch (playerState)
        {
            case PlayerState.pauseMovement:
                StartCoroutine(MoveStop(applyTime));
                break;
            case PlayerState.slowMovement:
                StartCoroutine(MoveSlow(applyTime));
                break;
            default:
                break;

        }

    }

    private IEnumerator MoveStop(float applyTime)
    {
        yield return StartCoroutine(Stop(applyTime));
        yield return StartCoroutine(Move());
    }

    private IEnumerator Stop(float applyTime)
    {
        float currentTime = 0.0f;

        while (currentTime < applyTime)
        {
            currentTime += Time.deltaTime;
            rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            anim.SetInteger("hRaw", 0);
            anim.SetInteger("vRaw", 0);
            // 함수 반복 끝
            yield return null;
        }
        
    }

    private IEnumerator Move()
    {
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        yield return null;
    }

    // 슬로우발판 코루틴

    private IEnumerator MoveSlow(float applyTime)
    {
        while (true)
        {
            yield return StartCoroutine(OnSlow(applyTime));

            yield return StartCoroutine(OffSlow());

            if (playerState == PlayerState.slowMovement)
            {
                break;
            }
        }
    }

    private IEnumerator OnSlow(float applyTime)
    {
        float currentTime = 0.0f;

        while (currentTime < applyTime)
        {
            currentTime += Time.deltaTime;
            speed = decreaseSpeed;
            yield return null;
        }
    }

    private IEnumerator OffSlow()
    {
        speed = baseSpeed;
        yield return null;
    }
}

