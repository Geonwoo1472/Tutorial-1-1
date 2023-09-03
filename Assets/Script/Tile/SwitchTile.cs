using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTile : MonoBehaviour
{
    public Sprite beforeSprite;
    public Sprite afterSprite;
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    /*
     박스나 플레이어가 해당 발판에 올라온 경우
    작동 상태로 변경하고
     눌린 스위치 이미지로 변경합니다.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            spriteRenderer.sprite = afterSprite;
        }
    }
    /*
     박스나 플레이어가 해당 발판에서 떨어진 경우
    비작동 상태로 변경하고
    눌리지 않은 스위치 이미지로 변경합니다.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            spriteRenderer.sprite = beforeSprite;
        }
    }
}
