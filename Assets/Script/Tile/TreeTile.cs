using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTile : IDestroyable
{   
    public override void interactionDestroy()
    {
        if (!destroyTree)
            return;

        PlayerStatus.instance.OnDamageFatigue(HF_Constance.TREETILE);
        Destroy(gameObject);
        
    }

    
}
