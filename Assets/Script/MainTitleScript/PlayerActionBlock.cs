using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾��� �������� �����ϴ�.
/// 
/// #object used(���� ������Ʈ)#
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
