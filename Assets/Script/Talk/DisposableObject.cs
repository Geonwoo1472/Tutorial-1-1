using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 플레이어가 상호작용하여 실행되는 말풍선 기능을 1회성으로 변경합니다.
/// 
/// #object used(부착 오브젝트)#
/// Position27 , switch기능설명 1회용
/// 
/// #Method#
/// X
/// 
/// </summary>
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
