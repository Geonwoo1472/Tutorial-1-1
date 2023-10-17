using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [현재는 사용되고 있지 않습니다.]
/// 게임 매너지가 가지고 있는 현재 맵의 문자열 정보에 따라
/// 맵핑되어 있는 곳으로 카메라가 옮겨갑니다.
/// MapToal에서 호출하여 사용하고 있습니다.
/// 
/// 부착 오브젝트 : Main Camera
/// 
/// -public void CameraPosMove()
/// 게임매니저의 문자열로 이루어진 현재 맵의 이름을 가져옵니다.
/// 이후 그 위치로 카메라의 위치를 새롭게 셋팅합니다.
/// </summary>
public class CameraMove : MonoBehaviour
{
    public void CameraPosMove()
    {
        string cameraPivot = GameManager.instance.currentMapName;
        GameObject go = GameObject.Find(cameraPivot);
        if(go != null)
        {
            transform.position = go.transform.position;
        }
        else
            Debug.Log("CameraMove.cs , go가 NULL 입니다.");
    }
}
