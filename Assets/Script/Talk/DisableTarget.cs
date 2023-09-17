using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    public GameObject target;
    public bool targetIsActive;

    /*
    소멸할때 같이 소멸할 게임오브젝트를 정합니다.
     */
    private void OnDisable()
    {
        Debug.Log("OnDisable 호출");
        if(target != null)
            target.SetActive(targetIsActive);
    }
}
