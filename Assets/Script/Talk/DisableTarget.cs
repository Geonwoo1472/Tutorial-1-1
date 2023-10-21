using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 소멸할때 같이 소멸할 게임오브젝트를 정합니다.
/// 
/// #object used(부착 오브젝트)#
/// KeyTextTrigger
/// Position 15
/// Position 4
/// 
/// #Method#
/// -void OnDisable()
/// 지정한 게임오브젝트를 비활성합니다.
/// 
/// </summary>
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
