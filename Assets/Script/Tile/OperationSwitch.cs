using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ����ġ�� ������ �� ��ɵ��� ���ǵǾ� �ֽ��ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Switch ���ӿ�����Ʈ
/// 
/// #Method#
/// -public void IsAction()
/// �÷��̾� RayCast���� ȣ���մϴ�.
/// ����ġ�� ON <-> OFF �մϴ�.
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
