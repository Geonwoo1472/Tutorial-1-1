using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 카메라의 크기를 재설정합니다.
/// 
/// #object used(부착 오브젝트)#
/// 충돌 시 카메라 사이즈가 변경될 필요가 있는 오브젝트
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 충돌체가 player인지 검사합니다.
/// 
/// -public void sizeChanging()
/// 카메라 사이즈를 내부 변수 값으로 변경합니다.
/// 
/// </summary>
public class CameraSizeChange : MonoBehaviour
{
    public float cameraSize;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sizeChanging();
        }
    }


    public void sizeChanging()
    {
        mainCamera.orthographicSize = cameraSize;
    }
}
