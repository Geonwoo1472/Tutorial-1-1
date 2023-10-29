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
     1. ������ ����� �� �� Ȯ���Ѵ�.
     2. �������� ��ȭ�ϴ� ������ �� 1ȸ ȣ���Ѵ�.
    �Ÿ� = �ӷ� * �ð� , ��� �պ��ϰ� ������ ����ϰ� �ִٰ� �������� �ٽ� ���ƿ��� �Ǳ��Ѵ�.
    ���� ���� �Ұ� �����غ��Ҵ�.
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
