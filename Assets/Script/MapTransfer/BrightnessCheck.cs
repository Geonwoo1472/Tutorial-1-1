using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 플레이어의 시야 넓이를 defalut값으로 변경합니다.
/// 
/// #object used(부착 오브젝트)#
/// 맵 이동을 담당하는 오브젝트
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 만약 플레이어가 시야 확장상태라면
/// 플레이어의 시야를 기본값으로 변경합니다.
/// 
/// </summary>
public class BrightnessCheck : MonoBehaviour
{
    /* 
     플레이어의 시야가 확장되어 있는 상태라면
    기본 상태로 돌아갑니다.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerStatus.instance.HasBrightened)
        {
            PlayerLight2DController.instance.brightnessChangeCorutin(BrightnessConstIndex.BaseLight);
            PlayerStatus.instance.HasBrightened = false;
        }
    }
}
