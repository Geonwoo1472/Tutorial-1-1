using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightComponent : MonoBehaviour
{
    public bool lightYN;
    private PlayerLight2DController lightObject;

    private void Start()
    {
        lightObject = PlayerLight2DController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightObject.LightSetActive(lightYN);
    }

}
