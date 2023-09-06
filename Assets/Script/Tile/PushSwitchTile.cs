using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSwitchTile : MonoBehaviour
{
    public Sprite beforeSprite;
    public Sprite afterSprite;

    public delegate void OnSwitchActive();
    public OnSwitchActive onSwitchActive;
    public delegate void OffSwitchActive();
    public OffSwitchActive offSwitchActive;

    private char semaphore;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        semaphore = '\0';
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
            if (semaphore == 0)
                AfterRender();
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
            if (semaphore == 0)
                BeforeRender();
        }
    }


    private void BeforeRender()
    {
        spriteRenderer.sprite = beforeSprite;
        offSwitchActive.Invoke();
    }

    private void AfterRender()
    {
        spriteRenderer.sprite = afterSprite;
        onSwitchActive.Invoke();
    }

}
