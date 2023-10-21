using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 플레이어가 상호작용하면 나무 오브젝트를 비활성 시키고
/// 관련된 기능들이 실행됩니다.
/// 
/// #object used(부착 오브젝트)#
/// BrokenTree
/// 
/// #Method#
/// -public override void InteractionDestroy()
/// 플레이어의 피로도를 감소시킵니다.
/// 나무가 베어지는 효과음을 출력합니다.
/// 이후 대상이 되는 게임오브젝트를 비활성시킵니다.
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
