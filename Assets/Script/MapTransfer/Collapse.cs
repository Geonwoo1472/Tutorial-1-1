using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collapse : MonoBehaviour
{
    public GameObject connectedCave;        // �ݴ��� ���� ����
    public Sprite activeImage;			    // ����� �̹���
    public Transform teleportPos;			// �̵��� ��ġ

    [HideInInspector]
    public bool isActive;                   // ������ ����ߴ���

    private Transform playerPos;            // �÷��̾� ��ġ 
    private Collapse oppositeCollapse;      // �ݴ��� ������ ��ũ��Ʈ
    private SpriteRenderer spriteRender;    // Sprite������Ʈ
    private BoxCollider2D boxCollider;      // boxCollider ������Ʈ 

    void Start()
    {
        isActive = false;

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        oppositeCollapse = connectedCave.GetComponent<Collapse>();
        spriteRender = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        if (isActive)
            return;

        if (collision.CompareTag("Player"))
        {
            Collapsing();
            SoundManager.instance.SoundPlaying(SoundType.collapseSound);
        }
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
        spriteRender.sprite = activeImage;
        boxCollider.isTrigger = false;
    }

    protected virtual void Collapsing()
    {
        playerPos.position = teleportPos.position;
        SetActive(true);
        oppositeCollapse.SetActive(true);
    }
}
