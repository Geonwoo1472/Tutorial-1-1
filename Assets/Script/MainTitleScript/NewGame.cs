using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    /* Ÿ��Ʋ ȭ���� NewGame ��ư �޼ҵ��Դϴ�. */
    public void InGame()
    {
        SceneManager.LoadScene(SceneConstIndex.INTRO);
        
    }
}
