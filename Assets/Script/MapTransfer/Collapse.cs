using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collapse : MonoBehaviour
{
    public GameObject connectedCave;        // 반대편 동굴 정보
    public Sprite activeImage;			    // 변경될 이미지
    public Transform teleportPos;			// 이동할 위치

    [HideInInspector]
    public bool isActive;                   // 동굴을 사용했는지

    private Transform playerPos;            // 플레이어 위치 
    private Collapse oppositeCollapse;      // 반대편 동굴의 스크립트
    private SpriteRenderer spriteRender;    // Sprite컴포넌트
    private BoxCollider2D boxCollider;      // boxCollider 컴포넌트 

    void Start()
    {
        isActive = false;

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        oppositeCollapse = connectedCave.GetComponent<Collapse>();
        spriteRender = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    /*
     Triger가 체크되어 있는 경우 발동.
    플레이어의 위치를 지정한 위치로 이동시키고
    다시 사용하지 못하도록 bool 값을 변경하고,
    동굴 이미지를 바꿉니다.
    이후 반대편 동굴도 같은 작업을 반복합니다.
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
