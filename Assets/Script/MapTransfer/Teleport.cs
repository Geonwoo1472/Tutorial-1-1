using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    public int maxNumber;                 // ���� �߻��� ��Ʈ �ѹ�
    private GameObject connectedCave;       // �ݴ��� ���� ����
    private Transform teleportPos;			// �̵��� ��ġ
    private Transform playerPos;            // �÷��̾� ��ġ 

    void Start()
    {
        int num = RandomNumber(maxNumber);
        Debug.Log(num);
        connectedCave = GameObject.Find("Teleport " + num);
        teleportPos = GameObject.Find("Spwan " + num).GetComponent<Transform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

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

    public int RandomNumber(int a)
    {
        int b = Random.Range(1, a + 1);
        int[] number = new int[a];

        if(number[b - 1] == 0)
        {
            number[b - 1] = b;
            return number[b - 1];
        }
        else
        {
            return RandomNumber(a);
        }
    }
}
