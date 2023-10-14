using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
