using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// #�뵵#
/// �÷��̾��� �þ߸� ������� ���� ġ ���� �����ϰ�,
/// PlayerLight2D�� ���ǵǾ� �ִ� �ڷ�ƾ�� �����ϴ� ����Դϴ�.
/// 
/// #���� ������Ʈ#
/// �þ߸� �����ִ� ������ FildItem ��ũ��Ʈ��
/// public Item ������ �ν�����â���� �ʱ�ȭ
/// 
/// #Method#
/// -public override bool Use()
/// �÷��̾��� LightController ��ũ���Ϳ� �����Ͽ�
/// ��⸦ ������Ű�� �ڷ�ƾ�� ȣ���ŵ�ϴ�.
/// �÷��̾��� ���´� �þ� �������·� �����ϰ�.
/// �� ������ ��� ��ġ�� ����� ���������� �Ϸ�Ǿ����Ƿ�
/// bool ���� true�� �ٲߴϴ�.
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public float sightValue;                                //������ų ��� ��ġ
    private PlayerLight2DController playerLightController;  //playerLight ��ũ��Ʈ

    public override bool Use()
    {
        playerLightController = PlayerLight2DController.instance;
        playerLightController.brightnessChangeCorutin(sightValue);
        PlayerStatus.instance.HasBrightened = true;
        SoundManager.instance.SoundPlaying(SoundType.torchSound);

        retValue = true;
        
        return base.Use();
    }
}