using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ��ǳ���� ���� �� �÷��̾ ������ �������� ���� �̵���ŵ�ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// �����Ű�� ���� ���ӿ�����Ʈ
/// AutoTalk�� ������Ƽ������ ��������, Compulsion ������� �ص� ��
/// �ش� ������Ʈ�� �߰��Ͽ� ���
/// 
/// #Method#
/// -public void CorotineCompulsionMove()
/// ������ �������� ������ �ð���ŭ
/// �÷��̾� �������� ���Ƶΰ� �÷��̾ ���� �̵���ŵ�ϴ�.
/// 
/// 
/// </summary>
public class PlayerCompulsionMove : MonoBehaviour
{
    public Direction compulsionDirection;               // �÷��̾ ������ �̵��� ����
    public float targetTime;                            // ������ �̵��� ��ǥ �ð�

    private float progressTime;                         // ���� ���� �ð�
    private Vector2 direction;                          // �÷��̾ ������ �̵��� ����
    private Rigidbody2D playerRigid;                    // �÷��̾� Rigid
    private Animator anim;                              // �÷��̾� Animator
    private AutoTalk autoTalkScript;                    // AutoTalkScript�� �������� �� ����

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
     �ڷ�ƾ ���� �޼ҵ��Դϴ�.
    ȣ���ϸ� ���� ���ӽð��� �ʱ�ȭ�ϰ� �ڷ�ƾ�� �����մϴ�.
     */
    public void CoroutineCompulsionMove()
    {
        progressTime = 0;
        StartCoroutine(CompulsionMove());
    }

    /*
     ���� �Ŵ����� �ִ� MoveStatus���� �����Ͽ�
    �÷��̾��� ������ �Է�Ű�� ���� ���ϰ� �����ϴ�.
    ���� ������ �������� targetTime�� �ð���ŭ �÷��̾�� �̵��ϰԵ˴ϴ�.
    �÷��̾� �������� ���� �� 
    StayƮ���ſ��� ����ϰ� �ִ� semapo����
    ������ �����ϰ��ִ� MoveStatus���� �����Ͽ� ������ �� �ֵ��� �����մϴ�.
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
     �ڷ�ƾ ���ο��� ����ϴ� �ִϸ��̼� ������ �޼ҵ��Դϴ�.
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
