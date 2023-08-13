using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessCheck : MonoBehaviour
{
    /* 
     �÷��̾��� �þ߰� Ȯ��Ǿ� �ִ� ���¶��
    �⺻ ���·� ���ư��ϴ�.
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
