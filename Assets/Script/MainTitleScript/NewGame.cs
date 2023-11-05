using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// ������ �����մϴ�.
/// ������ �ʱ� ������ ����˴ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Titleȭ���� Start ��ư
/// 
/// #Method#
/// -public void InGame()
/// INTROȭ������ ���� ��ȯ�մϴ�.
/// 
/// </summary>
public class NewGame : MonoBehaviour
{
    /* Ÿ��Ʋ ȭ���� NewGame ��ư �޼ҵ��Դϴ�. */
    public void InGame()
    {
        SceneManager.LoadScene(SceneConstIndex.INTRO);
        GameManager.instance.IsGameOver = false;
        StatusManager.instance.RevertValueStatus();
    }
}
