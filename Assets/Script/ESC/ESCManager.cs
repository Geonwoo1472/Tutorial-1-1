using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// ESC�� ���� �� �ִ� UI�� �����ϴ� ������Ʈ�Դϴ�
/// Stack ������ ����Ǿ� �ֽ��ϴ�.
/// Ű �Է��� GameManager���� �����ϹǷ�
/// �����ۼ����� �ʾҽ��ϴ�.
/// 
/// #���� ������Ʈ#
/// Empty Object
/// 
/// #Method#
/// �����ϴ�.
/// 
/// </summary>
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
