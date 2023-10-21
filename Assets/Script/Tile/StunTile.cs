using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �ش� ������Ʈ�� �浹�� ��� �÷��̾ ���� ������ ���� �ð���ŭ ������ŵ�ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// StunTile
/// 
/// #Method#
/// -void OnTriggerEnter2D(Collider2D)
/// �÷��̾ ��õ��� �������� ���ϵ����մϴ�.
/// 
/// </summary>
public class StunTile : MonoBehaviour
{
    [Header("�����ð�")]
    public float stunTime;

    private Player_Action playerAction;

    void Start()
    {
        playerAction = Player_Action.instance;    
    }

    /*
     �÷��̾ Ʈ���Ÿ� Ȱ��ȭ ��Ű��
     stunTime �ð���ŭ ����ϴ�.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerAction.PlayerCorouine(PlayerState.pauseMovement, stunTime);
        }
    }

}
