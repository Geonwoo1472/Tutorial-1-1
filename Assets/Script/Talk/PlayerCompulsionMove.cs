using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompulsionMove : MonoBehaviour
{
    public Direction compulsionDirection;
    public float targetTime;

    private float progressTime;
    private Vector2 direction;
    private Rigidbody2D playerRigid;
    private Animator anim;

    private void Awake()
    {
        progressTime = 0;
        InitDirection();
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

    public void CoroutineCompulsionMove()
    {
        progressTime = 0;
        StartCoroutine(CompulsionMove());
    }

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
    }

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
