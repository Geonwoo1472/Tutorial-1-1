using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCManager : MonoBehaviour
{
    public static ESCManager instance;

    /* ESC�� ���� �� �ִ� UI�� �����ϴ� ������Ʈ�Դϴ� . */

    public Stack<UIActive> UIStack = new Stack<UIActive>();

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
