using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
