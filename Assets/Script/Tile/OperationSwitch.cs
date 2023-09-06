using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationSwitch : MonoBehaviour
{
    public Sprite[] changeSprite;

    public delegate void OperationSwitchOn();
    public OperationSwitchOn operationSwitchOn;

    public delegate void OperationSwitchOff();
    public OperationSwitchOff operationSwitchOff;

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
        if (isAction)
            operationSwitchOn.Invoke();
        else
            operationSwitchOff.Invoke();
        spriteRenderer.sprite = changeSprite[spriteIndex];
        ++spriteIndex;
        spriteIndex = spriteIndex % 2;
    }
}
