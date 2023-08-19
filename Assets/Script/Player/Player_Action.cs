using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 BugList
1) 코루틴에서 멈추었는데 Update에서 풀어서 움직이는 것 같음
   맵탄 상태에서 키 계속 누르고 있으면 미세하게 반응함.
 */
public enum PlayerState
{
    MoveOn =0,
    MoveOff,
    MoveSlow
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

    // 캐릭터 속력
    public float speed;
    private float baseSpeed;
    private float decreaseSpeed;

    // 캐릭터 방향
    short direction;
    Vector3 dirVec;
    bool isCharacterMove;
    float isCharacterTime;

    // h : horizontal , v : vertical
    float h;
    float v;

    bool isHorizonMove;


    /* 값 가져오기 */
    private Rigidbody2D rigid;

    /*애니메이션 */
    Animator anim;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = Constants.DD;
        dirVec = Vector3.down;
        isCharacterTime = 0f;
        isCharacterMove = false;
        baseSpeed = speed;
        decreaseSpeed = speed / 2;

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance != null)
        {
            //임시방편으로 게임오버 활성화 중 움직임 불가함.
            if (GameManager.instance.isGameover)
                return;

            //
            if (GameManager.instance.moveStatus)
                return;
        }
        //키보드 입력 받는 메소드
        Player_Move();
        //실제 게임 velocity 주는 메소드
        Player_velocity();
    }

    void FixedUpdate()
    {
        if (isCharacterMove)
        {
            isCharacterTime += Time.deltaTime;
            if (isCharacterTime >= 0.7f)
            {
                isCharacterMove = false;
                isCharacterTime = 0f;
            }
        }
    }

    void Player_Move()
    {

        if (isCharacterMove)
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

    void Player_velocity()
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
    public short get_s_dir()
    {
        return direction;
    }

    public Vector3 get_v_dir()
    {
        return dirVec;
    }

    public void isCharacterSetter(bool isCharacter)
    {
        isCharacterMove = isCharacter;
    }

    //정지시 캐릭터 애니메이션 
    public void modifyRigidbody(bool change)
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

    //플레이어 움직임 제어 OnStop(PlayerState.MoveOff) 으로 호출하여야함.
    //설계가 살짝 잘못되어 있음.
    //매개변수를 2개 받고 멈추는 시간까지 받는게 좋아보임 수정할 것
    public void PlayerCorouine(PlayerState state, float applyTime = 0)
    {
        playerState = state;

        switch (playerState)
        {
            case PlayerState.MoveOn:
                //StartCoroutine(Stop());
                break;
            case PlayerState.MoveOff:
                StartCoroutine(MoveStop());
                break;
            case PlayerState.MoveSlow:
                StartCoroutine(MoveSlow(applyTime));
                break;
            default:
                break;

        }

    }


    private IEnumerator MoveStop()
    {
        while (true)
        {
            yield return StartCoroutine(Stop());

            yield return StartCoroutine(Move());

            if (playerState == PlayerState.MoveOff)
            {
                break;
            }
        }
    }

    // 
    private IEnumerator Stop()
    {
        float currentTime = 0.0f;

        while (currentTime < 2)
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

            if (playerState == PlayerState.MoveSlow)
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

    // 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            Debug.Log("박스와 충돌함 !! ");

        }
    }
}

