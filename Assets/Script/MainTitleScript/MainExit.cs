using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 유니티 프로세스를 종료하는 기능입니다.
/// 
/// #object used(부착 오브젝트)#
/// 메인화면의 Exit, 정지화면의 Exit
/// 
/// #Method#
/// -public void ExitGame()
/// 현재는 유니티 Run을 종료합니다
/// 배포 후 기능 변경 필요합니다.
/// 
/// </summary>
public class MainExit : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        //System.Diagnostics.Process.GetCurrentProcess().Kill(); // 유니티도 종료됨.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
