using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// ESC로 닫을 수 있는 UI를 관리하는 컴포넌트입니다
/// Stack 변수가 선언되어 있습니다.
/// 키 입력은 GameManager에서 관리하므로
/// 로직작성하지 않았습니다.
/// 
/// #부착 오브젝트#
/// Empty Object
/// 
/// #Method#
/// 없습니다.
/// 
/// </summary>
public class ESCManager : MonoBehaviour
{
    public static ESCManager instance;

    /* ESC로 닫을 수 있는 UI를 관리하는 컴포넌트입니다 . */

    public Stack<UIActive> UIStack = new Stack<UIActive>();

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
