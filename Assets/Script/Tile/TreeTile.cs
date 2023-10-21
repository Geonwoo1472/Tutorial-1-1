using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾ ��ȣ�ۿ��ϸ� ���� ������Ʈ�� ��Ȱ�� ��Ű��
/// ���õ� ��ɵ��� ����˴ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// BrokenTree
/// 
/// #Method#
/// -public override void InteractionDestroy()
/// �÷��̾��� �Ƿε��� ���ҽ�ŵ�ϴ�.
/// ������ �������� ȿ������ ����մϴ�.
/// ���� ����� �Ǵ� ���ӿ�����Ʈ�� ��Ȱ����ŵ�ϴ�.
/// 
/// </summary>
public class TreeTile : IDestroyable
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    public override void InteractionDestroy()
    {
        if (!destroyTree)
            return;

        PlayerStatus.instance.OnDamageFatigue(HF_Constance.TREETILE);
        soundManager.SoundPlaying(SoundType.breakTree);
        gameObject.SetActive(false);
        
    }
}
