using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 플레이어의 움직임을 막습니다.
/// 
/// #object used(부착 오브젝트)#
/// Empty Object
/// 
/// #Method#
/// X
/// 
/// </summary>
public class PlayerActionBlock : MonoBehaviour
{
    public bool isValue;
    
    void Start()
    {
        GameManager.instance.MoveStatus = isValue;
    }
}
