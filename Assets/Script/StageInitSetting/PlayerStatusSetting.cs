using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StatusManager.instance.GetFatigueIndex();
        StatusManager.instance.GetHungerIndex();
        StatusManager.instance.SetStatusValue();
    }
}
