using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// ���ӿ������� �� �÷��̾ ����ȭ������ ���ư� �� �ֵ����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ���ӿ��� UI�� ����Ÿ��Ʋ ��ư�� OnClick()���� ���
/// 
/// #Method#
/// /* ���� �������� �����͸� ���� �ʱ�ȭ�ϴ� �۾��� �߰��Ǿ���մϴ�*/
/// 
/// </summary>
public class OverUIMainMenu : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
