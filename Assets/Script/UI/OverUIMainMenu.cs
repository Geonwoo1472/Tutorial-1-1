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
    private Transform playerPos;

    private void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    /* Main Title [button] */
    public void LoadMainScene()
    {
        SceneManager.LoadScene(SceneConstIndex.MAINTITLE);
        SetPlayerBeginPosition();
        ESCManager.instance.EmptyStack();
        Inventory.instance.EmptyInventory();
        StatusManager.instance.RevertValueStatus();
    }

    private void SetPlayerBeginPosition()
    {
        Vector2 vec = new Vector2(-11.3f, 3.9f);
        playerPos.position = vec;
    }   
    
}
