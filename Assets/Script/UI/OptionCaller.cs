using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCaller : MonoBehaviour
{
    private ControlOptionActive controlOptionActive;

    void Start()
    {
        controlOptionActive = GameObject.Find("Canvas").transform.Find("(C)Option Popup").GetComponent<ControlOptionActive>();
    }

    public void OptionBtnOnClick()
    {
        controlOptionActive.OnActive();
    }
}
