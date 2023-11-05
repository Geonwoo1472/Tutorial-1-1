using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 게임을 진행합니다.
/// 게임의 초기 셋팅이 진행됩니다.
/// 
/// #object used(부착 오브젝트)#
/// Title화면의 Start 버튼
/// 
/// #Method#
/// -public void InGame()
/// INTRO화면으로 씬을 전환합니다.
/// 
/// </summary>
public class NewGame : MonoBehaviour
{
    /* 타이틀 화면의 NewGame 버튼 메소드입니다. */
    public void InGame()
    {
        SceneManager.LoadScene(SceneConstIndex.INTRO);
        GameManager.instance.IsGameOver = false;
        StatusManager.instance.RevertValueStatus();
    }
}
