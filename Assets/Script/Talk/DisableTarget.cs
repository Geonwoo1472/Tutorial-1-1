using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    public GameObject target;

    /*
    소멸할때 같이 소멸할 게임오브젝트를 정합니다.
     */
    private void OnDisable()
    {
        Debug.Log("OnDisable 호출");
        target.SetActive(false);
    }
}
