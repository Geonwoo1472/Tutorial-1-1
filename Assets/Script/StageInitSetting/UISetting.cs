using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : MonoBehaviour
{
    public bool hungerFatigueUI_YN;
    private GameObject hungerFatigueUI;
    private HF_UI hf_UI;

    void Start()
    {
        hungerFatigueUI = GameObject.Find("Canvas").transform.Find("HungerFatigueUI").gameObject;
        hf_UI = hungerFatigueUI.GetComponent<HF_UI>();

        OnStatusUI();
    }

    private void OnStatusUI()
    {
        hungerFatigueUI.SetActive(hungerFatigueUI_YN);
        hf_UI.ChangeStatusUI();
    }
}
