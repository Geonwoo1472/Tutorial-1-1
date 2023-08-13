using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public float sightValue;                                //������ų ��� ��ġ
    private PlayerLight2DController playerLightController;  //playerLight ��ũ��Ʈ

    /*
     �÷��̾��� LightController ��ũ���Ϳ� �����Ͽ�
    ��⸦ ������Ű�� �ڷ�ƾ�� ȣ���ŵ�ϴ�.
    �÷��̾��� ���´� �þ� �������·� �����ϰ�.
    �� ������ ��� ��ġ�� ����� ���������� �Ϸ�Ǿ����Ƿ�
    bool ���� true�� �ٲߴϴ�.
     */
    public override bool Use()
    {
        playerLightController = PlayerLight2DController.instance;
        playerLightController.playerLight2DCoroutine(sightValue);
        PlayerStatus.instance.HasBrightened = true;

        retValue = true;
        
        return base.Use();
    }
}