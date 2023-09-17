using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 BugList
1) �ڷ�ƾ���� ���߾��µ� Update���� Ǯ� �����̴� �� ����
   ��ź ���¿��� Ű ��� ������ ������ �̼��ϰ� ������.
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

    // ĳ���� �ӷ�
    public float speed;
    private float baseSpeed;
    private float decreaseSpeed;

    // ĳ���� ����
    short direction;
    Vector3 dirVec;
    bool isCharacterMove;
    float isCharacterTime;

    // h : horizontal , v : vertical
    float h;
    float v;

    bool isHorizonMove;
    /*�ִϸ��̼� */
    Animator anim;

    private AudioSource audioSrc;

    /* �� �������� */
    private Rigidbody2D rigid;
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
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance != null)
        {
            //�ӽù������� ���ӿ��� Ȱ��ȭ �� ������ �Ұ���.
            if (GameManager.instance.isGameover)
                return;

            //
            if (GameManager.instance.MoveStatus)
                return;
        }
        //Ű���� �Է� �޴� �޼ҵ�
        Player_Move();
        //���� ���� velocity �ִ� �޼ҵ�
        PlayerVelocity();
        //ĳ���� �� ����
        MoveSfx();
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

            /* <- ���� Value -1 , -> ���� Value 1 */
            h = Input.GetAxisRaw("Horizontal");
            /* �Ʒ� ���� Value -1, �� ���� Value 1 */
            v = Input.GetAxisRaw("Vertical");

            bool hDown = Input.GetButtonDown("Horizontal");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");

            // ������ȯ ����
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

            // �ִϸ��̼� [ h�� ���� !! v�� ���� !! ]
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

    //ĳ���� ���� getter
    public short GetShortDirection()
    {
        return direction;
    }

    public Vector3 GetVector3DirVec()
    {
        return dirVec;
    }

    public void isCharacterSetter(bool isCharacter)
    {
        isCharacterMove = isCharacter;
    }

    //������ ĳ���� �ִϸ��̼� 
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
    �÷��̾� ������ ��� ���� �ڷ�ƾ���� �Լ��Դϴ�.
    �ڷ�ƾ�� ȣ���� �� �÷��̾��� ���ϴ� �ڷ�ƾ��, Ȱ���ð��� �Ű������� �޽��ϴ�.     
     */
    public void PlayerCorouine(PlayerState state, float applyTime)
    {
        playerState = state;

        switch (playerState)
        {
            case PlayerState.MoveOn:
                //StartCoroutine(Stop());
                break;
            case PlayerState.MoveOff:
                StartCoroutine(MoveStop(applyTime));
                break;
            case PlayerState.MoveSlow:
                StartCoroutine(MoveSlow(applyTime));
                break;
            default:
                break;

        }

    }

    private IEnumerator MoveStop(float applyTime)
    {
        while (true)
        {
            yield return StartCoroutine(Stop(applyTime));

            yield return StartCoroutine(Move());

            if (playerState == PlayerState.MoveOff)
            {
                break;
            }
        }
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
            // �Լ� �ݺ� ��
            yield return null;
        }
        
    }

    private IEnumerator Move()
    {
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        yield return null;
    }

    // ���ο���� �ڷ�ƾ

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
}

