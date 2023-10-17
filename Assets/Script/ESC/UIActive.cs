using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// OnActive()�� ����ϱ� ���� �߻�Ŭ����
/// UI�� ESC�� �ݱ� ���� Stack���� �����Ǵ� ������ ����
/// 
/// 
/// #���� ������Ʈ#
/// ESC�� �ݰ��� �ϴ� ������Ʈ.
/// 
/// #Method#
/// -public abstract void OnActive()
/// override ����
/// 
/// </summary>
public abstract class UIActive : MonoBehaviour
{
    public abstract void OnActive();
}
