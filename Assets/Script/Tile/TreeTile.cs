using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTile : IDestroyable
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    public override void interactionDestroy()
    {
        if (!destroyTree)
            return;

        PlayerStatus.instance.OnDamageFatigue(HF_Constance.TREETILE);
        soundManager.TreeBrokenSound();
        gameObject.SetActive(false);
        
    }
}
