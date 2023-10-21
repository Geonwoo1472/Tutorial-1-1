using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// ���μ����� �����մϴ�
/// 
/// #object used(���� ������Ʈ)#
/// ��ư�� OnClick() ���� ȣ��
/// 
/// #Method#
/// -public void ExitGame()
/// ���μ����� �����մϴ�.
/// 
/// </summary>
public class OverUIExit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        //System.Diagnostics.Process.GetCurrentProcess().Kill(); �ƴ� ����Ƽ�� ������ ��ī�İ� ����
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene(0);

#endif
    }
}
