using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ����Ƽ ���μ����� �����ϴ� ����Դϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ����ȭ���� Exit, ����ȭ���� Exit
/// 
/// #Method#
/// -public void ExitGame()
/// ����� ����Ƽ Run�� �����մϴ�
/// ���� �� ��� ���� �ʿ��մϴ�.
/// 
/// </summary>
public class MainExit : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        //System.Diagnostics.Process.GetCurrentProcess().Kill(); // ����Ƽ�� �����.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
