using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSwitch : MonoBehaviour
{
    public Sprite[] changeSprite;
    

    private SpriteRenderer spriteRenderer;
    private bool isAction;
    private int spriteIndex;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isAction = false;
        spriteIndex = 0;
    }
    
    public void IsAction()
    {
        isAction = !isAction;
        spriteRenderer.sprite = changeSprite[spriteIndex];
        spriteIndex = ++spriteIndex % 2;
    }
}
