using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCaller : MonoBehaviour
{
    private LoadPopupActive loadPopupActive;
    
    void Start()
    {
        loadPopupActive = GameObject.Find("Canvas").transform.Find("(P)Load Popup").GetComponent<LoadPopupActive>();
    }

    public void LoadBtnOnClick()
    {
        loadPopupActive.OnActive();
    }
}
