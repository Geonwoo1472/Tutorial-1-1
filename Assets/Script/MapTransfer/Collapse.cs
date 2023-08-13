using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{    
    public GameObject connectedCave;        // �ݴ��� ���� ����
    public Sprite activeImage;			    // ����� �̹���

    [HideInInspector]
    public bool isActive;                   // ������ ����ߴ���

    private Transform playerPos;            // �÷��̾� ��ġ
    private Collapse oppositeCollapse;      // �ݴ��� ������ ��ũ��Ʈ
    private Transform TeleportPos;			// �̵��� ��ġ
    private SpriteRenderer spriteRender;    // Sprite������Ʈ
    
    void Start()
    {
        isActive = false;

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        oppositeCollapse = connectedCave.GetComponent<Collapse>();
        TeleportPos = connectedCave.transform;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void setActive(bool _isActive)
    {
        isActive = _isActive;
        spriteRender.sprite = activeImage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerPos = TeleportPos;
        setActive(true);
        oppositeCollapse.setActive(true);
    }

}
