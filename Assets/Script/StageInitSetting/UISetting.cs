using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : MonoBehaviour
{
    public bool hungerFatigueUI_YN;
    private GameObject hungerFatigueUI;
    
    void Start()
    {
        hungerFatigueUI = GameObject.Find("Canvas").transform.Find("HungerFatigueUI").gameObject;

        OnStatusUI();
    }

    private void OnStatusUI()
    {
        hungerFatigueUI.SetActive(hungerFatigueUI_YN);
    }
}
