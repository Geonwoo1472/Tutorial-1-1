using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public float changeDirectionTime;
    public float moveSpeed;

    private Rigidbody2D itemRigidbody;
    private Vector2 movementTop;
    private Vector2 movementBottom;

    private void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float shiftDown = (changeDirectionTime * moveSpeed);
        movementTop = new Vector2(transform.position.x, transform.position.y + shiftDown);

        MoveUpObject();
    }

    /*
     1. 범위가 벗어난지 매 초 확인한다.
     2. 움직임이 변화하는 시점에 딱 1회 호출한다.
    거리 = 속력 * 시간 , 사실 왕복하고 원점을 기억하고 있다가 원점으로 다시 돌아오면 되긴한다.
    물리 공부 할겸 적용해보았다.
     */
    private void MoveUpObject()
    {
        itemRigidbody.velocity = new Vector2(0, moveSpeed);

        Invoke("MoveDownObject", changeDirectionTime);
    }

    private void MoveDownObject()
    {
        itemRigidbody.MovePosition(movementTop);
        itemRigidbody.velocity = new Vector2(0, -moveSpeed);

        Invoke("MoveUpObject", changeDirectionTime);
    }
}
