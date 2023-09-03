using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTile : MonoBehaviour
{
    public Sprite beforeSprite;
    public Sprite afterSprite;

    private char semaphore;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(semaphore>0)
        {
            spriteRenderer.sprite = afterSprite;
        }
        else
        {
            spriteRenderer.sprite = beforeSprite;
        }
    }
    /*
     �ڽ��� �÷��̾ �ش� ���ǿ� �ö�� ���
    �۵� ���·� �����ϰ�
     ���� ����ġ �̹����� �����մϴ�.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            ++semaphore;
        }
    }
    /*
     �ڽ��� �÷��̾ �ش� ���ǿ��� ������ ���
    ���۵� ���·� �����ϰ�
    ������ ���� ����ġ �̹����� �����մϴ�.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            --semaphore;
        }
    }
}
