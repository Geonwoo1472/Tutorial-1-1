using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour

    // Ÿ��Ʋ ȭ�� NewGame ��ư�� ��ũ��Ʈ
{   public void InGame()
    {
        SceneManager.LoadScene(SceneConstIndex.CHAPTER1);
        
    }
}
