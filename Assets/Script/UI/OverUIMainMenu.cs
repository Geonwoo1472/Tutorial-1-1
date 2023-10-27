using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 게임오버됐을 시 플레이어가 메인화면으로 돌아갈 수 있도록합니다.
/// 
/// #object used(부착 오브젝트)#
/// 게임오버 UI의 메인타이틀 버튼의 OnClick()으로 등록
/// 
/// #Method#
/// /* 현재 진행중인 데이터를 전부 초기화하는 작업이 추가되어야합니다*/
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
