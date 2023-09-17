using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    public Transform teleportPos;			// �̵��� ��ġ
    private Transform playerPos;            // �÷��̾� ��ġ 

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }
    /*
     Triger�� üũ�Ǿ� �ִ� ��� �ߵ�.
    �÷��̾��� ��ġ�� ������ ��ġ�� �̵���Ű��
    �ٽ� ������� ���ϵ��� bool ���� �����ϰ�,
    ���� �̹����� �ٲߴϴ�.
    ���� �ݴ��� ������ ���� �۾��� �ݺ��մϴ�.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collapsing();
        }
    }
    protected virtual void Collapsing()
    {
        playerPos.position = teleportPos.position;
    }
}
