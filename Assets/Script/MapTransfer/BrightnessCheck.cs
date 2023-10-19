using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾��� �þ� ���̸� defalut������ �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// �� �̵��� ����ϴ� ������Ʈ
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// ���� �÷��̾ �þ� Ȯ����¶��
/// �÷��̾��� �þ߸� �⺻������ �����մϴ�.
/// 
/// </summary>
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
            PlayerLight2DController.instance.brightnessChangeCorutin(BrightnessConstIndex.BaseLight);
            PlayerStatus.instance.HasBrightened = false;
        }
    }
}
