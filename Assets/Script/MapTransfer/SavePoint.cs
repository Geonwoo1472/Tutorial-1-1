using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 씬 변경 후 플레이어 위치를 재설정합니다.
/// 
/// #object used(부착 오브젝트)#
/// Empty Object
/// 
/// #Method#
/// -private void positionSetting()
/// GameManager가 가지고있는 현재 맵 이름과
/// 내부 문자열 변수와 값이 같다면
/// 플레이어의 위치를 SavePoint가 부착된 게임오브젝트 위치로 이동시킵니다.
/// 
/// </summary>
public class SavePoint : MonoBehaviour
{
    public string regionName;

    private Transform playerTransform;
    private GameManager gameManager;
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        gameManager = GameManager.instance;

        positionSetting();
    }
    
    private void positionSetting()
    {
        if(regionName == gameManager.currentMapName)
        {
            playerTransform.position = transform.position;
        }
    }

}
