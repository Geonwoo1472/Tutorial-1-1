using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// 씬마다 카메라 사이즈 변경에 따라
/// 카메라 사이즈를 새롭게 설정합니다.
/// 
/// #부착 오브젝트#
/// Empty Object
/// 
/// #Method#
/// 없음.
/// 
/// </summary>
public class CameraSizeSet : MonoBehaviour
{
    public float cameraSize;
    Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (mainCamera == null)
            Debug.Log("카메라 널!! :( ");

        mainCamera.orthographicSize = cameraSize;
    }

    
}
