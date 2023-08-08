using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Scriptable/EyesightItem", fileName = "Item Data")]
[System.Serializable]
public class EyesightItem : Item
{
    public float sightValue;
    // private·Î º¯°æ
    private PlayerLight2DController playerLightController;


    public override bool Use()
    {
        playerLightController = PlayerLight2DController.instance;
        playerLightController.playerLight2DCoroutine(sightValue);
        retValue = true;
        
        return base.Use();
    }
}