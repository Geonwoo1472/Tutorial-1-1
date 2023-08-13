using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public float sightValue;                                //증가시킬 밝기 수치
    private PlayerLight2DController playerLightController;  //playerLight 스크립트

    /*
     플레이어의 LightController 스크립터에 접근하여
    밝기를 증가시키는 코루틴을 호출시킵니다.
    플레이어의 상태는 시야 증가상태로 변경하고.
    이 과정을 모두 거치면 사용이 정상적으로 완료되었으므로
    bool 값을 true로 바꿉니다.
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