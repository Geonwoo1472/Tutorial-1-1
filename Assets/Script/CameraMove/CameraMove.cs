using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /*
     게임 매너지가 가지고 있는 현재 맵의 문자열 정보에 따라
    맵핑되어 있는 곳으로 카메라가 옮겨갑니다.
    MapToal에서 호출하여 사용하고 있습니다.
     */
    public void CameraPosMove()
    {
        string cameraPivot = GameManager.instance.currentMapName;
        GameObject go = GameObject.Find(cameraPivot);
        if(go != null)
        {
            transform.position = go.transform.position;
        }
        else
            Debug.Log("go가 NULL 입니다.");
    }
}
