using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// #용도#
/// 플레이어의 시야를 어느정도 밝힐 치 값을 설정하고,
/// PlayerLight2D에 정의되어 있는 코루틴을 실행하는 기능입니다.
/// 
/// #부착 오브젝트#
/// 시야를 밝혀주는 아이템 FildItem 스크립트의
/// public Item 변수에 인스펙터창으로 초기화
/// 
/// #Method#
/// -public override bool Use()
/// 플레이어의 LightController 스크립터에 접근하여
/// 밝기를 증가시키는 코루틴을 호출시킵니다.
/// 플레이어의 상태는 시야 증가상태로 변경하고.
/// 이 과정을 모두 거치면 사용이 정상적으로 완료되었으므로
/// bool 값을 true로 바꿉니다.
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public float sightValue;                                //증가시킬 밝기 수치
    private PlayerLight2DController playerLightController;  //playerLight 스크립트

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