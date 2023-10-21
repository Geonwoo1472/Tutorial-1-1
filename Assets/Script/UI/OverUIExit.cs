using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 프로세스를 종료합니다
/// 
/// #object used(부착 오브젝트)#
/// 버튼의 OnClick() 으로 호출
/// 
/// #Method#
/// -public void ExitGame()
/// 프로세스를 종료합니다.
/// 
/// </summary>
public class OverUIExit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        //System.Diagnostics.Process.GetCurrentProcess().Kill(); 아니 유니티도 꺼지면 어카냐고 ㅋㅋ
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene(0);

#endif
    }
}
