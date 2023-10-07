using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableObject : MonoBehaviour
{
    private DalogManager dalogManager;
    // Start is called before the first frame update
    void Start()
    {
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        dalogManager.lastDalog += DeleteObject;
    }

    private void DeleteObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        dalogManager.lastDalog -= DeleteObject;
    }
}
