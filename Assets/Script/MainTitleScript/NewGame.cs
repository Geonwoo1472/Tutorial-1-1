using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    /* 타이틀 화면의 NewGame 버튼 메소드입니다. */
    public void InGame()
    {
        SceneManager.LoadScene(SceneConstIndex.INTRO);
        
    }
}
