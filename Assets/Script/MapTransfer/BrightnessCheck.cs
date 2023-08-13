using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            PlayerLight2DController.instance.playerLight2DCoroutine(BrightnessConstIndex.BaseLight);
            PlayerStatus.instance.HasBrightened = false;
        }
    }
}
