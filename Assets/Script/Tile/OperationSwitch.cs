using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 스위치가 가져야 할 기능들이 정의되어 있습니다.
/// 
/// #object used(부착 오브젝트)#
/// Switch 게임오브젝트
/// 
/// #Method#
/// -public void IsAction()
/// 플레이어 RayCast에서 호출합니다.
/// 스위치를 ON <-> OFF 합니다.
/// 
/// </summary>
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

        SoundManager.instance.SoundPlaying(SoundType.switchOperation);

        ++spriteIndex;
        spriteIndex = spriteIndex % 2;
    }
}
