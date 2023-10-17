using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// ������ ī�޶� ������ ���濡 ����
/// ī�޶� ����� ���Ӱ� �����մϴ�.
/// 
/// #���� ������Ʈ#
/// Empty Object
/// 
/// #Method#
/// ����.
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
            Debug.Log("ī�޶� ��!! :( ");

        mainCamera.orthographicSize = cameraSize;
    }

    
}
